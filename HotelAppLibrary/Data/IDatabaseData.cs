using HotelAppLibrary.Models;

namespace HotelAppLibrary.Data;

public interface IDatabaseData
{
    List<RoomTypeModel> GetAvailableRoomTypes(DateTime startDate, DateTime endDate);
    void BookGuest(string firstName, string lastName, DateTime startDate, DateTime endDate, int roomTypeId);
    List<BookingFullModel> SearchBookings(string lastName);
    void CheckInGuest(int bookingId);
    RoomTypeModel GetRoomTypeById(int id);
}