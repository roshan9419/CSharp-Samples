
using System.Text.Json.Serialization;

namespace VIEditor.UI.Models
{
    public class AppInfo
    {
        [JsonPropertyName("appName")]
        public string AppName;

        [JsonPropertyName("version")]
        public string Version;

        [JsonPropertyName("about")]
        public string About;
    }
}
