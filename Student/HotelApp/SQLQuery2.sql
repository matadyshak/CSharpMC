



	SELECT [b].[Id], [b].[RoomId], [b].[GuestId], [b].[StartDate], [b].[EndDate], 
	    [b].[CheckedIn], [b].[TotalCost], [g].[FirstName], [g].[LastName],
		[r].[RoomTypeId], [r].[RoomNumber], [rt].[Title], [rt].[Description],
		[rt].[Price]
	FROM dbo.Bookings b
	INNER JOIN dbo.Guests g ON b.GuestId = g.Id
	INNER JOIN dbo.Rooms r ON b.RoomId = r.Id
	INNER JOIN dbo.RoomTypes rt ON r.RoomTypeId = rt.Id
	WHERE b.StartDate = '12/5/19' AND g.LastName = 'Corey';

















