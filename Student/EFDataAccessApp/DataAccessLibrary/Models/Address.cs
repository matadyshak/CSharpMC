using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
    public class Address
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }  // Foreign key to Person

        [Required]
        public Person Person { get; set; } // Navigation property

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }
    }
}

//What is a Navigation Property?
//In EF Core, a navigation property allows you to traverse relationships between entities.
// So when you add this to your Employer class:

// public Person Person { get; set; }

//You're saying: "An employer is associated with one Person — and I want EF to understand this 
// relationship and allow me to access that person from this employer."

// The type is Person — the class you're referring to.
// The property name is also Person — it’s the identifier you'll use in code (employer.Person).

// You can access the related person like:
// var employer = db.EmployerTable.Include(e => e.Person).FirstOrDefault();
//Console.WriteLine(employer.Person.FirstName);

//You make the relationship bidirectional if Person also has:
// public Employer Employer { get; set; }

//EF can automatically map foreign keys like PersonId in Employer if present, or you can explicitly define it:
// public int PersonId { get; set; }
//[ForeignKey("PersonId")]
//public Person Person { get; set; }