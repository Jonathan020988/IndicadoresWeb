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

namespace IndicadoresWeb.Pages_Secciones
{
    public class EditModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public EditModel(IndicadoresWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Seccion Seccion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seccion =  await _context.Secciones.FirstOrDefaultAsync(m => m.Id == id);
            if (seccion == null)
            {
                return NotFound();
            }
            Seccion = seccion;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Seccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeccionExists(Seccion.Id))
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

        private bool SeccionExists(string id)
        {
            return _context.Secciones.Any(e => e.Id == id);
        }
    }
}
