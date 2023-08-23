using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskCases.Models
{
    public class Contact
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }

       


    }
}
    