
namespace VIEditor.UI.Handlers
{
    internal class OpenFileHandler : NewFileHandler
    {
        internal new void Start()
        {
            // setting up screen
            WindowDecorator.OnNewScreenLaunch(LabelManager.Label.OpenFile);

            // asking the directory path where file is stored and the file name
            AskFileDirectory();
            AskFileName();

            // opening the file in editing mode
            StartEditingMode();
        }
    }
}
