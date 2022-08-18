using VIEditor.Models;

namespace VIEditor.FileManager.Interfaces
{
    /// <summary>
    /// Contains method signatures for all the read operations on file
    /// </summary>
    internal interface IFileReadOperations
    {
        public FileItem GetFile(string fileLocation);
    }
}
