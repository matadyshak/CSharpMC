CREATE PROCEDURE [dbo].[spGuests_Insert]
	@firstName NVARCHAR(50),
	@lastName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
	
	-- Insert guest if not already present
	INSERT INTO dbo.Guests (FirstName, LastName)
	SELECT @firstName, @lastName
	WHERE NOT EXISTS (
	    SELECT 1 FROM dbo.Guests
		WHERE FirstName = @firstName AND LastName = @lastName
	);

    -- Return the guest record
	SELECT TOP 1 *
	FROM dbo.Guests 
	WHERE FirstName = @firstName AND LastName = @lastName
	ORDER BY Id DESC;
END;