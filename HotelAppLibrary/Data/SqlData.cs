using HotelAppLibrary.Databases;
using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data
{
    public class SqlData : IDatabaseData
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
                                        new { startDate, endDate },
                                        ConnectionStringName,
                                        true);
        }

        public void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId)
        {
            GuestModel guest = _db.LoadData<GuestModel, dynamic>("dbo.spGuest_Insert",
                    new { firstName, lastName },
                    ConnectionStringName,
                    true).First();


            RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>("select * from dbo.RoomTypes where Id = @Id",
                new { Id = roomTypeId }, ConnectionStringName, false).First();

            TimeSpan timeStaying = endDate.Date.Subtract(startDate.Date);

            List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>("dbo.spRoomTypes_GetAvailableTypes",
                new { startDate, endDate },
                ConnectionStringName,
                true);


            _db.SaveData("dbo.spBooking_Insert",
                new
                {
                    roomId = availableRooms.First().Id,
                    guestId = guest.Id,
                    startDate = startDate,
                    endDate = endDate,
                    totalCost = timeStaying.Days * roomType.Price
                },
                ConnectionStringName,
                true);
        }

        public List<BookingFullModel> SearchBookings(string lastName)
        {
            return _db.LoadData<BookingFullModel, dynamic>("dbo.spBookings_Search",
                new { lastName, StartDate = DateTime.Now.Date },
                ConnectionStringName,
                true);
        }

        public void CheckInGuest(int Id)
        {
            _db.SaveData("dbo.spBookings_CheckIn", new {bookingId = Id }, ConnectionStringName, true);
        }

        public RoomTypeModel GetRoomTypeById(int id)
        {
            return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypes_GetById", new {id}, ConnectionStringName,
                true).FirstOrDefault();
        }



        // هذه الدالة للتجربة, حاول تجربها لما تبني الفرونت اند

        //public void CheckInGuest(string lastName)
        //{
        //    var booking = SearchBookings(lastName);
        //    booking.First().CheckedIn = true;
        //}
    }
}
