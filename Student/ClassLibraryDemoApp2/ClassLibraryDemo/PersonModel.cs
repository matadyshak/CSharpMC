namespace ClassLibraryDemo
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Print()
        {
            return $"{FirstName} {LastName} {Email}";
        }
    }
}
