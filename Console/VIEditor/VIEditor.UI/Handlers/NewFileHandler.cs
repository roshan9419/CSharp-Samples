using System;
using System.Collections.Generic;
using VIEditor.FileManager;
using VIEditor.Models;
using VIEditor.Services;
using VIEditor.Validators;

namespace VIEditor.UI.Handlers
{
    internal class NewFileHandler
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        private static readonly FileService _fileService = FileService.GetInstance;
        private static readonly ConfigService _configService = ConfigService.GetInstance;

        private string _fileName;
        private string _fileDirectory;

        internal void Start()
        {
            // setting up screen
            WindowDecorator.OnNewScreenLaunch(LabelManager.Label.CreateFile);

            // asking the directory path where file has to be stored and the file name
            AskFileDirectory();
            AskFileName(checkExistingFile: true);

            // creating new file at that path
            OnNewFileCreation();

            // enabling writing into the file
            StartEditingMode();
        }

        protected void AskFileDirectory()
        {
            while (true)
            {
                // asking the location where user wants to store the file
                _fileDirectory = Utils.TakeStringInput(LabelManager.Label.AskFileDirectory).Trim();

                if (_fileDirectory.Length != 0)
                {
                    if (!PathValidator.IsValidDirectoryPath(_fileDirectory))
                        Utils.DisplayError(LabelManager.Error.InvalidDirectoryPath);
                    else
                        break;
                }
            }
        }

        protected void AskFileName(bool checkExistingFile = false)
        {
            while (true)
            {
                // asking the file name
                _fileName = Utils.TakeStringInput(LabelManager.Label.AskFileName).Trim();

                if (_fileName.Length == 0) continue;

                // add default extension if not provided
                if (_fileName.IndexOf(".") == -1)
                    _fileName += "." + _configService.DefaultFileExtension;

                // check if file supported or not
                if (!FileValidator.IsFileSupported(_fileName))
                {
                    Utils.DisplayError(LabelManager.Error.FileNotSupported);
                    _log.Info("File not supported, fileName: " + _fileName);
                    continue;
                }

                if (!checkExistingFile) break;

                // check if file already exists or not
                string filePath = _fileDirectory + "/" + _fileName;

                if (FileUtils.IsFileExists(filePath))
                {
                    Utils.DisplayError(LabelManager.Error.FileAlreadyExists);
                    string response = Utils.TakeStringInput(LabelManager.Label.FileOverride).ToLower();

                    if (response.Equals("y")) break;
                }
                else break;
            }
        }

        protected void StartEditingMode()
        {
            try
            {
                // start editing file
                FileContentEditor.EditFileContent(_fileName, _fileDirectory);

                // after successful writing
                OnFinishWriting();
            }
            catch (Exception e)
            {
                Utils.DisplayError(e.Message);
                OnFinishWriting(false);
            }
        }

        private void OnNewFileCreation()
        {
            FileItem fileItem = new FileItem(_fileName, _fileDirectory, "", DateTime.Now);

            _log.Debug(fileItem);

            try
            {
                _log.Debug("Creating new file");
                // creating a new file
                _fileService.CreateFileItem(fileItem);
            }
            catch (Exception e)
            {
                Utils.DisplayError(e.Message);

                // asking again the correct details
                AskFileDirectory();
                AskFileName(checkExistingFile: true);
            }

        }

        private void OnFinishWriting(bool isSuccess = true)
        {
            if (isSuccess)
                Console.WriteLine("\n\n" + LabelManager.Label.FileUpdated);
            
            Console.WriteLine(LabelManager.Label.GoBackToMenu);
            Console.ReadKey();

            HomeScreen.LoadWindow();
        }
    }
}
