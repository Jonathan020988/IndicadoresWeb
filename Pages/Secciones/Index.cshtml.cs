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
    public class IndexModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public IndexModel(IndicadoresWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Seccion> Seccion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Seccion = await _context.Secciones.ToListAsync();
        }
    }
}
