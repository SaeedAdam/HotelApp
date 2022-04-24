CREATE TABLE [dbo].[Bookings] (
    [Id]        INT   IDENTITY (1, 1) NOT NULL,
    [RoomId]    INT   NOT NULL,
    [GuestId]   INT   NOT NULL,
    [StartDate] DATE  NOT NULL,
    [EndDate]   DATE  NOT NULL,
    [CheckedIn]  BIT   DEFAULT ((0)) NOT NULL,
    [TotalCost] MONEY NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Bookings_Rooms] FOREIGN KEY ([RoomId]) REFERENCES [dbo].[Rooms] ([Id]),
    CONSTRAINT [FK_Bookings_Guest] FOREIGN KEY ([GuestId]) REFERENCES [dbo].[Guests] ([Id])
);

