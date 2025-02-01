namespace TimeOnlyVariables
{
    internal class Program
    {
        static void Main()
        {
            // Hours, Minutes
            TimeOnly timeHourMin = new TimeOnly(3, 15);
            PrintAllTimeFormats(timeHourMin);

            //24-Hour, minute, second
            TimeOnly timeHourMinSec = new TimeOnly(20, 15, 33);
            PrintAllTimeFormats(timeHourMinSec);

            //24-Hour, minute, second, millisecond
            TimeOnly timeMilliSec = new TimeOnly(20, 15, 33, 456);
            PrintAllTimeFormats(timeMilliSec);

            // Initializes a new instance of the TimeOnly structure to a specified number of ticks since midnight.
            // 100 ns tick = 10**-7 // 1 sec = 10,000,000 = 0x989680 ticks // 24 hours = 24 hours * 60 min * 60 sec = 86400 sec 
            // = 864 Billion ticks = 0xC9 2A69 C000 TICKS
            // One second before midnight = C9 2A69 C000 - 989680 = 864000000000 - 10000000 = 863990000000

            TimeOnly timeTicks = new TimeOnly(863990000000L);
            PrintAllTimeFormats(timeTicks);

            // Initializes a new instance of the TimeOnly structure to a specified TimeSpan value.
            TimeSpan timeSpan = timeHourMinSec - timeHourMin;
            TimeOnly timeOnly = TimeOnly.FromTimeSpan(timeSpan);
            PrintAllTimeFormats(timeOnly);

            TimeOnly opensAt = TimeOnly.Parse("8:00 AM");
            PrintAllTimeFormats(opensAt);

            // Get TimeOnly from a DateTime
            DateTime now = DateTime.Now;
            TimeOnly localNow = TimeOnly.FromDateTime(now);
            PrintAllTimeFormats(localNow);

            DateTime utcNow = DateTime.UtcNow;
            TimeOnly utcNowTime = TimeOnly.FromDateTime(utcNow);
            PrintAllTimeFormats(utcNowTime);
        }

        static void PrintAllTimeFormats(TimeOnly time1)
        {
            //Short time format
            Console.WriteLine(time1.ToString("t"));
            //Long time format
            Console.WriteLine(time1.ToString("T"));
            //Round trip format
            Console.WriteLine(time1.ToString("o"));
            //RFC1123
            Console.WriteLine(time1.ToString("r"));
            //Hours, minutes AM/PM
            Console.WriteLine(time1.ToString("hh:mm tt"));
            //Hours, minutes, seconds AM/PM
            Console.WriteLine(time1.ToString("hh:mm:ss tt"));
            //12-hour, minutes, seconds, milliseconds, AM/PM
            Console.WriteLine(time1.ToString("hh:mm:ss.fff tt"));
            //24-hour, minutes, seconds
            Console.WriteLine(time1.ToString("HH:mm:ss"));
            //24-hour, minutes, seconds, milliseconds
            Console.WriteLine(time1.ToString("HH:mm:ss.fff"));
            Console.WriteLine("\n");
        }
    }
}
