using System;
using System.IO;
using VIEditor.FileManager;
using VIEditor.Models;
using VIEditor.Services.Interfaces;

namespace VIEditor.Services
{
    /// <summary>
    /// This service contains file related opertaions on FileItem type
    /// </summary>
    public sealed class FileService : IFileItemOperations
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        private FileService() 
        {
            _log.Info("FileService initialized");
        }

        private static readonly Lazy<FileService> _instance = new(() => new FileService());

        public static FileService GetInstance
        {
            get { return _instance.Value; }
        }

        /// <summary>
        /// It creates or overrite an existing file
        /// </summary>
        /// <exception cref="Exception">If path does not exists in system</exception>
        public void CreateFileItem(FileItem fileItem)
        {
            _log.Debug(fileItem);
            
            FileWriter fileWriter = new FileWriter();
            fileWriter.CreateFile(fileItem.FullFilePath, fileItem.Content);
        }

        /// <summary>
        /// Updates an existing file if present else exception is thrown
        /// </summary>
        public void UpdateFileItem(FileItem fileItem)
        {
            _log.Debug(fileItem);

            FileWriter fileWriter = new FileWriter();
            fileWriter.UpdateFile(fileItem.FullFilePath, fileItem.Content);
        }

        /// <summary>
        /// Get's the file present at specified path if present
        /// </summary>
        /// <returns>The FileItem object/returns>
        public FileItem GetFileItem(string fileLocation)
        {
            try
            {
                FileReader fileReader = new FileReader();
                return fileReader.GetFile(fileLocation);
            }
            catch (FileNotFoundException fe)
            {
                _log.Error("File not found, fileLocation: " + fileLocation, fe);
                throw;
            }
        }
    }
}
