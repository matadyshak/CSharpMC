CREATE PROCEDURE [dbo].[spRoomTypes_GetById]
AS
BEGIN
    SET NOCOUNT ON;

	SELECT [Id], [Title], [Description], [Price]
	FROM [dbo].[RoomTypes]
END
