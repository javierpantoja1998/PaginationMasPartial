using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaginationMasPartial.Models
{
    [Table("ARTICULOS")]
    public class Articulo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Imagen")]
        public string Imagen { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Precio")]
        public int Precio { get; set; }
    }
}
