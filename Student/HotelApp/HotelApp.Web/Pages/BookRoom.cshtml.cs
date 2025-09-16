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
        public int RoomTypeId { get; set; }

        public RoomTypeModel RoomType { get; set; } = new RoomTypeModel();

        // These only bound during post (form submission)
        [BindProperty]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        public int ReservationNumber { get; set; } = 0;
        public void OnGet()
        {
            RoomType = _db.GetRoomTypeById(RoomTypeId);
        }

        public IActionResult OnPost()
        {
            RoomType = _db.GetRoomTypeById(RoomTypeId);

            // Validate form data before booking
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                ModelState.AddModelError(string.Empty, "First name and last name are required.");
                return Page();
            }

            _db.BookGuest(FirstName,
                            LastName,
                            StartDate,
                            EndDate,
                            RoomTypeId);

            return Page(); // Or redirect to a confirmation page
        }
    }
}
