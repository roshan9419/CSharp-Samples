using System.IO;

namespace VIEditor.FileManager
{
    public class DirectoryHandler
    {
        readonly string _directoryPath;

        public DirectoryHandler(string directoryPath)
        {
            _directoryPath = directoryPath;
        }

        /// <summary>
        /// Checks weather directory exists or not in physical storage
        /// </summary>
        public bool IsExists()
        {
            return Directory.Exists(_directoryPath);
        }

        /// <summary>
        /// Creates the directory on the specified path
        /// </summary>
        /// <returns>Boolean value weather it is successfully created or not</returns>
        public bool CreateDirectory()
        {
            try
            {
                Directory.CreateDirectory(_directoryPath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
