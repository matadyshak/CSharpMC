// C# allows a shortcut to not retype the data type
List<float> gradePointAverage = new();
List<string> students = new();

//The new command creates a new List with no entries
//.Add method adds memory for another element to the List and initializes it
//From that point the list can be accessed sequentially like an array
//Size of the array does not matter
//Don't have to initialize the amount of storage and then worry if there is enough
//Can also delete items from the List which frees memory
//Can use any data type

gradePointAverage.Add(3.78f);
gradePointAverage.Add(3.25f);
gradePointAverage.Add(2.75f);

students.Add("Michael Tadyshak");
students.Add("Steve Gilles");
students.Add("Ray Pokrandt");

for (int i = 0; i < gradePointAverage.Count; i++)
{
    Console.WriteLine($"{students[i]} graduated with a grade point average of {gradePointAverage[i]}");
}

