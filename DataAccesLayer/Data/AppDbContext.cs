using DataAccesLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DbSet<Beneficiario> Beneficiario { get; set; }
        public DbSet<Ordenante> Ordenante { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //desactIvamos el output para que funcione nuestro trigger
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pago>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
        }

    }
}
