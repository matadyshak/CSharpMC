

Dictionary<int, string> highGames = new Dictionary<int, string>
{
    {300, "Michael Tadyshak"},
    {200, "Myra Tadyshak"},
    {10, "Eilif Baumbach"}
};

var enumerator = highGames.GetEnumerator();

while (enumerator.MoveNext())
{
    var currentKey = enumerator.Current.Key;
    Console.WriteLine($"Name: {enumerator.Current.Value}, High Game: {currentKey}");
}

if (enumerator.MoveNext())
{
    var nextKey = enumerator.Current.Key;
    Console.WriteLine($"Name: {enumerator.Current.Value}, High Game: {nextKey}");
}
else
{
    Console.WriteLine("No more bowlers.");
}