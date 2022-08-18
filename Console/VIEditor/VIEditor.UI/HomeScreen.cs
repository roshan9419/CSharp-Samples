using System;
using VIEditor.UI.Enums;
using VIEditor.UI.Handlers;
using VIEditor.UI.Models;

namespace VIEditor.UI
{
    internal class HomeScreen
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        internal static void LoadWindow()
        {
            _log.Debug("HomeScreen launched");
            // setting up screen
            WindowDecorator.OnNewScreenLaunch(LabelManager.Label.WelcomeMessage);

            DisplayMenu();
            AskForChoice();
        }

        static void DisplayMenu()
        {
            // showing available menus
            MenuSystem menuSystem = new MenuSystem();
            MenuItem[] menuItems = menuSystem.GetMenus();

            int itemPos = 5;
            for (int itemIdx = 0; itemIdx < menuItems.Length; itemIdx++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 20, itemPos++);
                Console.WriteLine($"{itemIdx + 1} - {menuItems[itemIdx].Name}");
            }
        }

        static void AskForChoice()
        {
            int totalMenuItems = new MenuSystem().GetMenus().Length;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, totalMenuItems + 10);

            int choice;
            try
            {
                choice = Utils.TakeNumberInput(LabelManager.Label.YourChoice);
            }
            catch (FormatException fe)
            {
                InvalidInput(fe.Message + ", " + LabelManager.Label.PressKeyToRetry, totalMenuItems);
                return;
            }

            switch (choice)
            {
                case (int)MenuType.NewFile:
                    new NewFileHandler().Start();
                    break;

                case (int)MenuType.OpenFile:
                    new OpenFileHandler().Start();
                    break;

                case (int)MenuType.ChangeTheme:
                    ChangeThemeAction();
                    break;

                case (int)MenuType.Help:
                    HelpAction();
                    break;

                case (int)MenuType.Exit:
                    ExitAction();
                    break;

                default:
                    InvalidInput(LabelManager.Error.InvalidChoice + ", " + LabelManager.Label.PressKeyToRetry, totalMenuItems);
                    break;
            }
        }

        static void ChangeThemeAction()
        {
            // if dark theme is selected then making it light and vice-versa
            bool isDarkTheme = Console.BackgroundColor == ConsoleColor.Black;
            WindowDecorator.ChangeTheme(isDarkTheme ? AppTheme.Light : AppTheme.Dark);
            LoadWindow();
        }

        static void HelpAction()
        {
            // launching help screen
            HelpScreen.LoadWindow();
        }

        static void ExitAction()
        {
            _log.Debug("App stopped...");
            Environment.Exit(0);
        }

        static void InvalidInput(string message, int totalMenuItems)
        {
            _log.Debug("User provided invalid input");

            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, totalMenuItems + 11);
            Utils.DisplayError(message);
            Console.ReadKey();
            LoadWindow();
        }
    }
}
