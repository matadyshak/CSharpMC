using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace HotelApp.Web.Pages
{
    public class BookRoomModel : PageModel
    {
        private readonly IDatabaseData _db;
        private string _firstName;
        private string _lastName;
        public BookRoomModel(IDatabaseData db)
        {
            _db = db;
        }

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);

        [BindProperty(SupportsGet = true)]
        public int RoomTypeId { get; set; }

        public RoomTypeModel RoomTypeModel { get; set; } = new RoomTypeModel();

        // These only bound during post (form submission)
        [BindProperty]
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                _firstName = ti.ToTitleCase(value?.ToLower() ?? string.Empty);
            }
        }


        [BindProperty]
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get => _lastName;
            set
            {
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                _lastName = ti.ToTitleCase(value?.ToLower() ?? string.Empty);
            }
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
