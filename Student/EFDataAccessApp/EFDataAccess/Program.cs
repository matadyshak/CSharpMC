using DataAccessLibrary;

namespace EFDataAccess
{
    public static class Program
    {
        static void Main(string[] args)
        {
            EFCrud eFCrud = new EFCrud();

            eFCrud.CreatePhil();
            eFCrud.CreateMickey();
            eFCrud.ReadAllRecords();
            int? idPhil = eFCrud.ReadIdByName("Phil", "Tady");
            int? idMickey = eFCrud.ReadIdByName("Mickey", "Toddy");
            //ReadContact(eFCrud, 3);

            //CreateNewContact(eFCrud);

            //UpdateContact(eFCrud);

            //RemovePhoneNumberFromContact(eFCrud, 1, 1);

            Console.WriteLine("Completed processing");
            Console.ReadLine();
        }


    }
}
