using System.ComponentModel.DataAnnotations;

namespace seminar_1.Data.DTO
{
    public class StudentDto
    {
        [Required]
        public string _id { get; set; }

        [Required]
        public string about { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
    }
}
