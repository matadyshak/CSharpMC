CREATE PROCEDURE [dbo].[spRoomTypes_GetAvailableTypes]
	@startDate date,
	@endDate date
AS
BEGIN
    SET NOCOUNT ON;

SELECT DISTINCT
    rt.Id AS Id,
    rt.Title,
    rt.Description,
    rt.Price
FROM dbo.Rooms r
INNER JOIN dbo.RoomTypes rt ON rt.Id = r.RoomTypeId
WHERE r.Id NOT IN (
    SELECT b.RoomId 
    FROM dbo.Bookings b
    WHERE (@startDate < b.EndDate AND @endDate > b.StartDate)
)
ORDER BY rt.Price;
END;