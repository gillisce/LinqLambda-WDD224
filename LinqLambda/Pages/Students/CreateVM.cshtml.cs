using LinqLambda.Models;
using LinqLambda.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace LinqLambda.Pages.Students
{
    public class CreateVMModel : PageModel
    {
        private readonly LinqLambda.Data.SchoolContext _context;

        public CreateVMModel(LinqLambda.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            StudentVM = new StudentVM
            {
                EnrollmentDate = DateTime.Now,
                FirstMidName = "Joe VM",
                LastName = "Smith VM"
            };
            return Page();
        }
        #region snippet
        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        #endregion
    }
}
