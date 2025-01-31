using System.Globalization;

namespace DateOnlyVariables
{
    internal class Program
    {
        static void Main()
        {
            DateTime todayDT = DateTime.Now;
            Console.WriteLine(String.Format("{0:MM-dd-yy hh:mm:ss tt}", todayDT));
            // Still a date and time with time set to 12:00:00 AM
            Console.WriteLine(String.Format("{0:MM-dd-yy hh:mm:ss tt}", todayDT.Date)); 

            DateOnly today = DateOnly.FromDateTime(todayDT);
            //Console.WriteLine(String.Format("{0:MM-dd-yy hh:mm:ss tt}", today));
            Console.WriteLine(String.Format("{0:MM-dd-yy}", today));

            DateOnly tomorrow = today.AddDays(1);
            Console.WriteLine(String.Format("{0:MM-dd-yy}", tomorrow));

            DateOnly yesterday = today.AddDays(-1);
            Console.WriteLine(String.Format("{0:MM-dd-yy}", yesterday));

            DateOnly birthday = new DateOnly(1962, 10, 23);
            //Console.WriteLine(String.Format("{0:MM-dd-yy hh:mm:ss tt}", birthday));
            Console.WriteLine(String.Format("{0:MM-dd-yy}", birthday));

            string dateString = "23 October 1962";
            DateOnly date = DateOnly.ParseExact(dateString, "dd MMMM yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.ToString("MMMM dd, yyyy"));

            // Not supported
            // DateOnly dt1 = new DateOnly(ticks);
        }
    }
}
