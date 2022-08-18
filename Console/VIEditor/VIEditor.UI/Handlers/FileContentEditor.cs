using System;
using System.Collections.Generic;
using System.IO;
using VIEditor.Models;
using VIEditor.Services;

namespace VIEditor.UI.Handlers
{
    internal class FileContentEditor
    {
        private static readonly log4net.ILog _log = LogHelper.GetLogger();

        private static readonly FileService _fileService = FileService.GetInstance;
        private static readonly ConfigService _configService = ConfigService.GetInstance;

        internal static void EditFileContent(string fileName, string fileDirectory)
        {
            string fileLocation = fileDirectory + "/" + fileName;
            FileItem fileItem;

            try
            {
                fileItem = _fileService.GetFileItem(fileLocation);
            }
            catch (FileNotFoundException ex)
            {
                _log.Error("File not found at provided location", ex);
                throw new Exception(LabelManager.Error.FileNotFound);
            }

            _log.Debug("Enabled editing mode of file: " + fileLocation);

            Console.WriteLine(LabelManager.Label.PressKeyToStart);
            Console.ReadKey();

            WindowDecorator.ClearWindow();

            // get termination commands from config
            List<string> eofCommands = _configService.EOFCommands;

            int currentLine = 1;

            if (fileItem.Content.Length != 0)
            {
                // displaying the previous content
                fileItem.Content = fileItem.Content.Remove(fileItem.Content.Length - 1);
                string[] exisitingContent = fileItem.Content.Split("\n");

                foreach (string line in exisitingContent)
                {
                    WindowDecorator.AddColorText(currentLine++.ToString() + "\t", ConsoleColor.Red);
                    Console.WriteLine(line);
                }
            }


            string fileContent = "";
            while (true)
            {
                WindowDecorator.AddColorText(currentLine++.ToString() + "\t", ConsoleColor.Red);

                string inputLineContent = Utils.TakeStringInput("");

                // check if user enters any EOF command
                if (eofCommands.Contains(inputLineContent))
                    break;

                fileContent += inputLineContent + "\n";
            }

            // check if something added or not
            if (fileContent.Length != 0)
            {
                fileContent = fileContent.Remove(fileContent.Length - 1); // removes the last enter character
                fileItem.Content += fileContent;

                try
                {
                    // updating the edited content in physical file
                    _fileService.UpdateFileItem(fileItem);
                }
                catch
                {
                    throw new Exception(LabelManager.Error.FileUpdateFailure);
                }
            }
        }
    }
}
