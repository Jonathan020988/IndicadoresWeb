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

namespace IndicadoresWeb.Pages_UnidadesMedicion
{
    public class EditModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public EditModel(IndicadoresWeb.Data.ApplicationDbContext context)
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

            var unidadmedicion =  await _context.UnidadesMedicion.FirstOrDefaultAsync(m => m.Id == id);
            if (unidadmedicion == null)
            {
                return NotFound();
            }
            UnidadMedicion = unidadmedicion;
            return Page();
        }

  
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UnidadMedicion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadMedicionExists(UnidadMedicion.Id))
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

        private bool UnidadMedicionExists(int id)
        {
            return _context.UnidadesMedicion.Any(e => e.Id == id);
        }
    }
}
