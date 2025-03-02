namespace DemoGuestLibrary.Models
{
    public class GuestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string MessageForStaff { get; set; }
        public string GuestInfo
        {
            get
            {
                return $"{FirstName} {LastName} {City} {State} : {MessageForStaff}";
            }
        }
    }
}
