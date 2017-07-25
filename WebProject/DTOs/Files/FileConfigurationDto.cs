using Enums;

namespace DTOs.Files
{
    public class FileConfigurationDto
    {
        public int ClientId { get; set; }
        public int FileConfigurationId { get; set; }
        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public FileType FileType { get; set; }
    }
}
