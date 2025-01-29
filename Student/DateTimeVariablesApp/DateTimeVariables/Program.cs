using System.Collections.Specialized;
using System.Globalization;

namespace DateTimeVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCommon Date / Time formats: ");
            DateTime now = DateTime.Now;
            //No leading 0's
            Console.WriteLine(now.ToString("M-d-y h:m:s tt"));                // 1-28-25 8:41:9 PM
            //Leading 0's
            Console.WriteLine(now.ToString("MM-dd-yy hh:mm:ss tt"));          // 01-28-25 08:41:09 PM
            //Day and month abbreviated + 24 hour time
            Console.WriteLine(now.ToString("ddd MMM dd, yyyy H:mm:ss"));      // Tue Jan 28, 2025 20:41:09
            //Day and month full + 24 hour time
            Console.WriteLine(now.ToString("dddd MMMM dd, yyyy HH:mm:ss"));   // Tuesday January 28, 2025 20:41:09
            //Day-month-year with AM/PM and UTC offset
            Console.WriteLine(now.ToString("dd-MM-yy hh:mm:ss tt zzz"));      // 28-01-25 08:41:09 PM -06:00


            Console.WriteLine("\nPrint local, Utc and unspecified kinds of DateTime objects: ");
            DateTime localTime = DateTime.Now;
            Console.WriteLine(localTime.Kind);                                 // Output: Local
            DateTime utcTime = DateTime.UtcNow;
            Console.WriteLine(utcTime.Kind);                                   // Output: Utc
            DateTime unspecifiedTime = new DateTime(2025, 1, 28);
            Console.WriteLine(unspecifiedTime.Kind);                           // Output: Unspecified


            Console.WriteLine("\nPrint utcTime using String.Format: ");
            //No leading 0's
            Console.WriteLine(String.Format("{0:M-d-y h:m:s tt}", utcTime));                // 1-28-25 8:41:9 PM
            //Leading 0's
            Console.WriteLine(String.Format("{0:MM-dd-yy hh:mm:ss tt}", utcTime));          // 01-28-25 08:41:09 PM
            //Day and month abbreviated + 24 hour time
            Console.WriteLine(String.Format("{0:ddd MMM dd, yyyy H:mm:ss}", utcTime));      // Tue Jan 28, 2025 20:41:09
            //Day and month full + 24 hour time
            Console.WriteLine(String.Format("{0:dddd MMMM dd, yyyy HH:mm:ss}", utcTime));   // Tuesday January 28, 2025 20:41:09
            //Day-month-year with AM/PM and UTC offset
            Console.WriteLine(String.Format("{0:dd-MM-yy hh:mm:ss tt zzz}", utcTime));      // 28-01-25 08:41:09 PM -06:00

            Console.WriteLine("\nConvert day-month-year to month-day-year using ParseExact");
            string dateString = "23 October 1962";
            DateTime date = DateTime.ParseExact(dateString, "dd MMMM yyyy", null);
            Console.WriteLine(date.ToString("MMMM dd, yyyy"));

            Console.WriteLine("\nUse CultureInfo for Localization to display time in France in French language: ");
            DateTime nowInFrance = DateTime.Now;
            CultureInfo culture = new CultureInfo("fr-FR");
            Console.WriteLine(nowInFrance.ToString("D", culture));   // mardi janvier 28, 2025 20:41:09  "D" is a long date pattern


        }
    }
}
