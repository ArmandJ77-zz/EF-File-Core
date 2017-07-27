using System.IO;

namespace Domain.FileConfigurations.Builders
{
    public static class FileCreationHelper
    {
        public static void ExistanceCheckCreate(string path)
        {

            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            
            if (File.Exists(path))
                File.Delete(path);
        }

        //Should create custom exceptions and raise them here
        public static bool ExistanceCheck(string path)
        {

            if (!Directory.Exists(Path.GetDirectoryName(path)))
                return false;

            return true;
        }
    }
}
