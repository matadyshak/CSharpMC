CREATE PROCEDURE [dbo].[spBookings_Search]
	@lastName NVARCHAR(50),
	@dateToday date
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @guestId int;



	SELECT *
	from dbo.Bookings b
	WHERE b.LastName = @lastName AND b.StartDate <= @dateToday AND b.EndDate >= @dateToday;
	SELECT @guestId = Id
	FROM dbo.Guests 
	WHERE LastName = @lastName;



END;