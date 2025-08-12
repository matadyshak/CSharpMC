--CREATE PROCEDURE [dbo].[spRoomTypes_BookRoomType]
--	@roomTypeId INT,
--	@startDate DATE,
--	@endDate DATE,
--	@firstName NVARCHAR(50),
--	@lastName NVARCHAR(50)
--AS
--BEGIN
--    SET NOCOUNT ON;
--	-----------------------------------------------------
--	DECLARE @guestId int;
--	DECLARE @roomId int;
--	DECLARE @checkedIn bit = 0;
--	DECLARE @price money;
--	DECLARE @totalCost money;

--    -- Get the Id of the guest either new or repeated customer
--	SELECT @guestId = Id
--	FROM dbo.Guests 
--	WHERE FirstName = @firstName AND LastName = @lastName;

--	--How do I know if room 101, 102 or 103 is available?
--	--By examining all the bookings

--	-- Find 1ST available room of the given type
--    SELECT TOP 1 @roomId = r.Id
--    FROM dbo.Rooms r
--    WHERE r.RoomTypeId = @roomTypeId
--    AND r.Id NOT IN (
--        SELECT b.RoomId
--		FROM dbo.Bookings b
--        WHERE (
--		    @startDate < b.EndDate AND @endDate > b.StartDate
--        )
--    );

--	-- Use SET or SELECT when assigning values to variables
--	SELECT @price = Price 
--	FROM dbo.RoomTypes WHERE Id = @roomTypeId;

--	SET @totalCost = DATEDIFF(DAY, @startDate, @endDate) * @price;
	
--	INSERT INTO dbo.Bookings (RoomId, GuestId, StartDate, EndDate, CheckedIn, TotalCost)
--	VALUES (@roomId, @guestId, @startDate, @endDate, @checkedIn, @totalCost);
--end;
