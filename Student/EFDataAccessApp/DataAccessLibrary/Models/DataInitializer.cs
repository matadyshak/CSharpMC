namespace DataAccessLibrary.Models
{
    public class DataInitializer
    {
        public List<Person> GetPersonData()
        {
            return PersonData;
        }

        public List<Person> PersonData = new List<Person>
        {
            new Person
            {
                FirstName = "Philip",
                LastName = "TaddyGreatGrandDaddy",
                Addresses = new List<Address>
                {
                    new Address { Street = "2564 N Fratney Street", City = "Milwaukee", State = "WI", ZipCode = "53212" },
                    new Address { Street = "2045 W Neil Place", City = "Milwaukee", State = "WI", ZipCode = "53209" }
                },
                Employers = new List<Employer>
                {
                    new Employer { CompanyName = "Pulp Reproduction" },
                    new Employer { CompanyName = "SquareD" }
                }
            },
            new Person
            {
                FirstName = "Arlene",
                LastName = "TaddyGreatGrandMommy",
                Addresses = new List<Address>
                {
                    new Address { Street = "2579 N Pierce Street", City = "Milwaukee", State = "WI", ZipCode = "53212" },
                    new Address { Street = "2045 W Neil Place", City = "Milwaukee", State = "WI", ZipCode = "53209" }
                },
                Employers = new List<Employer>
                {
                    new Employer { CompanyName = "Wisconsin Gas Company" },
                    new Employer { CompanyName = "St. Michael Hospital" }
                }
            },
            new Person
            {
                FirstName = "Michael",
                LastName = "TaddyGrandDaddy",
                Addresses = new List<Address>
                {
                    new Address { Street = "2045 W Neil Place", City = "Milwaukee", State = "WI", ZipCode = "53209" },
                    new Address { Street = "2005 High Summit", City = "Garland", State = "TX", ZipCode = "75041" }
                },
                Employers = new List<Employer>
                {
                    new Employer { CompanyName = "Bobby's Place" },
                    new Employer { CompanyName = "Jewel Foods" },
                    new Employer { CompanyName = "Texas Instruments" }
                }
            },
            new Person
            {
                FirstName = "Thomas",
                LastName = "TaddyGrandUncle",
                Addresses = new List<Address>
                {
                    new Address { Street = "1200 Dixon Street", City = "Stevens Point", State = "WI", ZipCode = "53100" },
                    new Address { Street = "1631 Astor Street", City = "Milwaukee", State = "WI", ZipCode = "75041" }
                },
                Employers = new List<Employer>
                {
                    new Employer { CompanyName = "St Nicolas Catholic Church" },
                    new Employer { CompanyName = "St Michael Hospital" }
                }
            },
            new Person
            {
                FirstName = "Gregory",
                LastName = "TaddyGrandUncle",
                Addresses = new List<Address>
                {
                    new Address { Street = "2022 Patty Lane", City = "Green Bay", State = "WI", ZipCode = "54315" },
                    new Address { Street = "1620 North Road", City = "Ashwaubenon", State = "WI", ZipCode = "54313" }
                },
                Employers = new List<Employer>
                {
                    new Employer { CompanyName = "WBAY TV" },
                    new Employer { CompanyName = "UWGB" }
                }
            }
        };
    }
}
