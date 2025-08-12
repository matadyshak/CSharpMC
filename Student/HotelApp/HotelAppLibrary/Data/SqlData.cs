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
            return _db.LoadData<RoomTypeModel, dynamic>("dbo.uspRoomTypes_GetAvailableTypes",
                                                        // same name in sp and this method: camel case
                                                        new { startDate, endDate },
                                                        ConnectionStringName,
                                                        true);
        }
        //public void InsertGuestInfo(string firstName, string lastName)
        //{
        //    string sqlStatement = "insert into dbo.Guests(FirstName, LastName) values(firstName, lastName)";

        //    // How to prevent duplication?

        //    _db.SaveData(sqlStatement,
        //                 new { firstName, lastName },
        //                 ConnectionStringName,
        //                 false);
        //}

        //Assume there are no two people with the same name
        //If returning customer get the ID from the DB

        //-public void BookGuest(string firstName,
        //                       string lastName,
        //                       DateTime startDate,
        //                       DateTime endDate,
        //                       int roomType)
        //{
        //    _db.SaveData("dbo.uspRoomTypes_BookRoomType",
        //                 new { firstName, lastName, startDate, endDate, roomType },
        //                 ConnectionStringName,
        //                 true);
        //}
        -public void BookGuest(string firstName,
                               string lastName,
                               DateTime startDate,
                               DateTime endDate,
                               int roomType)
        {
            GuestModel guest = _db.LoadData<GuestModel, dynamic>("spGuests_Insert",
                                                                 new { firstName, lastName },
                                                                 ConnectionStringName,
                                                                 true).First();

            _db.SaveData("dbo.spRoomTypes_BookRoomType",
                         new { firstName, lastName, startDate, endDate, roomType },
                         ConnectionStringName,
                         true);
        }
    }
}