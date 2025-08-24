CREATE PROCEDURE [dbo].[spBookings_CheckIn]
	@bookingId int
AS
BEGIN
	SET NOCOUNT ON;
	-- Check if the booking exists
	IF NOT EXISTS (SELECT 1 FROM dbo.Bookings WHERE Id = @bookingId)
	BEGIN
		RETURN -1;
	END
	-- Update the booking to set CheckedIn to 1
	UPDATE dbo.Bookings
	SET CheckedIn = 1
	WHERE Id = @bookingId;
    RETURN 0;
END;