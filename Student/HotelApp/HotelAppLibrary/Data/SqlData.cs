using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data
{
    public class SqlData : IDatabaseData
    {
        private readonly ISqlDataAccess _db;
        private const string connectionStringName = "SqlDb";

        public SqlData(ISqlDataAccess db)
        {
            _db = db;
        }
        public List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate)
        {
            List<RoomTypeModel> roomTypes = _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetAvailableTypes",
                                                    new { startDate, endDate },
                                                    connectionStringName,
                                                    true);
            // Group by primary key of the RoomTypes table (RoomTypeId)
            var groups = roomTypes
                .GroupBy(rt => rt.Id);

            // Select the first entry from each group
            var selection = groups
                .Select(g => g.First());

            // Convert to a list
            var distinctRoomTypes = selection
                .ToList();

            return distinctRoomTypes;
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

            _db.SaveData<dynamic>("dbo.spBookings_Insert",
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
            _db.SaveData<dynamic>("dbo.spBookings_CheckIn",
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
                true).FirstOrDefault();

            return result;
        }

        public RoomTypeModel GetRoomTypeById(int id)
        {
            return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetById",
                                                        new { id },
                                                        connectionStringName,
                                                        true).FirstOrDefault();
        }
    }
}