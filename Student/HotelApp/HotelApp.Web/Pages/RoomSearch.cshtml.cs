using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Web.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly IDatabaseData _db;

        public RoomSearchModel(IDatabaseData db)
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
        public bool SearchEnabled { get; set; } = false;

        public List<RoomTypeModel> AvailableRoomTypes { get; set; } = new();

        // Why SearchEnabled Exists in This Pattern
        // 1. Razor Pages Use PRG(Post-Redirect-Get)
        // When the form is submitted, OnPost() doesn’t directly render the results.
        // Instead, it redirects to OnGet() with query parameters(StartDate, EndDate,
        // and SearchEnabled = true). This avoids duplicate form submissions and enables
        // clean URLs.

        // OnPost() → Redirects to OnGet() with query params
        // OnGet() → Executes the actual search logic

        // Without SearchEnabled, OnGet() would run every time the page loads —
        // even before the user submits the form.That’s why the flag is needed:
        // it tells OnGet() “this is a search, not just a page load.”

        public void OnGet()
        {

            // OnGet() gets the parameter values StartDate, EndDate, SearchEnabled from URL parameters
            // The page variables get set to those same values
            if (SearchEnabled == true)
            {
                AvailableRoomTypes = _db.GetAvailableRoomTypes(StartDate, EndDate);
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new { SearchEnabled = true, StartDate, EndDate });
        }
    }
}
