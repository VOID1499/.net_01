using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Proyecto_01.Models.Seeds
{
    public class CategoriaSeed :IEntityTypeConfiguration<Categoria>
    {


        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasData(
               new Categoria() { IdCategoria = 1, Nombre = "categoria1" },
               new Categoria() { IdCategoria = 2, Nombre = "categoria2" },
               new Categoria() { IdCategoria = 3, Nombre = "categoria3" },
               new Categoria() { IdCategoria = 4, Nombre = "categoria4" },
               new Categoria() { IdCategoria = 5, Nombre = "categoria5" },
               new Categoria() { IdCategoria = 6, Nombre = "categoria6" }
               );
        }
    }
}
