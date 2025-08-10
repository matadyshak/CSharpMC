CREATE PROCEDURE [dbo].[spRoomTypes_BookRoomType]
	@roomTypeId INT,
	@startDate DATE,
	@endDate DATE,
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @guestId int;
	DECLARE @roomId int;
	DECLARE @checkedIn bit;
	DECLARE @price money;
	DECLARE @totalCost money;
	DECLARE @roomNumber NVARCHAR(20);

	INSERT INTO dbo.Guests (FirstName, LastName)
	SELECT @firstName, @lastName
	WHERE NOT EXISTS (
	    SELECT 1 FROM dbo.Guests
		WHERE FirstName = @firstName AND LastName = @lastName
		);

	SELECT @guestId = Id
	FROM dbo.Guests 
	WHERE FirstName = @firstName AND LastName = @lastName;

	--How do I know if room 101, 102 or 103 is available?
	--By examining all the bookings
	
	-- Find an available room of the given type
    --SELECT TOP 1 @roomId = r.Id, @roomNumber = r.RoomNumber
    --FROM dbo.Rooms r
    --WHERE r.RoomTypeId = @roomTypeId
    --AND NOT EXISTS (
    --    SELECT 1 FROM dbo.Bookings b
    --    WHERE b.RoomId = r.Id
    --    AND (
    --        (@startDate BETWEEN b.StartDate AND b.EndDate) OR
    --        (@endDate BETWEEN b.StartDate AND b.EndDate) OR
    --        (b.StartDate BETWEEN @startDate AND @endDate)
    --    )
    --);



	SELECT @roomId, @roomNumber from dbo.Rooms where RoomTypeId = @roomTypeId;
	
	-- Use SET or SELECT when assigning values to variables
	SELECT @price = Price 
	FROM dbo.RoomTypes where RoomTypeId = @roomTypeId;

	SET @totalCost = DATEDIFF(DAY, @startDate, @endDate) * @price;
		
	INSERT INTO dbo.Bookings (RoomId, GuestId, StartDate, EndDate, CheckedIn, TotalCost)
	VALUES (@roomId, @guestId, @startDate, @endDate, @checkedIn, @totalCost);
end;
