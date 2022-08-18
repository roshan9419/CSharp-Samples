using System;

namespace VIEditor.UI
{
    internal class VIEditor
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        static void Main(string[] args)
        {
            try
            {
                // loading the labels
                LabelManager.LoadLabels();
            }
            catch (Exception ex)
            {
                Utils.DisplayError("Failed to load configuations");
                _log.Error("Failed to load configuration", ex);
                return;
            }

            _log.Debug("App started running...");

            // setting up app title
            WindowDecorator.SetTitle(LabelManager.AppInfo.AppName);

            // launching the home screen
            HomeScreen.LoadWindow();

            // waiting for the program to finish
            Console.ReadLine();
        }
    }
}
