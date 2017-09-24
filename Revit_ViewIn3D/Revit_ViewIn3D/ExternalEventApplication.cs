using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revit_3DSectionBox
{
 public   class ExternalEventApplication : IExternalEventHandler
    {
        public ExternalEventApplication() { }
   

        public void Execute(UIApplication app)
        {
           SectionBox sectionBox = new SectionBox();
           sectionBox.SetSectionBox(app,MainForm.offset);
        }

        public string GetName()
        {
            return "";
        }


        void MethodExample()
        {
            MessageBox.Show("");
        }
    }
}
