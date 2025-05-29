namespace DataAccessLibrary.Models
{
    // Only needed for deletes
    public class ContactPhoneNumberModel
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int PhoneNumberId { get; set; }
    }
}
