using System.Collections.Generic;

namespace BattleshipLibrary.Models
{
    class PlayerInfoModel
    {
        public string Name { get; set; }
        public List<GridSpotModel> ShipLocations { get; set; }
        public List<GridSpotModel> ShotGrid { get; set; }
        public int TotalShots { get; set; }
        public int TotalHits { get; set; }
    }
}
