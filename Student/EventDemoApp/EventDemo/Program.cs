using System;

namespace EventDemo
{
    class Program
    {
        static void Main()
        {
            CollegeClassModel circuits = new CollegeClassModel("Circuits 101", 3);
            CollegeClassModel dsp = new CollegeClassModel("DSP 101", 2);

            circuits.EnrollmentFull += CollegeClass_EnrollmentFull;

            circuits.SignUpStudent("Michael Tadyshak").PrintToConsole();
            circuits.SignUpStudent("Ray Pokrandt").PrintToConsole();
            circuits.SignUpStudent("Michael Mellone").PrintToConsole();
            circuits.SignUpStudent("Steve Gilles").PrintToConsole();
            circuits.SignUpStudent("Peter Blockhead").PrintToConsole();
            Console.WriteLine();

            dsp.EnrollmentFull += CollegeClass_EnrollmentFull;

            dsp.SignUpStudent("Michael Tadyshak").PrintToConsole();
            dsp.SignUpStudent("Ray Pokrandt").PrintToConsole();
            dsp.SignUpStudent("Michael Mellone").PrintToConsole();

            Console.ReadLine();
        }

        private static void CollegeClass_EnrollmentFull(object sender, string e)
        {
            CollegeClassModel model = (CollegeClassModel)sender;

            Console.WriteLine();
            Console.WriteLine($"{model.CourseTitle}: Full");
            Console.WriteLine();
        }
    }
}
