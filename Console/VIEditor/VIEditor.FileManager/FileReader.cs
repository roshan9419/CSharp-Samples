using System.IO;
using VIEditor.FileManager.Interfaces;
using VIEditor.Models;

namespace VIEditor.FileManager
{
    public class FileReader : IFileReadOperations
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        /// <summary>
        /// Fetches the physical disk file on specified location and convert's that to FileItem object.
        /// </summary>
        /// <returns>FileItem object</returns>
        public FileItem GetFile(string fileLocation)
        {
            _log.Debug("File requested: " + fileLocation);

            // check if file exists or not
            if (!FileUtils.IsFileExists(fileLocation))
            {
                throw new FileNotFoundException("No such file present at provided location");
            }

            FileInfo fileInfo = new FileInfo(fileLocation);

            using (StreamReader reader = new StreamReader(fileInfo.OpenRead()))
            {
                string content = "";
                string currentLine;
                while ((currentLine = reader.ReadLine()) != null)
                {
                    content += currentLine + "\n";
                }
                if (content.Length != 0)
                    content.Remove(content.Length - 1);
                
                return new FileItem(fileInfo.Name, fileInfo.Directory.FullName, content, fileInfo.LastWriteTime);
            }
        }
    }
}
