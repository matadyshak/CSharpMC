CREATE PROCEDURE [dbo].[spBookings_CheckIn]
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
		RETURN -1;
	END
	-- Update the booking to set CheckedIn to 1
	UPDATE dbo.Bookings
	SET CheckedIn = 1
	WHERE Id = @bookingId;
	SET @passFailMessage = 'Success';
	SET @statusMessage = 'Booking checked in successfully';
	SELECT @passFailMessage, @statusMessage
RETURN 0
END;