using System.ComponentModel.DataAnnotations;

namespace seminar_1.Data.Model
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string School { get; set; }
    }
}
