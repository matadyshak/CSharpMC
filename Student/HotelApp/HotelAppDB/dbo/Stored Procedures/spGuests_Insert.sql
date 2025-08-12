CREATE PROCEDURE [dbo].[spGuests_Insert]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50)
AS
BEGIN
	DECLARE @guestId int;
	
	INSERT INTO dbo.Guests (FirstName, LastName)
	SELECT @firstName, @lastName
	WHERE NOT EXISTS (
	    SELECT 1 FROM dbo.Guests
		WHERE FirstName = @firstName AND LastName = @lastName
		);

    -- Get the Id of the guest either new or repeated customer
	SELECT @guestId = Id
	FROM dbo.Guests 
	WHERE FirstName = @firstName AND LastName = @lastName;
END;