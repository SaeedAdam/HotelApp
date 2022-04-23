CREATE PROCEDURE [dbo].[spBookings_CheckIn]
	@bookingId int

AS
begin
	set nocount on;

	update dbo.Bookings
	set ChekedIn = 1
	where Id = @bookingId;
end
