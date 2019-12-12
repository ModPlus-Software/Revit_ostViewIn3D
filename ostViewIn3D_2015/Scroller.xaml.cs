﻿namespace ostViewIn3D
{
    using System.Windows;
    using Autodesk.Revit.UI;

    public partial class Scroller
    {
        private const string LangItem = "ostViewIn3D";
        private readonly ExternalEvent m_ExEvent;
        private readonly UIApplication appRevit;

        public Scroller(UIApplication appRevit, ExternalEvent exEvent)
        {
            InitializeComponent();
            Title = ModPlusAPI.Language.GetItem(LangItem, "h1");
            m_ExEvent = exEvent;
            this.appRevit = appRevit;
        }
        
        public bool IsSectionView { get; set; } = true;

        public int Offset { get; set; } = 0;
        
        private void TbSection_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (appRevit.ActiveUIDocument == null)
                return;
            if (appRevit.ActiveUIDocument.Selection.GetElementIds().Count == 0)
                return;
            IsSectionView = false;
            Offset = (int)tbSection.Value;
            m_ExEvent.Raise();  // сигнал для обработки события
        }

        private void Scroller_OnLoaded(object sender, RoutedEventArgs e)
        {
            tbSection.ValueChanged += TbSection_OnValueChanged;
        }
    }
}
