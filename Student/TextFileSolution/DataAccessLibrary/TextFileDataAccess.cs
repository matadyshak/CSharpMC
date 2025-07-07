using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class TextFileDataAccess
    {
        public List<ContactModel> ReadAllRecords(string textFile)
        {
            if (File.Exists(textFile) == false)
            {
                return new List<ContactModel>(); // Return empty list if file does not exist
            }

            //Read file into an array of strings, where each string is a line in the file
            var lines = File.ReadAllLines(textFile);

            List<ContactModel> output = new List<ContactModel>();

            //foreach (var line in lines)
            //{
            //    var parts = line.Split(',');
            //    if (parts.Length < 2) continue; // Skip invalid lines
            //    ContactModel contact = new ContactModel
            //    {
            //        FirstName = parts[0].Trim(),
            //        LastName = parts[1].Trim()
            //    };
            //    if (parts.Length > 2)
            //    {
            //        contact.EmailAddresses = parts[2].Split(';').Select(e => e.Trim()).ToList();
            //    }
            //    if (parts.Length > 3)
            //    {
            //        contact.PhoneNumbers = parts[3].Split(';').Select(p => p.Trim()).ToList();
            //    }
            //    yield return contact;
            //}

            foreach (var line in lines)
            {
                ContactModel c = new ContactModel();
                // Gets an array of strings, where each string is a part of the line split by commas
                var values = line.Split(',');
                if (values.Length < 4)
                {
                    throw new Exception($"Invalid row of data: {line}");
                }

                c.FirstName = values[0].Trim();
                c.LastName = values[1].Trim();
                // Convert array of strings to a list of strings
                c.EmailAddresses = values[2].Split(';').ToList();
                c.PhoneNumbers = values[3].Split(';').ToList();

                output.Add(c);
            }

            return output;

            //List<ContactModel> contacts = new List<ContactModel>();
            //if (!File.Exists(filePath))
            //{
            //    return contacts; // Return empty list if file does not exist
            //}
            //var lines = File.ReadAllLines(filePath);
            //foreach (var line in lines)
            //{
            //    var parts = line.Split(',');
            //    if (parts.Length < 2) continue; // Skip invalid lines
            //    ContactModel contact = new ContactModel
            //    {
            //        FirstName = parts[0].Trim(),
            //        LastName = parts[1].Trim()
            //    };
            //    for (int i = 2; i < parts.Length; i++)
            //    {
            //        if (parts[i].StartsWith("Phone:"))
            //        {
            //            contact.PhoneNumbers.Add(parts[i].Substring(6).Trim());
            //        }
            //        else if (parts[i].StartsWith("Email:"))
            //        {
            //            contact.EmailAddresses.Add(parts[i].Substring(6).Trim());
            //        }
            //    }
            //    contacts.Add(contact);
            //}
            //return contacts;
            //

        }

        public void WriteAllRecords(List<ContactModel> contacts, string textFile)
        {
            List<string> lines = new List<string>();

            foreach (var c in contacts)
            {
                lines.Add($"{c.FirstName},{c.LastName},{String.Join(';', c.EmailAddresses)},{String.Join(';', c.PhoneNumbers)}");
            }

            //Not necessary
            //if (!File.Exists(textFile))
            //{
            //    File.Create(textFile).Close(); // Create the file if it does not exist
            //}

            File.WriteAllLines(textFile, lines);
        }
    }
}
