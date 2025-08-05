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
    }
}

//public List<T> LoadData<T, U>(string sqlStatement,
//                              U parameters,
//                              string connectionStringName,
//                              bool isStoredProcedure = false)





//            var rows = sql.ReadAvailableRooms();

//            foreach (var row in rows)
//            {
//                Console.WriteLine($"{row.Id}: {row.RoomTypeId} {row.RoomNumber}");
//            }
//        }

//        public List<RoomModel> ReadAvailableRooms()
//        {
//            string sql = "select Id, RoomTypeId, RoomNumber from dbo.Rooms;";
//            return db.LoadData<RoomModel, RoomModel>(sql, null, "Default");
//        }
//    }
//}
