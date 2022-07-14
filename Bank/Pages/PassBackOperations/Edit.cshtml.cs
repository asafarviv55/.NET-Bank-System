using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.PassBackOperations
{
    public class EditModel : PageModel
    {
        private readonly Bank.Data.BankContext _context;

        public EditModel(Bank.Data.BankContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PassBackOperation PassBackOperation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PassBackOperations == null)
            {
                return NotFound();
            }

            var passbackoperation =  await _context.PassBackOperations.FirstOrDefaultAsync(m => m.id == id);
            if (passbackoperation == null)
            {
                return NotFound();
            }
            PassBackOperation = passbackoperation;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PassBackOperation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassBackOperationExists(PassBackOperation.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PassBackOperationExists(int id)
        {
          return (_context.PassBackOperations?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
