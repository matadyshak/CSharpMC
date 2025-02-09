
// The name Dictionary must be used unless you have created a sub-class of Dictionary
Dictionary<int, string> sacraments = new Dictionary<int, string>
{
    { 1, "Baptism" },
    { 2, "Confirmation" },
    { 3, "Eucharist" },
    { 4, "Reconciliation" },
    { 5, "Anointing of the Sick" },
    { 6, "Holy Orders" },
    { 7, "Matrimony" }
};

//sacraments.Add(1, "Baptism");
//sacraments.Add(2, "Confirmation");
//sacraments.Add(3, "Eucharist");
//sacraments.Add(4, "Reconciliation");
//sacraments.Add(5, "Anointing of the Sick");
//sacraments.Add(6, "Holy Orders");
//sacraments.Add(7, "Matrimony");


Console.WriteLine($"Key: 1  Name: {sacraments[1]}");
Console.WriteLine($"Key: 2  Name: {sacraments[2]}");
Console.WriteLine($"Key: 3  Name: {sacraments[3]}");
Console.WriteLine($"Key: 4  Name: {sacraments[4]}");
Console.WriteLine($"Key: 5  Name: {sacraments[5]}");
Console.WriteLine($"Key: 6  Name: {sacraments[6]}");
Console.WriteLine($"Key: 7  Name: {sacraments[7]}");

Console.WriteLine("Sacraments:");
foreach (KeyValuePair<int, string> sacrament in sacraments)
{
    // Key and Value are properties of the generic KeyValuePair class
    Console.WriteLine($"ID: {sacrament.Key}, Name: {sacrament.Value}");
}


KeyValuePair<int, string> sacrament2 = sacraments.First();
Console.WriteLine($"First Key: {sacrament2.Key}  Name: {sacrament2.Value}");

// There is no Next() method
//KeyValuePair<int, string> sacrament3 = sacraments.Next();
//Console.WriteLine($"Middle Key: {sacrament3.Key}  Name: {sacrament3.Value}");

KeyValuePair<int, string> sacrament4 = sacraments.Last();
Console.WriteLine($"Last Key: {sacrament4.Key}  Name: {sacrament4.Value}");


