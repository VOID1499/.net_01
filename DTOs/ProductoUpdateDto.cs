using Proyecto_01.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_01.DTOs
{
    public class ProductoUpdateDto
    {
        public uint Id { get; set; }

        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public uint IdCategoria { get; set; }

    }
}
