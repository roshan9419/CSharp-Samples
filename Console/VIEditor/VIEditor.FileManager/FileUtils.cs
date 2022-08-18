using System.IO;

namespace VIEditor.FileManager
{
    public static class FileUtils
    {
        /// <summary>
        /// Tells weather file exist on the specified path or not
        /// </summary>
        public static bool IsFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Tells the current directory where project is running
        /// </summary>
        /// <returns>The full absolute path</returns>
        public static string CurrentDirectory()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        }
    }
}
