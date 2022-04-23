CREATE PROCEDURE [dbo].[spRoomTypes_GetById]
	@id int

AS
begin
	set nocount on;

	select *
	from dbo.RoomTypes
	where Id = @id;
end