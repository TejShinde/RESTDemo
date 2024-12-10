using Microsoft .AspNetCore .DataProtection .KeyManagement;
using System .ComponentModel .DataAnnotations;
using System .ComponentModel .DataAnnotations .Schema;
using System .Net;
namespace RESTDemo .Model
{
    [Table("Book")]
    public class Book
    {
     [Key]
     public int BookId {  get; set; }
        [Required]
        public string? BookName { get; set; }
        [Required]

        public string? Author { get; set; }
        [Required]
        public int Price { get; set; }
        }
    }
