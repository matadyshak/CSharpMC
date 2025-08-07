using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data
{
    public class SqlData
    {
        private readonly ISqlDataAccess _db;
        private const string ConnectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }
        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetAvailableTypes",
                                                            // same name in sp and this method: camel case
                                                            new { startDate, endDate },
                                                            ConnectionStringName,
                                                            true);
        }

        public void BookRoomType(int roomTypeId, DateTime startDate, DateTime endDate)
        {
            _db.SaveData("dbo.spRoomTypes_BookRoomType",
                         new { RoomTypeId = roomTypeId, StartDate = startDate, EndDate = endDate },
                         ConnectionStringName,
                         true);
        }
    }
}