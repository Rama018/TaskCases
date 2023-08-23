using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskCases.Models;

namespace TaskCases.ViewModel
{
    public class CaseVM
    {
        public Case cases { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> subject { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> account { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> contact { get; set; }


        [ValidateNever]

        public string accountName { get; set; }
        [ValidateNever]
        public string SubjecttName { get; set; }

        [ValidateNever]
        public string ContactName { get; set; }

        public Guid accountID { get; set; }
        public Guid contactID { get; set; }
        public Guid subjectID { get; set; }

    }

}
