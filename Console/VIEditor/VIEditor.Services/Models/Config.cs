using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VIEditor.Services.Models
{
    public class Config
    {
        [JsonPropertyName("eofCommands")]
        public List<string> EOFCommands;

        [JsonPropertyName("supportedFileExtensions")]
        public List<string> SupportedFileExtensions;

        [JsonPropertyName("defaultFileExtension")]
        public string DefaultFileExtension;
    }
}
