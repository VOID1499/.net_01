using Proyecto_01.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_01.DTOs
{
    public class ProductoDto
    {

        public uint Id { get; set; }

        public string Nombre { get; set; }
        public string? Descripcion { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }


        public string Categoria { get; set; }
        public uint IdCagtegoria { get; set; }

    }
}
