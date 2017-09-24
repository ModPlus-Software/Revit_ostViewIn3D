using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yandex.Metrica;

namespace Revit_3DSectionBox
{
  
    public partial class MainForm : Form
    {
        public static MainForm mf ;
        private ExternalEventApplication m_Handler;
        private ExternalEvent m_ExEvent;
        public static bool isSectionView = true;
        public static int offset = 0;
        public UIApplication appRevit;
        public MainForm(UIApplication appRevit, ExternalEvent exEvent, ExternalEventApplication handler)
        {
            InitializeComponent();
            this.m_ExEvent = exEvent;
            this.m_Handler = handler;
            this.appRevit = appRevit;
            mf = this; 
        }

        public MainForm()
        {
            InitializeComponent();
            mf = this; 

        }



        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mf = null;
        }

        private void tbSection_Scroll(object sender, EventArgs e)
        {
            if (appRevit.ActiveUIDocument == null) return;
            if (appRevit.ActiveUIDocument.Selection.GetElementIds().Count == 0)
                return;
           // YandexMetrica.ReportEvent("Скроллинг Вася");
            isSectionView = false;
            offset = tbSection.Value;
            m_ExEvent.Raise();  //сигнал для обработки события
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://apps.autodesk.com/ru/Publisher/PublisherHomepage?ID=6VKGQDXQNY3U");
            YandexMetrica.ReportEvent("Об авторе");
        }

        private void linkLabelFedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://apps.autodesk.com/ru/Publisher/PublisherHomepage?ID=CZHJQREKZJ9H");
            YandexMetrica.ReportEvent("О ФЕдоре");
        }
    }
}
