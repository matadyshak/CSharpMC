using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Web.Pages
{
    public class RoomSearchModel : PageModel
    {
        private readonly IDatabaseData _db;

        public RoomSearchModel(IDatabaseData db)
        {
            _db = db;
        }

        // Represents the list of available room types
        [BindProperty]
        public List<RoomTypeModel> RoomTypes { get; set; } = new();

        [BindProperty]
        public DateTime? StartDate { get; set; }

        [BindProperty]
        public DateTime? EndDate { get; set; }

        public string SelectedText { get; set; }

        public void OnGet()
        {
            // Populate the list of room types from the database

        }

        public void OnPost()
        {
            if (Request.Form["action"] == "search")
            {
                if (StartDate.HasValue && EndDate.HasValue)
                {
                    RoomTypes = _db.GetAvailableRoomTypes(StartDate.Value, EndDate.Value);
                }
                else
                {
                    RoomTypes = new List<RoomTypeModel>(); // Or show a validation message
                }
            }
            //else if (Request.Form["selectedText"].Count > 0)
            //{
            //    var selectedRoomType = Request.Form["selectedText"];
            //    // Handle room selection logic here
            //}
        }
    }
}