

using System.Globalization;

bool isValid = false;
string? input = null;
string[] names;
//REGEX
// * = 0 or more
// ? = 0 or 1
// + = 1 or more
// (){0,} = 0 or more groups of what is in parens

//One or more first names separated by commas with first letter capitalized
//string regexFirstNameCSV = @"^[A-Z][a-z]*(,[A-Z][a-z]*){0,}$";

//Allows mixed case entry
string regexFirstNameCSV = @"^[A-Za-z]+(,[A-Za-z]+){0,}$";

while (!isValid)
{
    Console.Write("\nEnter a comma separated list of first names: ");
    input = Console.ReadLine();
    if (string.IsNullOrEmpty(input) ||
       (System.Text.RegularExpressions.Regex.IsMatch(input, regexFirstNameCSV) == false))
    {
        isValid = false;
        Console.WriteLine("The comma-separated list of first names was invalid.  Be sure there are only commas and no spaces.");
    }
    else
    {
        // Program will allow user to enter names with mixed case of any kind but then converts the entries to title case (first letter capitalized)
        isValid = true;
        input = ConvertToTitleCase(input);
        names = input.Split(',');
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"Hello, {names[i]}!");
        }
    }
}

static string ConvertToTitleCase(string mixedCase)
{
    mixedCase = mixedCase.Trim();
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    string titleCase = textInfo.ToTitleCase(mixedCase.ToLower());

    return titleCase;
}