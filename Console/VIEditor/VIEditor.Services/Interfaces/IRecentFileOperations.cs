using System.Collections.Generic;
using VIEditor.Models;

namespace VIEditor.Services.Interfaces
{
    internal interface IRecentFileOperations
    {
        public void AddRecentFile(RecentFile recentFile);
        public void UpdateRecentFile(RecentFile recentFile);
        public List<RecentFile> GetRecentFiles();
        public List<RecentFile> GetRecentFiles(int count);
    }
}
