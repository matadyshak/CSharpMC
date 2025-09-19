using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Web.Pages
{
    public class BookRoomModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }
        public RoomTypeModel RoomTypeModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]
        public string LastName { get; set; }

        public BookRoomModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            RoomTypeModel = _db.GetRoomTypeById(RoomTypeId);
            if (RoomTypeModel == null)
            {
                RoomTypeModel = new RoomTypeModel
                {
                    Title = "Unknown room",
                    Description = "Room details are not available."
                };
            }
        }

        public IActionResult OnPost()
        {
            _db.BookGuest(FirstName, LastName, StartDate, EndDate, RoomTypeId);
            return RedirectToPage("/Index");
        }
    }
}
