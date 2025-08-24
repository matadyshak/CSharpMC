CREATE PROCEDURE [dbo].[spBookings_GetStatus]
	@bookingId int
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @passFailMessage NVARCHAR(50);
    DECLARE @statusMessage NVARCHAR(50);
    DECLARE @checkedIn BIT;

    -- Check if the booking exists
    IF NOT EXISTS (SELECT 1 FROM dbo.Bookings WHERE Id = @bookingId)
    BEGIN
        SET @passFailMessage = 'Error';
        SET @statusMessage = 'Booking not found';
        SELECT @passFailMessage AS PassFailMessage, @statusMessage AS StatusMessage;
        RETURN -1;
    END

    -- Retrieve CheckedIn status
    SELECT @checkedIn = CheckedIn
    FROM dbo.Bookings
    WHERE Id = @bookingId;

    -- Evaluate CheckedIn status
    IF @checkedIn = 1
    BEGIN
        SET @passFailMessage = 'Success';
        SET @statusMessage = 'Booking checked in successfully';
    END
    ELSE
    BEGIN
        SET @passFailMessage = 'Error';
        SET @statusMessage = 'Booking could not be checked in';
    END

    SELECT @passFailMessage AS PassFailMessage, @statusMessage AS StatusMessage;
    RETURN 0;
END
