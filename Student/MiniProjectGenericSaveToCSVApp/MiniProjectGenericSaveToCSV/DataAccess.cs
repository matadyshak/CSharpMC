using System;
using System.Collections.Generic;
using System.IO;

namespace MiniProjectGenericSaveToCSV
{
    public class DataAccess<T> where T : new()
    {
        public event EventHandler<T> BadEntryFound;
        public void SaveToCSVFile(List<T> items, string filePath)
        {
            string val = "";

            List<string> rows = new List<string>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            // create header row
            string row = "";
            foreach (var col in cols)
            {
                row += $",{col.Name}";
            }
            row = row.Substring(1);
            rows.Add(row);

            // create data rows
            foreach (var item in items)
            {
                row = "";
                bool badWordDetected = false;

                foreach (var col in cols)
                {
                    // For each of the properties in item
                    val = col.GetValue(item, null).ToString();
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

        public bool BadWordDetector(string input)
        {
            bool output = false;
            string lowerCaseInput = input.ToLower();

            if (lowerCaseInput.Contains("darn") || lowerCaseInput.Contains("heck"))
            {
                output = true;
            }

            return output;
        }
    }
}
