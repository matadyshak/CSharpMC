using System;

namespace MiniProjectStudentCheckApp
{
	internal class Program
	{
		static void Main()
		{
			string firstName;
			string formattedName;
			string ageText;
			int age;

			ConsoleWrite("What is your first name? ");
			firstName = Console.ReadLine();

//			bool isValid = false;
//			while(!isValid)
//			{
//				Console.Write("What is your age in years? ");
//				ageText = Console.ReadLine();
//				isValid = int.tryParse(ageText, out age) && (age >= 0);
//				if (!isValid)
//				{
//					Console.WriteLine($"Age entered: \'{ageText}\' is not valid.");
//				}
//			}

			Console.Write("What is your age in years? ");
			ageText = Console.ReadLine();
			if (int.tryParse(ageText, out age) == false)
			{
				Console.WriteLine($"Age entered: \'{ageText}\' is not valid. Program aborted.");
				Console.ReadLine();
				return;
			}

			if (firstName.ToLower() == "bob") || (firstName.ToLower() == "sue")
			{
				formattedName = $"Professor {firstName}" 
			}
			else
			{
				formattedName = firstName;
			}

			if (age < 21) 
			{
				Console.WriteLine($"I recommend you wait {21 - age} year(s), {formattedName}");
			}
			else
			{
				Console.WriteLine($"Welcome to the class, {formattedName}");
			}

		}
	}
}



