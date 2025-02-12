using System.Globalization;

namespace MethodsReturningData
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
