using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NET_TEST_BASE.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace NET_TEST_BASE.Data
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

        //desactuvamos el output para que funcione nuestro trigger
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pago>()
                .ToTable(tb => tb.UseSqlOutputClause(false));
        }

        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Obtener todas las entradas que han cambiado
            var cambios = ChangeTracker.Entries()
                .Where(e => e.Entity is Pago &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));

            foreach (var cambio in cambios)
            {
                // Determinar la acción (Insertar, Modificar, Eliminar)
                string accion = cambio.State switch
                {
                    EntityState.Added => "Insert",
                    EntityState.Modified => "Update",
                    EntityState.Deleted => "Delete",
                    _ => "Unknown"
                };

                // Crear un registro en la bitácora
                var bitacora = new Bitacora
                {
                    Entidad = "Pago",
                    Accion = accion,
                    Fecha = DateTime.Now,
                    Usuario = "Sistema", // Puedes agregar el usuario actual si lo manejas
                    Detalles = GenerarDetallesDeCambio(cambio) // Función para generar los detalles
                };

                // Agregar el registro de la bitácora
                Bitacoras.Add(bitacora);
            }

            // Guardar los cambios (incluyendo los registros de la bitácora)
            return await base.SaveChangesAsync(cancellationToken);
        }

        // Método auxiliar para generar una descripción de los cambios
        private string GenerarDetallesDeCambio(EntityEntry entry)
        {
            var detalles = new StringBuilder();

            if (entry.State == EntityState.Added)
            {
                // Si es un nuevo pago, listamos todos los valores insertados
                foreach (var propiedad in entry.CurrentValues.Properties)
                {
                    var valor = entry.CurrentValues[propiedad]?.ToString() ?? "null";
                    detalles.AppendLine($"{propiedad.Name}: {valor}");
                }
            }
            else if (entry.State == EntityState.Modified)
            {
                // Si es una modificación, listamos los valores que han cambiado
                foreach (var propiedad in entry.OriginalValues.Properties)
                {
                    var original = entry.OriginalValues[propiedad]?.ToString() ?? "null";
                    var actual = entry.CurrentValues[propiedad]?.ToString() ?? "null";
                    if (original != actual)
                    {
                        detalles.AppendLine($"{propiedad.Name}: {original} -> {actual}");
                    }
                }
            }
            else if (entry.State == EntityState.Deleted)
            {
                // Si es una eliminación, listamos todos los valores eliminados
                foreach (var propiedad in entry.OriginalValues.Properties)
                {
                    var valor = entry.OriginalValues[propiedad]?.ToString() ?? "null";
                    detalles.AppendLine($"{propiedad.Name}: {valor}");
                }
            }

            return detalles.ToString();
        }
        
    }
}
