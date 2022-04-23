CREATE TABLE [dbo].[Bookings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoomId] INT NOT NULL, 
    [GuestId] INT NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NOT NULL, 
    [ChekedIn] BIT NOT NULL DEFAULT 0, 
    [TotalCost] MONEY NOT NULL, 
    CONSTRAINT [FK_Bookings_Rooms] FOREIGN KEY (RoomId) REFERENCES Rooms(Id), 
    CONSTRAINT [FK_Bookings_Guest] FOREIGN KEY (GuestId) REFERENCES Guests(Id)
)
