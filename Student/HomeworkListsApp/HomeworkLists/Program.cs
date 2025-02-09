
List <string> students = new List<string>();

do
{
    Console.Write("\nEnter student's last name (or type 'exit' to finish): ");
    string studentName = Console.ReadLine();

    if (string.IsNullOrEmpty(studentName))
    {
        Console.WriteLine("Invalid input. Please enter a valid name.");
        continue;
    }

    if (studentName.ToLower() == "exit")
    {
        break;
    }

    students.Add(studentName);
} while (true);

    // This caused the first char of "Students in the class: " to be consumed
    //} while (Console.ReadKey().Key != ConsoleKey.Escape);

Console.WriteLine("Students in the class: ");

foreach(string student in students)
{
    Console.WriteLine(student);
}