using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormControl.Data;
using FormControl.Models;

namespace FormControl.Pages.Produtos
{
    public class DetailsModel : PageModel
    {
        private readonly FormControl.Data.ApplicationDbContext _context;

        public DetailsModel(FormControl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Produto Produto { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            else 
            {
                Produto = produto;
            }
            return Page();
        }
    }
}
