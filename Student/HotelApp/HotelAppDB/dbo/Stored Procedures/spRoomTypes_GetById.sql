CREATE PROCEDURE [dbo].[spRoomTypes_GetById]
	@Id int
AS
BEGIN
    SET NOCOUNT ON;

	SELECT [Id], [Title], [Description], [Price]
	FROM [dbo].[RoomTypes]
	WHERE [Id] = @Id;
END
