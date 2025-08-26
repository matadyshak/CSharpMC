using HotelAppLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelApp.Web.Pages
{
    public class RoomSearchModel : PageModel
    {
        [BindProperty]
        public List<RoomTypeModel> Items { get; set; }
        public void OnGet()
        {
            Items = new List<RoomTypeModel>
            {
                new RoomTypeModel { Title = "King Size Bed", Description = "A room with a king-size bed and a window", Price = 100 },
                new RoomTypeModel { Title = "Two Queen Size Beds", Description = "A room with two queen-size beds and a window", Price = 115 },
                new RoomTypeModel { Title = "Executive Suite", Description = "Two rooms, each with a king-size bed and a window", Price = 205 }
            };
        }

        public IActionResult OnPostSelect(string roomTitle)
        {
            return RedirectToPage("/RoomSearch", new { roomTitle = roomTitle });
        }
    }
}
