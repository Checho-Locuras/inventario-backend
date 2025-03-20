using InventarioCCL.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InventarioCCL.DataAccess.DataBase
{
    public class CCLContext : DbContext
    {
        public CCLContext(DbContextOptions<CCLContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("productos");
            modelBuilder.Entity<Producto>().Property(p => p.Id).HasColumnName("id");
            modelBuilder.Entity<Producto>().Property(p => p.Nombre).HasColumnName("nombre");
            modelBuilder.Entity<Producto>().Property(p => p.Cantidad).HasColumnName("cantidad");
        }
    }
}
