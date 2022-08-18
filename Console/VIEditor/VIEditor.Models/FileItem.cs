using System;

namespace VIEditor.Models
{
    public class FileItem : RecentFile
    {
        public FileItem(string fileName, string fileDirectory, string content, DateTime lastUpdated) :
            base(fileName, fileDirectory, lastUpdated)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}
