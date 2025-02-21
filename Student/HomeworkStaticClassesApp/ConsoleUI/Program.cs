namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayData.WelcomeMessage();

            //Intentionally mis-spelled operator as operater to avoid using a reserved keyword
            double x = RequestData.GetDouble("Enter a floating-point value for X: ");
            double y = RequestData.GetDouble("Enter a floating-point value for Y: ");

            string operater = RequestData.GetOperator("Enter operator (+, -, *, /): ");

            double output = CalculateData.Operate(x, operater, y);

            DisplayData.DisplayResult(x, operater, y, output);
        }
    }
}
