using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Revit_3DSectionBox
{
    class ExternalApplication : IExternalApplication
    {

        public static ExternalApplication thisApp = null;
       private MainForm mainForm;
       static RibbonPanel ribbonPanel;
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            if (!application.GetRibbonPanels().Any(x => x.Name.Equals("3D Section Box")))
                ribbonPanel = application.CreateRibbonPanel("3DSectionBox");
            else ribbonPanel = application.GetRibbonPanels().Where(x => x.Name.Equals("3D Section Box")).ToList()[0];
            PushButtonData viewWaterMark = new PushButtonData("3D Section Box", "3D Section Box",
               Assembly.GetExecutingAssembly().Location, "Revit_3DSectionBox.ExternalCommands");
            IntPtr hBitmap = Revit_3DSectionBox.Properties.Resources._3DSectionBox_32x32_.GetHbitmap();
            BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();

            var destination= System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, sizeOptions);
            var destination1 = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(Revit_3DSectionBox.Properties.Resources._3DSectionBox_16x16_.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, sizeOptions);
            viewWaterMark.LargeImage = destination;
            viewWaterMark.Image = destination1;
            viewWaterMark.ToolTip = "3D Section Box";
            viewWaterMark.LongDescription = "Select element and push button for create section box";
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
           
            ContextualHelp context = new ContextualHelp(ContextualHelpType.Url, dir.Parent.FullName + "\\" + "help.htm");
            viewWaterMark.SetContextualHelp(context);
           // viewWaterMark.SetContextualHelp(context);
            ribbonPanel.AddItem(viewWaterMark);
            mainForm = null;
            thisApp = this;
            return Result.Succeeded;
        }

        public void ShowMainForm(UIApplication appRevit)
        {
            ExternalEventApplication handler = new ExternalEventApplication();    
            ExternalEvent exEvent = ExternalEvent.Create(handler);                //Создаем событие
            mainForm = new MainForm(appRevit, exEvent, handler);                 
            mainForm.Show();

        }
    }
}
