CREATE PROCEDURE [dbo].[spRoomTypes_GetAvailableTypes]
	@startDate date,
	@endDate date
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        r.Id AS RoomId,
        r.RoomNumber,
        rt.Id AS RoomTypeId,
        rt.Title,
        rt.Description,
        rt.Price
    FROM dbo.Rooms r
    INNER JOIN dbo.RoomTypes rt ON rt.Id = r.RoomTypeId
    WHERE r.Id NOT IN (
        SELECT b.RoomId 
        FROM dbo.Bookings b
        WHERE (
            (@startDate < b.EndDate AND @endDate > b.StartDate)
        )
    )
    ORDER by rt.Price, r.RoomNumber;
 END;

 --CREATE PROCEDURE [dbo].[spRoomTypes_GetAvailableTypes]
--	@startDate date,
--	@endDate date
--AS
--begin
--    set nocount on;

--    select t.Id, t.Title, t.Description, t.Price
--    from dbo.Rooms r
--    inner join dbo.RoomTypes t on t.Id = r.RoomTypeId
--    where r.Id not in (
--    select b.RoomId 
--    from dbo.Bookings b
--    where (@startDate < b.StartDate and @endDate > b.EndDate)
--        or (b.StartDate <= @endDate and @endDate < b.EndDate)
--        or (b.StartDate <= @startDate and @startDate < b.EndDate)
--    )
--    group by t.Id, t.Title, t.Description, t.Price;
--end