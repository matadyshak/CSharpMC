CREATE TABLE [dbo].[RoomType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(1024) NOT NULL, 
    [Price] DECIMAL NOT NULL
)
