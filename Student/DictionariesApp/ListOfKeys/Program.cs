

Dictionary<int, string> highSeries = new Dictionary<int, string>();

highSeries.Add(900, "Michael");
highSeries.Add(600, "Myra");
highSeries.Add(100, "Eilif");

//.Key is a single key
// .Keys is a collection of keys
List<int> keys = new List<int>(highSeries.Keys);

for (int i = 0; i < keys.Count; i++)
{
    int currentKey = keys[i];

    if (i==0)
    {
        Console.WriteLine($"Name: {highSeries[currentKey]}, High Series: {currentKey}");
    }

    if (i < keys.Count - 1)
    {
        // For all but the lastkey, get the next key
        int nextKey = keys[i + 1];
        // Console.WriteLine($"Next Key: {nextKey}, Value: {highSeries[nextKey]}");
        Console.WriteLine($"Name: {highSeries[nextKey]}, High Series: {nextKey}");
    }
    else
    {
        Console.WriteLine("No more bowlers.");
    }
}