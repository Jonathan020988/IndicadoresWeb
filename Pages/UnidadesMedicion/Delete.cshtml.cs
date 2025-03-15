using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IndicadoresWeb.Data;
using IndicadoresWeb.Models;

namespace IndicadoresWeb.Pages_UnidadesMedicion
{
    public class DeleteModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public DeleteModel(IndicadoresWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UnidadMedicion UnidadMedicion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadmedicion = await _context.UnidadesMedicion.FirstOrDefaultAsync(m => m.Id == id);

            if (unidadmedicion is not null)
            {
                UnidadMedicion = unidadmedicion;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadmedicion = await _context.UnidadesMedicion.FindAsync(id);
            if (unidadmedicion != null)
            {
                UnidadMedicion = unidadmedicion;
                _context.UnidadesMedicion.Remove(UnidadMedicion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
