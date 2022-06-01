using MasterTrade.Modelo.Entidades;
using MasterTrade.Modelo.Enums;
using MasterTrade.Modelo.Heredable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MasterTrade.Modelo.Contexto
{
    public class BaseDatos : DbContext
    {
        //SETEAR LAS TABLAS ENTIDADES EN LA BASE DE DATOS
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraProducto> CompraProductos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaProducto> DetalleVentas { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<Impuesto> Impuestos { get; set; }
        public DbSet<Precio> Precios { get; set; }
        public DbSet<ValorDollar> ValorDollars { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Producto>(entity =>
            {
                //añadiendo valores por defecto a columnas de product
                entity.HasIndex(p => p.CodBarras)
                  .IsUnique();
            });
           
           
            builder.Entity<Usuario>(entity =>
            {
                entity.Property(p => p.TipoUsuario)
                .HasDefaultValue(TipoUsuario.Vendedor);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var CONFIGURATION = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Configuraciones.json").Build();
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseMySql(CONFIGURATION["ConnectionsStrings:DefaultConnection"], new MariaDbServerVersion(new Version()))
                    .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    ;
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.Entity is BaseData trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.FechaActualizacion = utcNow;
                            entry.Property("CreatedAt").IsModified = false;
                            break;

                        case EntityState.Added:
                            trackable.FechaCreacion = utcNow;
                            trackable.FechaActualizacion = utcNow;
                            break;
                    }
                }
            }
        }
    }
}
