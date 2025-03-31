using System;
using System.Collections.Generic;
using System.IO;

namespace WrapUpDemo
{
    public class DataAccess<T> where T : new()
    {
        public event EventHandler<T> BadEntryFound;

        public void SaveToCSV(List<T> items, string filePath)
        {
            List<string> rows = new List<string>();
            T entry = new T();
            // GetType: PersonModel or CarModel
            var type = entry.GetType();
            // GetProperties: FirstName, LastName, Email

            var cols = type.GetProperties();

            string row = "";
            foreach (var col in cols)
            {
                // FirstName,...
                row += $",{col.Name}";
            }
            row = row.Substring(1);
            // "FirstName","LastName", "Email"
            rows.Add(row);

            foreach (var item in items)
            {
                row = "";
                bool badWordDetected = false;

                foreach (var col in cols)
                {
                    //string val = col.GetValue(item, null).ToString();
                    var temp = col.GetValue(item, null);
                    string val = temp.ToString();

                    badWordDetected = BadWordDetector(val);
                    if (badWordDetected == true)
                    {
                        BadEntryFound?.Invoke(this, item);
                        break;
                    }

                    row += $",{val}";
                }

                if (badWordDetected == false)
                {
                    row = row.Substring(1);
                    rows.Add(row);
                }
            }

            File.WriteAllLines(filePath, rows);
        }

        private bool BadWordDetector(string stringToTest)
        {
            bool output = false;
            string lowerCaseTest = stringToTest.ToLower();

            if (lowerCaseTest.Contains("darn") || lowerCaseTest.Contains("heck"))
            {
                output = true;
            }

            return output;
        }
    }
}
