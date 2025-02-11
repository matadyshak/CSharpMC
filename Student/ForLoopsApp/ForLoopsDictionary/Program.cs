Dictionary<string, string> computers = new();

Console.WriteLine("Initialize dictionary and print the entries...");
computers.Add("Laptop", "Portable computer with LCD screen");
computers.Add("Desktop", "Non-Portable computer with separate monitor");
computers.Add("All-In-One", "Non-Portable computer with built-in LCD screen");

Console.WriteLine($"A Laptop is defined as a \'{computers["Laptop"]}\'");
Console.WriteLine($"A Desktop is defined as a \'{computers["Desktop"]}\'");
Console.WriteLine($"An All-In-One is defined as a \'{computers["All-In-One"]}\'");

Console.WriteLine("\nCopy the keys to a List object and pass the Keys collection to the constructor");
Console.WriteLine("Copy the values to a List object and pass the Values collection to the constructor");
Console.WriteLine("Print the keys and values using a for loop");
Console.WriteLine("This no longer works if elements are later deleted from the Dictionary");
List<string> keys = new List<string>(computers.Keys);
List<string> values = new List<string>(computers.Values);

for (int i = 0; i < computers.Count; i++)
{
    Console.WriteLine($"A {keys[i]} is defined as a \'{values[i]}\'");
}