using System .ComponentModel .DataAnnotations;
using System .ComponentModel .DataAnnotations .Schema;

namespace RESTDemo .Model
    {
    [Table("User1")]
    public class User
        {
        [Key]
        public int UserId { get; set; }

        [Required] 
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
        }
    }
