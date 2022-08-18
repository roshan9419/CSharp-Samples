namespace VIEditor.FileManager.Interfaces
{
    /// <summary>
    /// Contains method signatures of all the write operations on file
    /// </summary>
    internal interface IFileWriteOperations
    {
        public void CreateFile(string fileLocation, string fileContent);
        public void UpdateFile(string fileLocation, string fileContent);
    }
}
