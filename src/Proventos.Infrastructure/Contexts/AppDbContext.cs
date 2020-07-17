using Microsoft.EntityFrameworkCore;
using Proventos.Core.Models;

namespace Proventos.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        public DbSet<Provento> Provento { get; set; }
        public DbSet<CotacaoPorLoteMil> CotacaoPorLoteMil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}