using System.Collections.Generic;

namespace EFConsoleUI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Email> EmailAddresses { get; set; } = new List<Email>();
        public List<Phone> PhoneNumbers { get; set; } = new List<Phone>();
    }
}
