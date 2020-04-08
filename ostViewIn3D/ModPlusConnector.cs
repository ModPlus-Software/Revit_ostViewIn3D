#pragma warning disable SA1600 // Elements should be documented
namespace ostViewIn3D
{
    using System;
    using System.Collections.Generic;
    using ModPlusAPI.Interfaces;

    public class ModPlusConnector : IModPlusFunctionInterface
    {
        public SupportedProduct SupportedProduct => SupportedProduct.Revit;

        public string Name => "ostViewIn3D";

#if R2015
        public string AvailProductExternalVersion => "2015";
#elif R2016
        public string AvailProductExternalVersion => "2016";
#elif R2017
        public string AvailProductExternalVersion => "2017";
#elif R2018
        public string AvailProductExternalVersion => "2018";
#elif R2019
        public string AvailProductExternalVersion => "2019";
#elif R2020
        public string AvailProductExternalVersion => "2020";
#elif R2021
        public string AvailProductExternalVersion => "2021";
#endif

        public string FullClassName => "ostViewIn3D.ExternalCommands";

        public string AppFullClassName => string.Empty;

        public Guid AddInId => Guid.Empty;

        public string LName => "3D подрезка";

        public string Description => "Подрезает в видовой куб выбранные элементы с возможностью задания размера видового куба";

        public string Author => "Останин Антон";

        public string Price => "0";

        public bool CanAddToRibbon => true;

        public string FullDescription => "Имеется возможность динамического изменения размеров видового куба равномерно во все стороны относительно выбранных элементов";

        public string ToolTipHelpImage => "ostViewIn3D.png";

        public List<string> SubFunctionsNames => new List<string>();

        public List<string> SubFunctionsLames => new List<string>();

        public List<string> SubDescriptions => new List<string>();

        public List<string> SubFullDescriptions => new List<string>();

        public List<string> SubHelpImages => new List<string>();

        public List<string> SubClassNames => new List<string>();
    }
}
#pragma warning restore SA1600 // Elements should be documented