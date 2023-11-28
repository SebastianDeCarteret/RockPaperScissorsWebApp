using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RockPaperScissorsWebApp.Models;

namespace RockPaperScissorsWebApp.Data
{
    public class RockPaperScissorsWebAppContext : DbContext
    {
        public RockPaperScissorsWebAppContext (DbContextOptions<RockPaperScissorsWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<RockPaperScissorsWebApp.Models.Movie> Movie { get; set; } = default!;
    }
}
