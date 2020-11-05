namespace ostViewIn3D
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;

    public class SectionBox
    {
        public void SetSectionBox(UIApplication app, int offset)
        {
            var doc = app.ActiveUIDocument.Document;
            Element currentView = app.ActiveUIDocument.ActiveView;
            View3D view3D = null;
            var userName = Environment.UserName;

            var list3D = new FilteredElementCollector(doc).OfClass(typeof(View3D)).ToList();
            if (currentView is View3D)
            {
                view3D = currentView as View3D;
            }
            else
            {
                if (list3D.Any())
                {
                    var my3D = list3D.Where(x => x.Name.ToUpper().Contains(userName.ToUpper())).ToList();
                    if (my3D.Count != 0)
                    {
                        view3D = my3D[0] as View3D;
                    }
                }
            }

            if (view3D == null)
            {
                using (var tr = new Transaction(doc, "Create 3D view"))
                {
                    tr.Start();
                    if (list3D.Any() && list3D[0].GetTypeId().IntegerValue == -1)
                    {
                        var threeD =
                            new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType))
                                .Cast<ViewFamilyType>()
                                .FirstOrDefault(x => x.ViewFamily == ViewFamily.ThreeDimensional);
                        view3D = View3D.CreateIsometric(doc, threeD?.Id);
                    }
                    else
                    {
                        if (list3D.Any())
                        {
                            view3D = View3D.CreateIsometric(doc, list3D[0].GetTypeId());
                        }
                        else
                        {
                            var threeD =
                                new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType))
                                    .Cast<ViewFamilyType>()
                                    .FirstOrDefault(x => x.ViewFamily == ViewFamily.ThreeDimensional);
                            view3D = View3D.CreateIsometric(doc, threeD?.Id);
                        }
                    }
#if R2017 || R2018
                    view3D.ViewName = "3D - " + userName;
#else
                    view3D.Name = "3D - " + userName;
#endif
                    tr.Commit();
                }
            }

            app.ActiveUIDocument.ActiveView = view3D;
            var elements = app.ActiveUIDocument.Selection.GetElementIds()
                .Select(id => doc.GetElement(id)).Where(el => el.Category.Id.IntegerValue != (int)BuiltInCategory.OST_SectionBox).ToList();

            var points = GetBoundingBoxXYZ(elements, doc);
            var box = new BoundingBoxXYZ();
            box.Max = new XYZ(points[0].X + offset, points[0].Y + offset, points[0].Z + offset);
            box.Min = new XYZ(points[1].X - offset, points[1].Y - offset, points[1].Z - offset);
            using (var tr = new Transaction(doc, "Create 3D section"))
            {
                tr.Start();
                try
                {
                    view3D.SetSectionBox(box);
                    if (ExternalCommands.ScrollerWin.IsSectionView)
                    {
                        app.ActiveUIDocument.ShowElements(app.ActiveUIDocument.Selection.GetElementIds());
                    }
                }
                catch
                {
                    // ignored
                }

                tr.Commit();
            }
        }

        private List<Point3D> GetBoundingBoxXYZ(List<Element> listElements, Document doc)
        {
            var listPoints = new List<Point3D>();
            var max = new XYZ();
            var min = new XYZ();
            double maxX = -10000000;
            double maxY = -10000000;
            double maxZ = -10000000;
            double minX = 10000000;
            double minY = 100000000;
            double minZ = 10000000;

            Transform transform = null;
            var collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(RevitLinkInstance));
            foreach (var el in collector)
            {
                var instance = el as RevitLinkInstance;
                if (instance == null)
                    continue;
                transform = instance.GetTotalTransform();
                break;
            }

            foreach (var el in listElements)
            {
                var boundingBox = el.get_BoundingBox(null);
                if (boundingBox == null)
                    continue;
                if (boundingBox.Max.X > maxX)
                    maxX = boundingBox.Max.X;
                if (boundingBox.Max.Y > maxY)
                    maxY = boundingBox.Max.Y;
                if (boundingBox.Max.Z > maxZ)
                    maxZ = boundingBox.Max.Z;
                if (boundingBox.Min.X < minX)
                    minX = boundingBox.Min.X;
                if (boundingBox.Min.Y < minY)
                    minY = boundingBox.Min.Y;
                if (boundingBox.Max.Z < minZ)
                    minZ = boundingBox.Min.Z;
                max = new XYZ(maxX, maxY, maxZ);
                min = new XYZ(minX, minY, minZ);
                if (el.Document.Title != doc.Title)
                {
                    max = transform.OfPoint(max);
                    min = transform.OfPoint(min);
                }
            }

            var pointMax = new Point3D();
            pointMax.X = max.X;
            pointMax.Y = max.Y;
            pointMax.Z = max.Z;

            var pointMin = new Point3D();
            pointMin.X = min.X;
            pointMin.Y = min.Y;
            pointMin.Z = min.Z;

            listPoints.Add(pointMax);
            listPoints.Add(pointMin);
            return listPoints;
        }
    }

    public class Point3D
    {
        public double X { get; set; }
        
        public double Y { get; set; }
        
        public double Z { get; set; }
    }
}
