using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bank.Data;
using Bank.Models;

namespace Bank.Pages.UsersAuths
{
    public class DetailsModel : PageModel
    {
        private readonly Bank.Data.BankContext _context;

        public DetailsModel(Bank.Data.BankContext context)
        {
            _context = context;
        }

      public UsersAuth UsersAuth { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UsersAuths == null)
            {
                return NotFound();
            }

            var usersauth = await _context.UsersAuths.FirstOrDefaultAsync(m => m.id == id);
            if (usersauth == null)
            {
                return NotFound();
            }
            else 
            {
                UsersAuth = usersauth;
            }
            return Page();
        }
    }
}
