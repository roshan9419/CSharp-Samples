
using System.Text.Json.Serialization;

namespace VIEditor.UI.Models
{
    public class Label
    {
        [JsonPropertyName("welcomeMessage")]
        public string WelcomeMessage;

        [JsonPropertyName("about")]
        public string About;

        [JsonPropertyName("menus")]
        public Menus Menus;

        [JsonPropertyName("createFile")]
        public string CreateFile;
        
        [JsonPropertyName("openFile")]
        public string OpenFile;
        
        [JsonPropertyName("askFileDirectory")]
        public string AskFileDirectory;
        
        [JsonPropertyName("askFileName")]
        public string AskFileName;
        
        [JsonPropertyName("fileUpdated")]
        public string FileUpdated;
        
        [JsonPropertyName("goBackToMenu")]
        public string GoBackToMenu;
        
        [JsonPropertyName("pressKeyToStart")]
        public string PressKeyToStart;

        [JsonPropertyName("pressKeyToRetry")]
        public string PressKeyToRetry;

        [JsonPropertyName("yourChoice")]
        public string YourChoice;

        [JsonPropertyName("fileOverride")]
        public string FileOverride;

        [JsonPropertyName("supportedFileExtensions")]
        public string SupportedFileExtensions;

        [JsonPropertyName("commandsToTerminate")]
        public string CommandsToTerminate;
    }

    public class Menus
    {
        [JsonPropertyName("newFile")]
        public string NewFile;
        
        [JsonPropertyName("openFile")]
        public string OpenFile;
        
        [JsonPropertyName("recentFile")]
        public string RecentFile;
        
        [JsonPropertyName("changeTheme")]
        public string ChangeTheme;
        
        [JsonPropertyName("help")]
        public string Help;
        
        [JsonPropertyName("exit")]
        public string Exit;
    }
}
