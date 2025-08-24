using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data
{
    public class SqlData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }
        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetAvailableTypes",
                                                        // same name in sp and this method: camel case
                                                        new { startDate, endDate },
                                                        connectionStringName,
                                                        true);
        }

        public void BookGuest(string firstName,
                               string lastName,
                               DateTime startDate,
                               DateTime endDate,
                               int roomTypeId)
        {
            GuestModel guest = _db.LoadData<GuestModel, dynamic>("spGuests_Insert",
                                                                 new { firstName, lastName },
                                                                 connectionStringName,
                                                                 true).First();

            RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>("SELECT * FROM dbo.RoomTypes WHERE Id = @Id",
                                                                          new { Id = roomTypeId },
                                                                          connectionStringName,
                                                                          false).First();

            TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);

            List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>("spRooms_GetAvailableRooms",
                                                                              new { startDate, endDate, roomTypeId },
                                                                              connectionStringName,
                                                                              true);

            _db.SaveData("dbo.spBookings_Insert",
                         new
                         {
                             roomId = availableRooms.First().Id,
                             guestId = guest.Id,
                             startDate = startDate,
                             endDate = endDate,
                             totalCost = roomType.Price * timeStaying.Days
                         },
                         connectionStringName,
                         true);
        }

        public List<BookingFullModel> SearchBookings(string lastName)
        {
            return _db.LoadData<BookingFullModel, dynamic>("dbo.spBookings_Search",
                                              new { lastName, startDate = DateTime.Now.Date },
                                              connectionStringName,
                                              true);
        }
        public CheckInResultModel CheckInGuest(int bookingId)
        {
            _db.SaveData("dbo.spBookings_CheckIn",
                                    new
                                    {
                                        BookingId = bookingId
                                    },
                                    connectionStringName,
                                    true);

            CheckInResultModel result = _db.LoadData<CheckInResultModel, dynamic>(
                "dbo.spBookings_GetStatus",
                new
                {
                    BookingId = bookingId
                },
                connectionStringName,
                true).FirstOrDefault(); //Returns first value or null if no value

            string passFailMessage = result?.PassFailMessage;
            string statusMessage = result?.StatusMessage;

            return result;
        }
    }
}