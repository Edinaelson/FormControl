using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FormControl.Data;
using FormControl.Models;
using static System.Net.Mime.MediaTypeNames;
using CsvHelper;
using System.Globalization;

namespace FormControl.Pages.Fornecedores
{
    public class DetailsModel : PageModel
    {
        private readonly FormControl.Data.ApplicationDbContext _context;

        public DetailsModel(FormControl.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Fornecedor Fornecedor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Fornecedores == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            else 
            {
                Fornecedor = fornecedor;
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(IFormFile Csv)
        {
            /* var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/archives/clients");
            var nomeArquivo = Path.GetFileName(Csv.FileName);
            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            if (!Directory.Exists(caminhoPasta))
            {
                Directory.CreateDirectory(caminhoPasta);
            } */

            //using var stream = new FileStream(caminhoCompleto, FileMode.Create);

            using var reader = new StreamReader(Csv.OpenReadStream());

            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            
            var records = csv.GetRecords<Foo>().ToList();

           return new JsonResult(records);
        }

    }

   
}
