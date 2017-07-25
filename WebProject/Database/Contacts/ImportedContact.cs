using Database.Clients;

namespace Database.Contacts
{
    public class ImportedContact
    {
        public int ImportedContactId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Region { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
