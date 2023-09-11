using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APINegocio.Models
{
    public class Suppliers
    {
        [Key]
        [Column("SupplierId")]
        public int SupplierId { get; set; }
        public string SupplierName { get; set;}
        public string SupplierDescription { get; set;}
        public string Contactos { get; set; }
    }
}
