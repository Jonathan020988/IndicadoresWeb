using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IndicadoresWeb.Data;
using IndicadoresWeb.Models;

namespace IndicadoresWeb.Pages_Secciones
{
    public class DeleteModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public DeleteModel(IndicadoresWeb.Data.ApplicationDbContext context)
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

            var seccion = await _context.Secciones.FirstOrDefaultAsync(m => m.Id == id);

            if (seccion is not null)
            {
                Seccion = seccion;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seccion = await _context.Secciones.FindAsync(id);
            if (seccion != null)
            {
                Seccion = seccion;
                _context.Secciones.Remove(Seccion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
