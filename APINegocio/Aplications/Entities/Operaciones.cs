using System.ComponentModel.DataAnnotations;

namespace APINegocio.Aplications.Entities
{
    public partial class Operaciones
    {
        [Key]
        public int OperacionId { get; set; }
        public string Tipo { get; set; }
        public string Producto { get; set; }
        public DateTime? Fecha { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        public bool IsDeletedBy { get; set; }
        public DateTime? IsDeletedAt { get; set;}
        public bool IsUpdatedBy { get; set; }
        public DateTime? IsUpdatedAt { get; set;}
        public bool IsStatu { get; set; }
    }
}
