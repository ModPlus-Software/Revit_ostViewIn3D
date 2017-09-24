using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace ostViewIn3D
{
    public class ExternalEventApplication : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            SectionBox sectionBox = new SectionBox();
            sectionBox.SetSectionBox(app, ExternalCommands.ScrollerWin.offset);
        }

        public string GetName()
        {
            return "";
        }
    }
}
