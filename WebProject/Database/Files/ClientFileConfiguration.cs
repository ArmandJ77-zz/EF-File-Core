using Database.Clients;

namespace Database.Files
{
    public class ClientFileConfiguration
    {
        public int ClientFileConfigurationId { get; set; }
        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public int FileType { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
