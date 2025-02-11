string nameString = "Tim,Sue,Bob,Jane";
string[] namesArray = nameString.Split(',');

Console.WriteLine("\nforeach from an array of strings");
foreach (string name in namesArray)
{
    Console.WriteLine(name);
}
// name out of scope here

Console.WriteLine("\nforeach from array converted to a List");
List<string> namesList = namesArray.ToList();
foreach (string name in namesList)
{
    Console.WriteLine(name);
}

Console.WriteLine("\nforeach with a List...");
List<string> namesList2 = nameString.Split(',').ToList();
foreach (string name in namesList2)
{
    Console.WriteLine(name);
}

Console.WriteLine("\nforeach with a Dictionary...");
Dictionary<string, string> cars = new Dictionary<string, string>();
cars.Add("Chevrolet", "Corvette");
cars.Add("Ford", "Mustang");
cars.Add("Dodge", "Challenger");
cars.Add("Honda", "Civic");

foreach (KeyValuePair<string, string> car in cars)
{
    Console.WriteLine($"Manufacturer: {car.Key}, Model: {car.Value}");
}

// var is a shortcut for the type that was assigned when first declared