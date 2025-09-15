using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Web.Pages
{
    public class BookRoomModel : PageModel
    {
        private readonly IDatabaseData _db;

        public BookRoomModel(IDatabaseData db)
        {
            _db = db;
        }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }  // Get from URL

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } // Get from URL

        [BindProperty(SupportsGet = true)]
        public bool SearchEnabled { get; set; } = false;

        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LastName { get; set; }

        public RoomTypeModel RoomType { get; set; } = new RoomTypeModel();

        public int ReservationNumber { get; set; } = 0;
        public void OnGet()
        {
            if (SearchEnabled == true)
            {
                _db.BookGuest(FirstName,
                              LastName,
                              StartDate,
                              EndDate,
                              RoomType.Id);
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new { SearchEnabled = true, StartDate, EndDate, RoomType.Id });
        }
    }
}
