namespace MethodOverrideDemo
{
    public class EmployeeModel : PersonModel
    {
        public decimal HourlyRate { get; set; }

        public virtual decimal GetPaycheckAmount(int hoursWorked)
        {
            return HourlyRate * hoursWorked;
        }
    }
}
