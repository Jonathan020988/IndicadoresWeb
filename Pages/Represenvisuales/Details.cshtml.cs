using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IndicadoresWeb.Data;
using IndicadoresWeb.Models;

namespace IndicadoresWeb.Pages_Represenvisuales
{
    public class DetailsModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public DetailsModel(IndicadoresWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Represenvisual Represenvisual { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var represenvisual = await _context.RepresenVisuales.FirstOrDefaultAsync(m => m.Id == id);

            if (represenvisual is not null)
            {
                Represenvisual = represenvisual;

                return Page();
            }

            return NotFound();
        }
    }
}
