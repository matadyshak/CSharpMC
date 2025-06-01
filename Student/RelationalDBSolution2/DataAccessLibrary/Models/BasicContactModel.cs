namespace SQLServerUI.Models
{
    public class BasicContactModel
    {
        public int Id { get; set; }

        //These annotations work with Entity Framework but are ignored by Dapper
        // [Column("GivenName")]
        public string? FirstName { get; set; }

        // [Column("SurName")]
        public string? LastName { get; set; }
    }
}
