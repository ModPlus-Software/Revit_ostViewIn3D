namespace ostViewIn3D
{
    using System.Windows;
    using Autodesk.Revit.UI;

    public partial class Scroller
    {
        private readonly ExternalEvent _externalEvent;
        private readonly UIApplication appRevit;

        public Scroller(UIApplication appRevit, ExternalEvent exEvent)
        {
            InitializeComponent();
            Title = ModPlusAPI.Language.GetItem("h1");
            _externalEvent = exEvent;
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
            _externalEvent.Raise();  // сигнал для обработки события
        }

        private void Scroller_OnLoaded(object sender, RoutedEventArgs e)
        {
            tbSection.ValueChanged += TbSection_OnValueChanged;
        }
    }
}
