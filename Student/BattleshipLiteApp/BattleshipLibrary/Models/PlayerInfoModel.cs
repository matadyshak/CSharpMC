using System.Collections.Generic;

namespace BattleshipLiteLibrary.Models
{
    class PlayerInfoModel
    {
        public string Name { get; set; }
        public List<GridSpotModel> ShipLocations { get; set; } = new List<GridSpotModel>();
        public List<GridSpotModel> ShotGrid { get; set; } = new List<GridSpotModel>();
        public int TotalShots { get; set; }
        public int TotalHits { get; set; }


    }
}
