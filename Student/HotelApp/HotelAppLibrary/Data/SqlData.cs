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
        public void InsertGuestInfo(string firstName, string lastName)
        {
            string sqlStatement = "insert into dbo.Guests(FirstName, LastName) values(firstName, lastName)";

            // How to prevent duplication?

            _db.SaveData(sqlStatement,
                         new { firstName, lastName },
                         ConnectionStringName,
                         false);
        }
        -public void BookRoomType(int roomTypeId, DateTime startDate, DateTime endDate, string firstName, string lastName)
        {
            _db.SaveData("dbo.spRoomTypes_BookRoomType",
                         new { roomTypeId, startDate, endDate, firstName, lastName },
                         ConnectionStringName,
                         true);
        }
    }
}