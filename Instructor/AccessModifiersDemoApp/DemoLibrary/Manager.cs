namespace DemoLibrary
{
    public class Manager : Employee
    {
        public string GetAllNames()
        {
            return $"{ FirstName }, { LastName }, { formerLastName }";
        }
    }
}
