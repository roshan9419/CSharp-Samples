using System;
using System.IO;
using VIEditor.FileManager.Interfaces;

namespace VIEditor.FileManager
{
    public class FileWriter : IFileWriteOperations
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        /// <summary>
        /// Creates a file in physical storage on specified path
        /// </summary>
        public void CreateFile(string fileLocation, string fileContent)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(fileLocation);
                string fileDirectory = fileInfo.Directory.Name;

                // create directory if not exists
                DirectoryHandler dirHandler = new DirectoryHandler(fileDirectory);

                if (!dirHandler.IsExists())
                {
                    bool isCreated = dirHandler.CreateDirectory();
                    _log.Debug("Directory created : " + fileDirectory);

                    if (!isCreated)
                        throw new Exception("Failed to create file directory");
                }

                using StreamWriter writer = new StreamWriter(File.Create(fileLocation));
                writer.Write(fileContent);

                _log.Debug("Successfully created file at path: " + fileLocation);
            }
            catch (Exception ex)
            {
                _log.Error("Failed to create file on disk", ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the exisiting file with updated content if file is present
        /// </summary>
        public void UpdateFile(string fileLocation, string fileContent)
        {
            try
            {
                // check if file exists or not before writing
                if (!FileUtils.IsFileExists(fileLocation))
                    throw new FileNotFoundException("File not found");

                using StreamWriter writer = new StreamWriter(File.OpenWrite(fileLocation));
                writer.Write(fileContent);

                _log.Debug("Successfully updated file, fileLocation: " + fileLocation);
            }
            catch (Exception ex)
            {
                _log.Error("Failed to update file on disk", ex);
                throw;
            }
        }
    }
}
