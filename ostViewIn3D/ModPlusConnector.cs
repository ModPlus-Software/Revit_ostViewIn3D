namespace ostViewIn3D
{
    using System;
    using System.Collections.Generic;
    using ModPlusAPI.Abstractions;
    using ModPlusAPI.Enums;

    /// <inheritdoc/>
    public class ModPlusConnector : IModPlusPlugin
    {
        /// <inheritdoc/>
        public SupportedProduct SupportedProduct => SupportedProduct.Revit;

        /// <inheritdoc/>
        public string Name => "ostViewIn3D";

#if R2015
        /// <inheritdoc/>
        public string AvailProductExternalVersion => "2015";
#elif R2016
        /// <inheritdoc/>
        public string AvailProductExternalVersion => "2016";
#elif R2017
        /// <inheritdoc/>
        public string AvailProductExternalVersion => "2017";
#elif R2018
        /// <inheritdoc/>
        public string AvailProductExternalVersion => "2018";
#elif R2019
        /// <inheritdoc/>
        public string AvailProductExternalVersion => "2019";
#elif R2020
        /// <inheritdoc/>
        public string AvailProductExternalVersion => "2020";
#elif R2021
        /// <inheritdoc/>
        public string AvailProductExternalVersion => "2021";
#endif

        /// <inheritdoc/>
        public string FullClassName => "ostViewIn3D.ExternalCommands";

        /// <inheritdoc/>
        public string AppFullClassName => string.Empty;

        /// <inheritdoc/>
        public Guid AddInId => Guid.Empty;

        /// <inheritdoc/>
        public string LName => "3D подрезка";

        /// <inheritdoc/>
        public string Description => "Подрезает в видовой куб выбранные элементы с возможностью задания размера видового куба";

        /// <inheritdoc/>
        public string Author => "Останин Антон";

        /// <inheritdoc/>
        public string Price => "0";

        /// <inheritdoc/>
        public bool CanAddToRibbon => true;

        /// <inheritdoc/>
        public string FullDescription => "Имеется возможность динамического изменения размеров видового куба равномерно во все стороны относительно выбранных элементов";

        /// <inheritdoc/>
        public string ToolTipHelpImage => "ostViewIn3D.png";

        /// <inheritdoc/>
        public List<string> SubPluginsNames => new List<string>();

        /// <inheritdoc/>
        public List<string> SubPluginsLNames => new List<string>();

        /// <inheritdoc/>
        public List<string> SubDescriptions => new List<string>();

        /// <inheritdoc/>
        public List<string> SubFullDescriptions => new List<string>();

        /// <inheritdoc/>
        public List<string> SubHelpImages => new List<string>();

        /// <inheritdoc/>
        public List<string> SubClassNames => new List<string>();
    }
}