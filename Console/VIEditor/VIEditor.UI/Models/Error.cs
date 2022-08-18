
using System.Text.Json.Serialization;

namespace VIEditor.UI.Models
{
    public class Error
    {
        [JsonPropertyName("invalidNumber")]
        public string InvalidNumber;

        [JsonPropertyName("invalidChoice")]
        public string InvalidChoice;
        
        [JsonPropertyName("fileNotFound")]
        public string FileNotFound;

        [JsonPropertyName("fileAlreadyExists")]
        public string FileAlreadyExists;

        [JsonPropertyName("invalidDirectoryPath")]
        public string InvalidDirectoryPath;

        [JsonPropertyName("fileNotSupported")]
        public string FileNotSupported;

        [JsonPropertyName("fileCreateFailure")]
        public string FileCreateFailure;
        
        [JsonPropertyName("fileUpdateFailure")]
        public string FileUpdateFailure;
    }
}
