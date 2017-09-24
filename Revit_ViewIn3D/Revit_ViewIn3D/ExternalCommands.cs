using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yandex.Metrica;

namespace Revit_3DSectionBox
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class ExternalCommands : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            UIApplication appRevit = commandData.Application;
            if (MainForm.mf != null)
                return Result.Cancelled;
            try
            {
                string pathToTemp = Path.GetTempPath() + "3D_SectionBox";
                if (!Directory.Exists(pathToTemp))
                {
                    try { Directory.CreateDirectory(pathToTemp); }
                    catch { }
                }
                Yandex.Metrica.YandexMetricaFolder.SetCurrent(pathToTemp);
                YandexMetrica.Activate("40bbb879-2330-4c57-a374-5ad5044a7ce9");
                YandexMetrica.ReportEvent("Запуск", "{\"RevitVersion\":\"" + commandData.Application.Application.VersionNumber + "\"}");
            }
            catch
            {

            }
            if (appRevit.ActiveUIDocument.Selection.GetElementIds().Count == 0)
            {
                MessageBox.Show("You must select element!", "Attention!", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return Result.Cancelled;
            }
            SectionBox sectionBox = new SectionBox();
            sectionBox.SetSectionBox(appRevit,0);
            ExternalApplication extApplication = new ExternalApplication();
            extApplication.ShowMainForm(appRevit);
            return Result.Succeeded;
        }
    }
}
