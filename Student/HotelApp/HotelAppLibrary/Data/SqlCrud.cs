using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace HotelAppLibrary.Data
{
    public class SqlCrud
    {
        private SqlDataAccess db = new SqlDataAccess(IConfiguration config);
        public void GetAvailableRooms(SqlCrud sql)
        {
            var rows = sql.ReadAvailableRooms();

            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.RoomTypeId} {row.RoomNumber}");
            }
        }

        public List<Rooms> ReadAvailableRooms()
        {
            string sql = "select Id, RoomTypeId, RoomNumber from dbo.Rooms;";
            return db.LoadData<Rooms, Rooms>(sql, null, "Default");
        }
    }
}
