using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_01.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint IdCategoria { get; set; }
        public string Nombre { get; set;}

        public ICollection<Producto> Productos { get; set;}
    }
}
