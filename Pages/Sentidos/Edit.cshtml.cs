using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndicadoresWeb.Data;
using IndicadoresWeb.Models;

namespace IndicadoresWeb.Pages_Sentidos
{
    public class EditModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public EditModel(IndicadoresWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sentido Sentido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sentido =  await _context.Sentidos.FirstOrDefaultAsync(m => m.Id == id);
            if (sentido == null)
            {
                return NotFound();
            }
            Sentido = sentido;
            return Page();
        }

          public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sentido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SentidoExists(Sentido.Id))
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

        private bool SentidoExists(int id)
        {
            return _context.Sentidos.Any(e => e.Id == id);
        }
    }
}
