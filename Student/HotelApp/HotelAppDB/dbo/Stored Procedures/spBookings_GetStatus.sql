CREATE PROCEDURE [dbo].[spBookings_GetStatus]
	@bookingId int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @passFailMessage NVARCHAR(50);
	DECLARE @statusMessage NVARCHAR(50);
	-- Check if the booking exists
	IF NOT EXISTS (SELECT 1 FROM dbo.Bookings WHERE Id = @bookingId)
	BEGIN
		SET @passFailMessage = 'Error';
		SET @statusMessage = 'Booking not found';
		SELECT @passFailMessage, @statusMessage
		RETURN -1;
	END
	SELECT CheckedIn
	FROM dbo.Bookings
	WHERE Id = @bookingId AND CheckedIn = 1;
	SET @passFailMessage = 'Success';
	SET @statusMessage = 'Booking checked in successfully';
	SELECT @passFailMessage, @statusMessage
RETURN 0;
END;
