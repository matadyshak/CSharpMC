

using System.Globalization;

DateTime today = DateTime.UtcNow;

//DateTime birthday = DateTime.Parse("6/11/1998");

//DateTime birthday = DateTime.ParseExact("6/11/1998", "d/M/yyyy", CultureInfo.InvariantCulture);

//Console.WriteLine(birthday.ToString());

Console.WriteLine(today.ToString("MMMM dd, yyyy hh:mm tt zzz"));