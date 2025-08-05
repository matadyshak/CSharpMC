namespace HotelAppLibrary.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public bool CheckedIn { get; set; }

        // Navigation properties
        public Guests Guest { get; set; } = new Guests();
        public Rooms Room { get; set; } = new Rooms();
    }
}
