CREATE PROCEDURE [dbo].[spBookings_Search]
	@lastName nvarchar(50),
	@startDate date
AS
begin
	set nocount on;

	select [b].[Id], [b].[RoomId], [b].[GuestId], [b].[StartDate], [b].[EndDate], [b].[ChekedIn], 
		[b].[TotalCost],[g].[FirstName], [g].[LastName], [r].[RoomNumber], [r].[RoomTypeId], 
		[t].[Type], [t].[Description], [t].[Price] 
	from dbo.Bookings b
	inner join dbo.Guests g on b.GuestId = g.Id
	inner join dbo.Rooms r on b.RoomId = r.Id
	inner join dbo.RoomTypes t on r.RoomTypeId = t.Id
	where b.StartDate = @startDate and g.LastName = @lastName;
end
