using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs.Contacts
{
    public class ImportedContactsDto
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string gender { get; set; }
        public string region { get; set; }
        public int age { get; set; }
        public string title { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string photo { get; set; }
    }
}
