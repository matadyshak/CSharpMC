using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ClassLibraryDemo
{
    public class DataAccess<T> where T : new()
    {
        public event EventHandler<T> BadEntryFound;
        public event EventHandler<T> FileNotFoundOrEmpty;
        //public event EventHandler<T> ColumnNotFound;
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
        public List<T> LoadFromCSVFile(string filePath)
        {
            List<T> Items = new List<T>();

            try
            {
                // Without the catch blocks this will cause an unhandled exception
                string[] lines = File.ReadAllLines(filePath);

                // In case of file not found the below lines will be skipped over
                // HeaderRow is never checked to see if it matches the property names of T
                string[] HeaderRow = lines[0].Split(',');

                // Additions could be done to handle missing columns, extra columns, re-arranged columns, etc.

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');

                    //Use reflection to get the properties of T
                    T entry = new T();
                    var properties = entry.GetType().GetProperties();

                    // properties.Length should equal values.Length
                    for (int j = 0; j < properties.Length && j < values.Length; j++)
                    {
                        PropertyInfo prop = properties[j];
                        // Initially entry is null null null
                        if (prop.CanWrite)
                        {
                            // This sets the three properties of entry to the values[j]
                            prop.SetValue(entry, Convert.ChangeType(values[j], prop.PropertyType));
                        }
                    }
                    Items.Add(entry);
                }
            }
            catch (IOException e)
            {
                FileNotFoundOrEmpty?.Invoke(this, new T());
            }
            catch (Exception e)
            {
                FileNotFoundOrEmpty?.Invoke(this, new T());
            }

            return Items;
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
