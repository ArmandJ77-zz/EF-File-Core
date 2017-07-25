using Database.Clients;

namespace Database.Contacts
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public bool IsValid { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
