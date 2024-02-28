using Microsoft.EntityFrameworkCore;
using Proyecto_01.Models.Seeds;

namespace Proyecto_01.Models
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options) 
        : base(options)
        { }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoriaSeed());
        }

    }
}
