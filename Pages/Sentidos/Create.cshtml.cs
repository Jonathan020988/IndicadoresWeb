using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IndicadoresWeb.Data;
using IndicadoresWeb.Models;

namespace IndicadoresWeb.Pages_Sentidos
{
    public class CreateModel : PageModel
    {
        private readonly IndicadoresWeb.Data.ApplicationDbContext _context;

        public CreateModel(IndicadoresWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sentido Sentido { get; set; } = default!;

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sentidos.Add(Sentido);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
