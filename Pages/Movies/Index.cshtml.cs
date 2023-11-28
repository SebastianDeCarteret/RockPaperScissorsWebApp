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
    public class IndexModel : PageModel
    {
        private readonly RockPaperScissorsWebApp.Data.RockPaperScissorsWebAppContext _context;

        public IndexModel(RockPaperScissorsWebApp.Data.RockPaperScissorsWebAppContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
