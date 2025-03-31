using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CollegeClassModel history = new CollegeClassModel("History 101", 3);
            CollegeClassModel math = new CollegeClassModel("Caculus 201", 2);

            history.EnrollmentFull += CollegeClass_EnrollmentFull;

            history.SignUpStudent("Tim Corey").PrintToConsole();
            history.SignUpStudent("Sue Storm").PrintToConsole();
            history.SignUpStudent("Joe Smith").PrintToConsole();
            history.SignUpStudent("Mary Jones").PrintToConsole();
            history.SignUpStudent("Sandy Patty").PrintToConsole();
            Console.WriteLine();

            math.EnrollmentFull += CollegeClass_EnrollmentFull;

            math.SignUpStudent("Sue Storm").PrintToConsole();
            math.SignUpStudent("Joe Smith").PrintToConsole();
            math.SignUpStudent("Mary Jones").PrintToConsole();

            Console.ReadLine();
        }

        private static void CollegeClass_EnrollmentFull(object sender, string e)
        {
            CollegeClassModel model = (CollegeClassModel)sender;

            Console.WriteLine();
            Console.WriteLine($"{ model.CourseTitle }: Full");
            Console.WriteLine();
        }
    }
}
