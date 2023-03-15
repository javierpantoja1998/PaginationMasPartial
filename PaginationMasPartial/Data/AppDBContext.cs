using Microsoft.EntityFrameworkCore;
using PaginationMasPartial.Models;

namespace PaginationMasPartial.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
    }
}
