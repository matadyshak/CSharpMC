namespace BattleshipLiteLibrary.Models
{
    class GridSpotModel
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
