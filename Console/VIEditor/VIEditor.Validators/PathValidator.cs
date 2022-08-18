using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIEditor.Validators
{
    public static class PathValidator
    {
        public static bool IsValidDirectoryPath(string directoryPath)
        {
            bool isValid;

            try
            {
                string root = Path.GetPathRoot(directoryPath);
                isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
            }
            catch
            {
                // raises exception if path is wrong
                isValid = false;
            }

            return isValid;
        }
    }
}
