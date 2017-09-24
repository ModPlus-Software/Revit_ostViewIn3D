using System;
using System.Collections.Generic;
using ModPlusAPI.Interfaces;

namespace ostViewIn3D
{
    public class Interface : IModPlusFunctionInterface
    {
        public SupportedProduct SupportedProduct => SupportedProduct.Revit;
        public string Name => "ostViewIn3D";
        public string AvailProductExternalVersion => "2016";
        public string FullClassName => "ostViewIn3D.ExternalCommands";
        public string AppFullClassName => string.Empty;
        public Guid AddInId => Guid.Empty;
        public string LName => "3D подрезка";
        public string Description => "Подрезает в видовой куб выбранные элементы с возможностью задания размера видового куба";
        public string Author => "Останин Антон";
        public string Price => "0";
        public bool CanAddToRibbon => true;
        public string FullDescription => "Имеется возможность динамического изменени размеров видового куба равномерно во все стороны относительно выбранных элементов";
        public string ToolTipHelpImage => "ostViewIn3D.png";
        public List<string> SubFunctionsNames => new List<string>();
        public List<string> SubFunctionsLames => new List<string>();
        public List<string> SubDescriptions => new List<string>();
        public List<string> SubFullDescriptions => new List<string>();
        public List<string> SubHelpImages => new List<string>();
        public List<string> SubClassNames => new List<string>();
    }
}
