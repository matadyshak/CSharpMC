using System;

namespace MethodOverload
{
    class Program
    {
        static void Main()
        {
            EmployeeModel michael = new EmployeeModel("Michael", "Tadyshak", 25.00m, "Customer Service");
            EmployeeModel myra = new EmployeeModel("Myra", "Tadyshak");
            EmployeeModel daniel = new EmployeeModel();

            Console.ReadLine();
        }
    }

    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal HourlyRate { get; set; }
        public string Department { get; set; }

        public EmployeeModel()
        {
        }
        public EmployeeModel(string firstName, string lastName, decimal hourlyRate, string department)
        {
            FirstName = firstName;
            LastName = lastName;
            HourlyRate = hourlyRate;
            Department = department;
        }

        public EmployeeModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            HourlyRate = GetHourlyRate();
            Department = GetDepartment();
        }

        public decimal GetHourlyRate()
        {
            decimal rate = 0;
            bool valid = false;

            while (!valid)
            {
                Console.Write("Enter hourly rate: ");
                string input = Console.ReadLine();
                try
                {
                    decimal.TryParse(input, out rate);
                    valid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine($"Input: {input} was invalid.  Try again.");
                }
            }

            return rate;
        }

        public string GetDepartment()
        {
            string department = "";

            Console.Write("Enter department name: ");
            department = Console.ReadLine();

            return department;
        }

    }
}
