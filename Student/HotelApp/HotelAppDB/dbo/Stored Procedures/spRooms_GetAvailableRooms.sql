CREATE PROCEDURE [dbo].[spRooms_GetAvailableRooms]
	@startDate date,
	@endDate date,
	@roomTypeId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT r.*
	FROM dbo.Rooms r
	INNER JOIN dbo.RoomTypes t on t.Id = r.RoomTypeId
	WHERE r.RoomTypeId = @roomTypeId
	AND r.Id NOT IN (
		select b.RoomId 
		from dbo.Bookings b
		where (@startDate < b.EndDate and @endDate > b.StartDate)
	);	

END;