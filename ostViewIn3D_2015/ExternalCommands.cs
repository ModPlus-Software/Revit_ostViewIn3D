namespace ostViewIn3D
{
    using System.Collections.Generic;
    using System.Linq;
    using Autodesk.Revit.Attributes;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.Exceptions;
    using Autodesk.Revit.UI;
    using Autodesk.Revit.UI.Selection;
    using ModPlusAPI;

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class ExternalCommands : IExternalCommand
    {
        private const string LangItem = "ostViewIn3D";
        public static Scroller ScrollerWin = null;

        /// <inheritdoc/>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Statistic.SendCommandStarting(new ModPlusConnector());

            UIApplication appRevit = commandData.Application;
            if (ScrollerWin != null)
            {
                return Result.Cancelled;
            }

            if (!SetSelection(appRevit))
            {
                return Result.Cancelled;
            }

            SectionBox sectionBox = new SectionBox();
            sectionBox.SetSectionBox(appRevit,0);
            ExternalEventApplication handler = new ExternalEventApplication();
            ExternalEvent exEvent = ExternalEvent.Create(handler);                // Создаем событие
            ScrollerWin = new Scroller(appRevit, exEvent);
            ScrollerWin.Closed += ScrollerWin_Closed;
            ScrollerWin.Show();
            return Result.Succeeded;
        }

        private void ScrollerWin_Closed(object sender, System.EventArgs e)
        {
            ScrollerWin = null;
        }

        private bool SetSelection(UIApplication uiApplication)
        {
            var selection = uiApplication.ActiveUIDocument.Selection;
            var doc = uiApplication.ActiveUIDocument.Document;
            var selectedIds = selection.GetElementIds();
            if (selectedIds.Any())
            {
                var selectedExceptSectionBox = new List<Element>();
                foreach (ElementId id in selectedIds)
                {
                    var element = doc.GetElement(id);
                    if (element.Category.Id.IntegerValue != (int)BuiltInCategory.OST_SectionBox)
                    {
                        selectedExceptSectionBox.Add(element);
                    }
                }

                if (selectedExceptSectionBox.Any())
                {
                    return true;
                }
            }

            try
            {
                var selSet = selection.PickObjects(
                    ObjectType.Element,
                    new SelFilter(), 
                    Language.GetItem(LangItem, "msg1")).Select(r =>r.ElementId).ToList();
                selection.SetElementIds(selSet);
                return selSet.Any();
            }
            catch (OperationCanceledException)
            {
                return false;
            }
        }
    }

    internal class SelFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_SectionBox)
            {
                return false;
            }

            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
