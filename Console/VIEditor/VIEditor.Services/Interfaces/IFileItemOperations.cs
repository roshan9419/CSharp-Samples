using VIEditor.Models;

namespace VIEditor.Services.Interfaces
{
    internal interface IFileItemOperations
    {
        public void CreateFileItem(FileItem fileItem);
        public void UpdateFileItem(FileItem fileItem);
        public FileItem GetFileItem(string fileLocation);
    }
}
