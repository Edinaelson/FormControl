using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FormControl.Data;
using FormControl.Models;

namespace FormControl.Pages.Fornecedores
{
    public class CreateModel : PageModel
    {
        private readonly FormControl.Data.ApplicationDbContext _context;

        public CreateModel(FormControl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fornecedor Fornecedor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

          if (!ModelState.IsValid || _context.Fornecedores == null || Fornecedor == null)
            {
                return Page();
            }

            _context.Fornecedores.Add(Fornecedor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
