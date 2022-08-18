using System.IO;
using VIEditor.Converters;
using VIEditor.FileManager;
using VIEditor.UI.Models;

namespace VIEditor.UI
{
    /// <summary>
    /// This manager contains all the label related thing which to be shown in console
    /// </summary>
    internal static class LabelManager
    {
        internal static AppInfo AppInfo;
        internal static Label Label;
        internal static Error Error;

        /// <summary>
        /// This method should be called on app launch, so all the labels are loaded before use
        /// </summary>
        internal static void LoadLabels()
        {
            // specific files
            string appInfoFile = Path.Combine(FileUtils.CurrentDirectory(), @"Resources\appInfo.json");
            string labelFile = Path.Combine(FileUtils.CurrentDirectory(), @"Resources\labels.json");
            string errorFile = Path.Combine(FileUtils.CurrentDirectory(), @"Resources\errors.json");

            // converting the json to respective object
            AppInfo = JsonParser<AppInfo>.JsonToObject(appInfoFile);
            Label = JsonParser<Label>.JsonToObject(labelFile);
            Error = JsonParser<Error>.JsonToObject(errorFile);
        }
    }
}
