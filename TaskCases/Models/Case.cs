using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TaskCases.Models
{
    public class Case
    {
        public Guid ID { get; set; } 

        public string Name { get; set; }

        public string Owner { get; set; }

        public string CaseNumber { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime ModifideOn { get; set; } = DateTime.Now;

        public Guid SubjectID { get; set; }
        [ValidateNever]

        public Subject subject { get; set; }
        public Guid ContactID { get; set; }
        [ValidateNever]
        public Contact contact { get; set; }

        public Guid AccountID { get; set; }
        [ValidateNever]
        public Account account { get; set; }

        public string Customer { get; set; }


    }
}
