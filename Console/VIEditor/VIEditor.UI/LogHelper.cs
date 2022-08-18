using System.Runtime.CompilerServices;

namespace VIEditor.UI
{
    internal class LogHelper
    {
        /// <summary>
        /// Returns the logger instance of caller class
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Instance of log4net.ILog</returns>
        public static log4net.ILog GetLogger([CallerFilePath]string fileName = "")
        {
            return log4net.LogManager.GetLogger(fileName);
        }
    }
}
