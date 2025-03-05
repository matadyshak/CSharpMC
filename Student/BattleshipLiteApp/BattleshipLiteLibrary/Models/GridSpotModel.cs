namespace BattleshipLiteLibrary.Models
{
    public class GridSpotModel
    {
        public string SpotLetter { get; set; }
        public int SpotNumber { get; set; }

        public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty;

        public GridSpotModel(string spotLetter, int spotNumber, GridSpotStatus status)
        {
            SpotLetter=spotLetter;
            SpotNumber=spotNumber;
            Status = status;
        }
    }
}