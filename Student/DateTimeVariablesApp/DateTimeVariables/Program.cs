using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DateTimeVariables
{
    internal class Program
    {
        static void Main()
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
            Console.WriteLine(String.Format("{0:M-d-y h:m:s tt}", utcTime));                // 1-29-25 2:41:9 AM
            //Leading 0's
            Console.WriteLine(String.Format("{0:MM-dd-yy hh:mm:ss tt}", utcTime));          // 01-29-25 02:41:09 AM
            //Day and month abbreviated + 24 hour time
            Console.WriteLine(String.Format("{0:ddd MMM dd, yyyy H:mm:ss}", utcTime));      // Wed Jan 29, 2025 02:41:09
            //Day and month full + 24 hour time
            Console.WriteLine(String.Format("{0:dddd MMMM dd, yyyy HH:mm:ss}", utcTime));   // Wednesday January 29, 2025 02:41:09
            //Day-month-year with AM/PM and UTC offset
            Console.WriteLine(String.Format("{0:dd-MM-yy hh:mm:ss tt zzz}", utcTime));      // 29-01-25 02:41:09 PM -00:00

            Console.WriteLine("\nConvert day-month-year to month-day-year using ParseExact");
            string dateString = "23 October 1962";
            DateTime date = DateTime.ParseExact(dateString, "dd MMMM yyyy", null);          
            Console.WriteLine(date.ToString("MMMM dd, yyyy"));                              // October 23, 1962

            Console.WriteLine("\nUse CultureInfo for Localization to display time in France in French language: ");
            DateTime nowInFrance = DateTime.Now;
            CultureInfo culture = new CultureInfo("fr-FR");
            Console.WriteLine(nowInFrance.ToString("D", culture));   // mardi janvier 28, 2025 20:41:09  "D" is default format for the culture

            Console.WriteLine("\nTest addition and subtraction of DateTime objects.");
	        DateTime birth = new DateTime(1962, 10, 23, 3, 0, 0);     // 1962-10-23 03:00:00
	        Console.WriteLine(birth.ToString("dddd MMMM dd, yyyy hh:mm:ss tt"));   //Tuesday October 23, 1962 03:00:00 AM

            DateTime baptism = birth.AddDays(19).AddHours(9).AddMinutes(23);
	        Console.WriteLine(baptism.ToString("dddd MMMM dd, yyyy hh:mm:ss tt"));   //Sunday November 11, 1962 12:23 PM

            //Constructors
            DateTime dt1 = new DateTime();
	        Console.WriteLine(dt1.ToString("dddd MMMM dd, yyyy hh:mm:ss tt"));   //Monday January 01, 0001 00:00:00 AM

            long ticks = 637678912000000000L;
            DateTime dt2 = new DateTime(ticks);
	        Console.WriteLine(dt2.ToString("dddd MMMM dd, yyyy hh:mm:ss tt"));   // Wednesday September 22, 2021 07:06:40 AM

            // Year, month, date
            DateTime dt3 = new DateTime(1952, 5, 19);
	        Console.WriteLine(dt3.ToString("dddd MMMM dd, yyyy hh:mm:ss tt"));   //Tuesday May 19, 1952 00:00:00 AM
          
	        //Year, Month, Day, Hour, Minute, Second Constructor:
            DateTime dt4 = new DateTime(1952, 5, 19, 15, 5, 55);
	        Console.WriteLine(dt4.ToString("dddd MMMM dd, yyyy hh:mm:ss tt"));   //Tuesday May 19, 1952 15:05:55 AM
          
            // Year, Month, Day, Hour, Minute, Second, Millisecond Constructor:
            DateTime dt5 = new DateTime(1952, 5, 19, 15, 5, 55, 333);
	        Console.WriteLine(dt5.ToString("dddd MMMM dd, yyyy hh:mm:ss fff"));   //Tuesday May 19, 1952 15:05:55 333


	        // Difference between two dates
            TimeSpan difference = baptism - birth;
            int days = difference.Days;
            int hours = difference.Hours;
            int minutes = difference.Minutes;
            Console.WriteLine($"Birth to baptism is {days} days, {hours} hours, {minutes} minutes");
  
            // Comparison of dates / times
            Console.WriteLine($"Equal: {birth==baptism}, Not equal: {birth!=baptism}, Earlier: {birth < baptism}, Later: {birth > baptism}");
	    
            DateTime utcTime2 = DateTime.UtcNow;
            DateTime localTime2 = utcTime2.ToLocalTime(); // Convert UTC to local time

            DateTime localTime3 = DateTime.Now;
            DateTime utcTime3 = localTime3.ToUniversalTime(); // Convert local time to UTC

            // Using TimeZoneInfo for Specific Time Zones
            DateTime utcTimeNow = DateTime.UtcNow;
            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime estTime = TimeZoneInfo.ConvertTimeFromUtc(utcTimeNow, estZone); // Convert UTC to EST
            Console.WriteLine(String.Format("UTC: {0:dddd MMMM dd, yyyy hh:mm:ss tt}", utcTimeNow));
            Console.WriteLine(String.Format("EST: {0:dddd MMMM dd, yyyy hh:mm:ss tt}", estTime));

            //PrintSystemTimeZones();
        }

        static void PrintSystemTimeZones()
        {
            ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
        
            foreach (TimeZoneInfo timeZone in timeZones)
            {
                Console.WriteLine($"ID: {timeZone.Id}");
                Console.WriteLine($"Display Name: {timeZone.DisplayName}");
                Console.WriteLine($"Standard Name: {timeZone.StandardName}");
                Console.WriteLine($"Daylight Name: {timeZone.DaylightName}");
                Console.WriteLine($"Base UTC Offset: {timeZone.BaseUtcOffset}");
                Console.WriteLine();
            }
            return;
        }
    }
}
