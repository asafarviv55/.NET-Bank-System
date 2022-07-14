using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.Loans
{
    public class CreateModel : PageModel
    {
        private readonly Bank.Data.BankContext _context;

        public CreateModel(Bank.Data.BankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Loan Loan { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Loans == null || Loan == null)
            {
                return Page();
            }

            _context.Loans.Add(Loan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
