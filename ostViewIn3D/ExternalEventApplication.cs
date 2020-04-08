namespace ostViewIn3D
{
    using Autodesk.Revit.UI;

    public class ExternalEventApplication : IExternalEventHandler
    {
        /// <inheritdoc/>
        public void Execute(UIApplication app)
        {
            SectionBox sectionBox = new SectionBox();
            sectionBox.SetSectionBox(app, ExternalCommands.ScrollerWin.Offset);
        }

        /// <inheritdoc/>
        public string GetName()
        {
            return string.Empty;
        }
    }
}
