using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using ModPlusAPI;
using ModPlusAPI.Windows;

namespace ostViewIn3D
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class ExternalCommands : IExternalCommand
    {
        public static Scroller ScrollerWin = null;

        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            Statistic.SendCommandStarting(new Interface());

            UIApplication appRevit = commandData.Application;
            if (ScrollerWin != null)
                return Result.Cancelled;
            
            //if (appRevit.ActiveUIDocument.Selection.GetElementIds().Count == 0)
            //{
            //    MessageBox.Show("Нужно выбрать элемент", MessageBoxIcon.Alert);
            //    return Result.Cancelled;
            //}
            if (!SetSelection(appRevit)) return Result.Cancelled;
            SectionBox sectionBox = new SectionBox();
            sectionBox.SetSectionBox(appRevit,0);
            ExternalEventApplication handler = new ExternalEventApplication();
            ExternalEvent exEvent = ExternalEvent.Create(handler);                //Создаем событие
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
            if (selection.GetElementIds().Any()) return true;
            try
            {
                var selSet = selection.PickObjects(ObjectType.Element, "Выберите элементы для 3D подрезки").Select(r=>r.ElementId).ToList();
                selection.SetElementIds(selSet);
                return selSet.Any();
            }
            catch (OperationCanceledException)
            {
                return false;
            }
        }
    }
}
