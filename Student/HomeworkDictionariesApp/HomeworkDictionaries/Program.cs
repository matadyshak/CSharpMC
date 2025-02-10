Dictionary<int, string> employees = new Dictionary<int, string>();
employees.Add(67265, "Michael Tadyshak");
employees.Add(68111, "Dustin Diaz");
employees.Add(68110, "Jennifer Cowden");

// Allow entry of three more employees
bool isValid = false;
bool isDone = false;
int employeeNumber = 0;
string? input = null;
string? employeeFullName = null;

//REGEX
// * = 0 or more
// ? = 0 or 1
// + = 1 or more
// (){0,} = 0 or more groups of what is in parens

//One or more names with first letter capitalized and single space between names and allows single letter names, ie K C Jones and most Baptist preachers
string regexFullName = @"^[A-Z][a-z]*(\s[A-Z][a-z]*){0,}$";

//One or more names with first letter capitalized and allow multiple spaces between words: [\s]+
//string regexFullName = @"^[A-Z][a-z]*([\s]+[A-Z][a-z]*){0,}$"; 

//Also allows hyphenated names and the ' char
//string regexFullName = @"^([a-zA-Z]{ 2,}\s[a-zA-Z]{ 1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)$";

//Listing others while we are at it (See MySecondProject)
//string regexCellNumber = @"^(\+?\d{1,2}\s?)?(\(?\d{3}\)?[\s.-]?)?\d{3}[\s.-]?\d{4}$";
//string regexEmailAddress = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

while (!isDone)
{
    do
    {
        isValid = false;
        Console.Write("\nEnter an employee number [10000-99999] or type 'exit' to quit: ");
        input = Console.ReadLine().Trim();
        if (input.ToLower() == "exit")
        {
            isDone = true;
            break;
        }

        if (int.TryParse(input, out employeeNumber) && (employeeNumber >= 10000)  && (employeeNumber < 100000))
        {
            isValid = true;
        }
        else
        {
            Console.WriteLine($"Employee number: \'{input}\' is invalid.  Please try again.");
        }
    } while (!isValid);

    isValid = false;
    while (!isValid && !isDone)
    {
        Console.Write("Enter employee's full name [Firstname Lastname]: ");
        employeeFullName = Console.ReadLine().Trim();
        //The regex allows multiple names and requires first letter only of each name to be capitalized 
        if ((employeeFullName != null) && (employeeFullName.Length > 0) &&
            (System.Text.RegularExpressions.Regex.IsMatch(employeeFullName, regexFullName)))
        {
            isValid = true;
            try
            {
                employees.Add(employeeNumber, employeeFullName);
            }
            catch
            {
                Console.WriteLine($"Failed to add employee # \'{employeeNumber}\', Name: {employeeFullName}");
            }
        }
        else
        {
            Console.WriteLine($"Employee's full name: \'{employeeFullName}\' is invalid.  Please try again.");
        }
    }
}

// Ask user to enter some IDs and return the names
isValid = false;
isDone = false;

while (!isDone)
{
    isValid = false;
    while (!isValid)
    {
        Console.Write("\nEnter an employee number [10000-99999] to retrieve the employee full name or type 'exit' to quit: ");
        input = Console.ReadLine().Trim();
        if (input.ToLower() == "exit")
        {
            isDone = true;
            break;
        }

        if (int.TryParse(input, out employeeNumber) && (employeeNumber >= 10000)  && (employeeNumber < 100000))
        {
            isValid = true;
            try
            {
                Console.WriteLine($"Employee # {employeeNumber} is {employees[employeeNumber]}");
            }
            catch
            {
                Console.WriteLine($"Employee # {employeeNumber} was not found.");
            }
        }
        else
        {
            Console.WriteLine($"Employee number: \'{input}\' is invalid.  Please try again.");
        }
    }
} //while (!isDone)

Console.WriteLine("Program ended.");

