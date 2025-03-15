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

namespace IndicadoresWeb.Pages_TiposIndicador
{
    public class EditModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public EditModel(IndicadoresWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TipoIndicador TipoIndicador { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoindicador =  await _context.TiposIndicador.FirstOrDefaultAsync(m => m.Id == id);
            if (tipoindicador == null)
            {
                return NotFound();
            }
            TipoIndicador = tipoindicador;
            return Page();
        }

                public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TipoIndicador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoIndicadorExists(TipoIndicador.Id))
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

        private bool TipoIndicadorExists(int id)
        {
            return _context.TiposIndicador.Any(e => e.Id == id);
        }
    }
}
