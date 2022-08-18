using System;

namespace VIEditor.Models
{
    public class RecentFile
    {
        public RecentFile(string fileName, string fileDirectory, DateTime lastUpdated)
        {
            FileName = fileName;
            FileDirectory = fileDirectory;
            LastUpdated = lastUpdated;
        }

        public string FileName { get; }
        public string FileDirectory { get; }
        public DateTime LastUpdated { get; set; }

        public string FullFilePath => FileDirectory + "/" + FileName;
    }
}
