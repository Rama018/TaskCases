using System.ComponentModel.DataAnnotations;

namespace TaskCases.Models
{
    public class Account
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }

    
    }
}
