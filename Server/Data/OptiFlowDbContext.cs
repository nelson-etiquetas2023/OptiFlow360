using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public class OptiFlowDbContext(DbContextOptions<OptiFlowDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Users> Users { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Product>(entity =>
           {
               entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
               entity.Property(e => e.Costo).HasColumnType("decimal(18,2)");
           });
       }
    }
}
