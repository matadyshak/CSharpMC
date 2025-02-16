using System.Globalization;

namespace HomeworkMethodGreeter
{
    public static class StringConversions
    {
        public static string ConvertToTitleCase(string mixedCase)
        {
            mixedCase = mixedCase.Trim();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string titleCase = textInfo.ToTitleCase(mixedCase.ToLower());

            return titleCase;
        }
    }
}
