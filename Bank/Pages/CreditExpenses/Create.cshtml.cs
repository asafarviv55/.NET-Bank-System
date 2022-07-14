using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.CreditExpenses
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
        public CreditExpense CreditExpense { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CreditExpenses == null || CreditExpense == null)
            {
                return Page();
            }

            _context.CreditExpenses.Add(CreditExpense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
