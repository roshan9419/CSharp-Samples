using VIEditor.Services;

namespace VIEditor.Validators
{
    public static class FileValidator
    {
        public static bool IsFileSupported(string fileName)
        {
            int index = fileName.IndexOf(".");
            string providedExtension = fileName.Substring(index + 1).ToLower();

            if (!ConfigService.GetInstance.SupportedFileExtensions.Contains(providedExtension))
                return false;
            
            return true;
        }
    }
}
