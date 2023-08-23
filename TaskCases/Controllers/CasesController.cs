using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nest;
using TaskCases.DataAccess.Data;
using TaskCases.DataAccess.Repository.IRepository;
using TaskCases.Models;
using TaskCases.ViewModel;

namespace TaskCases.Controllers
{
    public class CasesController : Controller
    {

        private readonly ICase _case;
        private readonly ISubject _sub;
        private readonly IAccount _acc;
        private readonly IContact _cont;


        public CasesController(ICase Case, ISubject sub, IAccount acc, IContact cont) { _case = Case; _sub = sub; _acc = acc; _cont = cont; }
        public async Task<IActionResult> List()
        {

            List<Case> cases = new List<Case>();
            cases = await _case.GetAll();
            foreach (var item in cases)
            {
                var account1 = await _acc.GetById(item.AccountID);
                var subject1 = await _sub.GetById(item.SubjectID);
                var contact1 = await _cont.GetById(item.ContactID);
                if (account1 != null && subject1 != null && contact1 != null)
                {
                    item.account = account1;
                    item.subject = subject1;
                    item.contact = contact1;
                }
            }
            return View(cases);
        }
        public async Task<IActionResult> Create()
        {
            List<Subject> subjects = await _sub.GetAll();
            List<Account> accounts = await _acc.GetAll();
            List<Contact> contacts = await _cont.GetAll();
            CaseVM productVM = new()
            {
                cases = new(),
                subject = subjects.Select(
                    i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.ID.ToString()
                    }),
                account = accounts.Select(
                   i => new SelectListItem
                   {
                       Text = i.Name,
                       Value = i.ID.ToString()
                   }),
                contact = contacts.Select(
                   i => new SelectListItem
                   {
                       Text = i.Name,
                       Value = i.ID.ToString()
                   }),
            };

            return View(productVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CaseVM vm)
        {
            if (vm != null)
            {
                var accountWithMatchingCustomer = await _acc.GetByName(vm.cases.Customer);
                var contactWithMatchingCustomer = await _cont.GetByName(vm.cases.Customer);
                if (vm.cases.Customer != null)
                {
                    if (accountWithMatchingCustomer != null || contactWithMatchingCustomer != null)
                    {

                        return RedirectToAction(nameof(List));

                    }
                    else
                    {
                        if (ModelState.IsValid)
                        {
                            vm.cases.CaseNumber = $"CAS-{vm.cases.CaseNumber}--K";
                            await _case.Add(vm.cases);
                            return RedirectToAction(nameof(List));
                        }
                        else
                        {
                            return RedirectToAction(nameof(Create));

                        }
                    }
                }

            }
            return RedirectToAction(nameof(Create));
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            Case GetByIDForCase = await _case.GetById(id);
            Subject GetByIDForSubject = await _sub.GetById(GetByIDForCase.SubjectID);
            Account GetByIDForAccount = await _acc.GetById(GetByIDForCase.AccountID);
            Contact GetByIDForContact = await _cont.GetById(GetByIDForCase.ContactID);

            CaseVM vm = new CaseVM()
            {
                cases = GetByIDForCase,
                SubjecttName = GetByIDForSubject.Name,
                accountName = GetByIDForAccount.Name,
                ContactName = GetByIDForContact.Name,
                accountID = GetByIDForCase.AccountID,
                subjectID = GetByIDForCase.SubjectID,
                contactID = GetByIDForCase.ContactID,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CaseVM vm)
        {
            vm.cases.CaseNumber = $"CAS-{vm.cases.CaseNumber}--K";
            vm.cases.AccountID = vm.accountID;
            vm.cases.SubjectID = vm.subjectID;
            vm.cases.ContactID = vm.contactID;
            await _case.Update(vm.cases);

            return RedirectToAction(nameof(List));


        }
    }
}
