using System.IO;

namespace Domain.FileConfigurations.Builders
{
    public static class FileCreationHelper
    {
        public static void ExistanceCheck(string path)
        {

            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
