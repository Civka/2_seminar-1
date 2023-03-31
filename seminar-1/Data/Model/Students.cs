using System.ComponentModel.DataAnnotations;

namespace seminar_1.Data.Model
{
    public class Students
    {
        // po změně ve třídě student, vždy udělat add-migration a update-database
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ExternalId { get; set; }


    }
}
