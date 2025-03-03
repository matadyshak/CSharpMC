﻿using static BattleshipLiteLibrary.Models.enums;

namespace BattleshipLiteLibrary.Models
{
    class PlayerInfoModel
    {
        public string SpotLetter { get; set; }
        public int SpotNumber { get; set; }

        public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty;
        public GridSpotModel(string spotLetter, int spotNumber)
        {
            SpotLetter=spotLetter;
            SpotNumber=spotNumber;
        }
    }
}
