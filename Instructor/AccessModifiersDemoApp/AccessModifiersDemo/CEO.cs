using DemoLibrary;

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers

namespace AccessModifiersDemo
{
    public class CEO : Manager
    {
        public void GetConnectionInfo()
        {
            ModifiedDataAccess data = new ModifiedDataAccess();
            data.GetUnsecureConnectionInfo();

            formerLastName = "test";
        }
    }
}
