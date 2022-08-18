using System;
using VIEditor.UI.Enums;

namespace VIEditor.UI
{
    internal class WindowDecorator
    {
        /// <summary>
        /// Sets the console title
        /// </summary>
        internal static void SetTitle(string title)
        {
            Console.Title = title;
        }

        /// <summary>
        /// Clears the entire console data
        /// </summary>
        internal static void ClearWindow()
        {
            Console.Clear();
        }

        /// <summary>
        /// Add header text in center of window
        /// </summary>
        internal static void SetHeader(string headerText)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 1);
            Console.WriteLine(headerText);
        }

        internal static void OnNewScreenLaunch(string headerText)
        {
            // clearing the previous screen
            ClearWindow();

            // applying borders to window sides
            ApplyWindowBorders();

            // showing header
            SetHeader(headerText + "\n");
        }

        /// <summary>
        /// It set's the borders on horizontal sides with specified symbol
        /// </summary>
        internal static void AddHorizontalBorder(int xPos, int yPos, char symbol = '*')
        {
            Console.SetCursorPosition(xPos, yPos);
            for (int i = 0; i < Console.WindowWidth; i++)
                Console.Write(symbol);
        }

        /// <summary>
        /// It set's the borders on vertical sides with specified symbol
        /// </summary>
        internal static void AddVerticalBorder(int xPos, int yPos, char symbol = '*')
        {
            Console.SetCursorPosition(xPos, yPos);
            for (int i = 0; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                Console.Write(symbol);
            }
        }

        /// <summary>
        /// It sets the border on all 4 sides of console window
        /// </summary>
        internal static void ApplyWindowBorders()
        {
            // horizontal top border
            AddHorizontalBorder(0, 0);

            // horizontal bottom border
            AddHorizontalBorder(0, Console.WindowHeight - 1);

            // vertical left border
            AddVerticalBorder(0, 0);

            // vertical right border
            AddVerticalBorder(Console.WindowWidth - 1, 0);
        }

        internal static void ChangeTheme(AppTheme appTheme)
        {
            if (appTheme == AppTheme.Dark)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }

        internal static void AddColorText(string displayText, ConsoleColor color)
        {
            bool isDarkTheme = Console.BackgroundColor == ConsoleColor.Black;
            
            Console.ForegroundColor = color;
            Console.Write(displayText);
            Console.ForegroundColor = isDarkTheme ? ConsoleColor.White : ConsoleColor.Black;
        }
    }
}
