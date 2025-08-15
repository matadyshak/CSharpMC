namespace HotelAppLibrary.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public bool CheckedIn { get; set; }

        // Navigation properties
        public GuestModel Guest { get; set; } = new GuestModel();
        public RoomModel Room { get; set; } = new RoomModel();
    }
}