using System;

namespace VIEditor.UI
{
    internal static class Utils
    {
        /// <summary>
        /// Takes the input from user and converts that to integer
        /// </summary>
        /// <returns>The integer which user typed</returns>
        /// <exception cref="FormatException">If the input in not a number</exception>
        internal static int TakeNumberInput(string displayText)
        {
            try
            {
                Console.Write(displayText);
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new FormatException(LabelManager.Error.InvalidNumber);
            }
        }

        /// <summary>
        /// Takes the input from user in the form of string
        /// </summary>
        /// <returns>The string which user typed</returns>
        internal static string TakeStringInput(string displayText)
        {
            Console.Write(displayText);
            return Console.ReadLine();
        }

        /// <summary>
        /// Displays the error message on console in Red color
        /// </summary>
        internal static void DisplayError(string errorMessage)
        {
            WindowDecorator.AddColorText(errorMessage + "\n", ConsoleColor.Red);
        }
    }
}
