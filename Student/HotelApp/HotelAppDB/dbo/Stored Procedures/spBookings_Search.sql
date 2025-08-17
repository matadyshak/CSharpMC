CREATE PROCEDURE [dbo].[spBookings_Search]
	@lastName NVARCHAR(50),
	@dateToday Date
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @guestId int;

	SELECT b.*
	FROM dbo.Bookings b
	INNER JOIN dbo.Guests g ON b.GuestId = g.Id
	WHERE g.LastName = @lastName AND b.StartDate <= @dateToday AND b.EndDate >= @dateToday;
--
--	SELECT @guestId = Id
--	FROM dbo.Guests 
--	WHERE LastName = @lastName;

END;

--bookings table
--id roomid guestid startdate enddate checkedin totalcost

--BookingModel
--id roomid guestid startdate enddate checkedin totalcost

--GuestModel Guest = Id, FirstName, LastName
--RoomModel Room = Id, RoomNumber, RoomType