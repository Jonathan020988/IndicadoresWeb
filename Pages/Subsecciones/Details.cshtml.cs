using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IndicadoresWeb.Data;
using IndicadoresWeb.Models;

namespace IndicadoresWeb.Pages_Subsecciones
{
    public class DetailsModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public DetailsModel(IndicadoresWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Subseccion Subseccion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subseccion = await _context.Subsecciones.FirstOrDefaultAsync(m => m.Id == id);

            if (subseccion is not null)
            {
                Subseccion = subseccion;

                return Page();
            }

            return NotFound();
        }
    }
}
