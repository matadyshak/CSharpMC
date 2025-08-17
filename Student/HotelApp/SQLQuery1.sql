	@lastName NVARCHAR(50),
	@dateToday date
AS
BEGIN
    SET NOCOUNT ON;

	DECLARE @guestId int;

	SELECT b.*
	FROM dbo.Bookings b
	INNER JOIN dbo.Guests g ON b.GuestId = g.Id
	WHERE g.LastName = 'Corey' AND b.StartDate <= '08/16/25' AND b.EndDate >= '08/16/25';
--
--	SELECT @guestId = Id
--	FROM dbo.Guests 
--	WHERE LastName = @lastName;

select * from dbo.Bookings b;


END;