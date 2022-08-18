using System;
using System.Collections.Generic;
using VIEditor.Services;

namespace VIEditor.UI
{
    internal class HelpScreen
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        internal static void LoadWindow()
        {
            _log.Debug("HelpScreen launched");

            // setting up screen
            WindowDecorator.OnNewScreenLaunch(LabelManager.Label.Menus.Help);
            
            DisplayAbout();
            Console.WriteLine();

            DisplaySupportedFileExtensions();
            Console.WriteLine();

            DisplayCommands();
            Console.WriteLine("\n\n");

            // to go back to main menu
            DisplayMessage(LabelManager.Label.GoBackToMenu);
            Console.ReadKey();
            WindowDecorator.ClearWindow();

            HomeScreen.LoadWindow();
        }

        static void DisplayMessage(string message) => Console.WriteLine("\t" + message);

        static void DisplayAbout()
        {
            DisplayMessage(LabelManager.Label.About);
            DisplayMessage("------");
            DisplayMessage(LabelManager.AppInfo.About);
        }

        static void DisplaySupportedFileExtensions()
        {
            List<string> extensions = ConfigService.GetInstance.SupportedFileExtensions;

            DisplayMessage(LabelManager.Label.SupportedFileExtensions);
            DisplayMessage("-------------------------");
            DisplayMessage(string.Join("  ", extensions));
        }

        static void DisplayCommands()
        {
            List<string> eofCommands = ConfigService.GetInstance.EOFCommands;
            
            DisplayMessage(LabelManager.Label.CommandsToTerminate);
            DisplayMessage("----------------------------------");
            DisplayMessage(string.Join("  ", eofCommands));
        }
    }
}
