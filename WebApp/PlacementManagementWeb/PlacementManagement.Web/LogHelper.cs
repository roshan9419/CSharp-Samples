using System.Runtime.CompilerServices;

namespace PlacementManagement.Web
{
    internal class LogHelper
    {
        /// <summary>
        /// Returns the logger instance of caller class
        /// </summary>
        /// <returns>Instance of log4net.ILog</returns>
        public static log4net.ILog GetLogger([CallerFilePath] string fileName = "")
        {
            return log4net.LogManager.GetLogger(fileName);
        }
    }
}