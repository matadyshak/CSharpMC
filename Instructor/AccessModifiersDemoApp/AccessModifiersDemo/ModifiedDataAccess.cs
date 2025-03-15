using DemoLibrary;

// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers

namespace AccessModifiersDemo
{
    public class ModifiedDataAccess : DataAccess
    {
        public void GetUnsecureConnectionInfo()
        {
            GetConnectionString();
        }
    }
}
