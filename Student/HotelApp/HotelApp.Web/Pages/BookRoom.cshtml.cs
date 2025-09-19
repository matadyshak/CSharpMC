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

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        public RoomTypeModel RoomTypeModel { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Last name is required")]
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
            RoomTypeModel = _db.GetRoomTypeById(RoomTypeId);

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

            return RedirectToPage("/Index");
        }
    }
}
