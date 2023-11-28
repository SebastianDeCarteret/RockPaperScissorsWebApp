using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RockPaperScissorsWebApp.Data;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly RockPaperScissorsWebApp.Data.RockPaperScissorsWebAppContext _context;

        public DetailsModel(RockPaperScissorsWebApp.Data.RockPaperScissorsWebAppContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
