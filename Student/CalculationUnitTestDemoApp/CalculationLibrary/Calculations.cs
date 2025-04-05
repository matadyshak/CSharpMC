namespace CalculationLibrary
{
    public class Calculations
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Divide(double x, double y)
        {
            double output = 0.0d;

            if (y == 0.0d)
            {
                return 0;
            }

            output = x / y;

            return output;
        }
    }
}