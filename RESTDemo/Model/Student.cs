using System .ComponentModel .DataAnnotations;
using System .ComponentModel .DataAnnotations .Schema;

namespace RESTDemo .Model
    {
    [Table("Student")]
    public class Student
        {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public string? Email { get; set; }
        [Required]
        public string? Grade { get; set; }
        }
    }
    
