using System.Windows;
using System.Windows.Input;
using Autodesk.Revit.UI;
using ModPlusAPI.Windows.Helpers;

namespace ostViewIn3D
{
    public partial class Scroller
    {
        private readonly ExternalEvent m_ExEvent;
        public bool isSectionView  = true;
        public int offset = 0;
        private readonly UIApplication appRevit;

        public Scroller(UIApplication appRevit, ExternalEvent exEvent)
        {
            InitializeComponent();
            this.OnWindowStartUp();
            m_ExEvent = exEvent;
            this.appRevit = appRevit;
        }

        private void TbSection_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (appRevit.ActiveUIDocument == null) return;
            if (appRevit.ActiveUIDocument.Selection.GetElementIds().Count == 0)
                return;
            isSectionView = false;
            offset = (int)tbSection.Value;
            m_ExEvent.Raise();  //сигнал для обработки события
        }

        private void Scroller_OnLoaded(object sender, RoutedEventArgs e)
        {
            tbSection.ValueChanged += TbSection_OnValueChanged;
        }

        private void Scroller_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
