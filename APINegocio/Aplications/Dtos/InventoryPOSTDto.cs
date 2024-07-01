using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Dtos
{
    public class InventoryPOSTDto
    {
        public string InventoryName { get; set; }
        public string DescrictionInventory { get; set; }
        public string ReferenceInventory { get; set; }
        public int NumberInventory { get; set; }
        public string CodigoInventory { get; set; }
        public DateTime DateCread { get; set; }
        public int StorId { get; set; }
        public int Stock { get; set; }
        public int ShoppingId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime IsDateCread { get; set; }
        public bool IsShipped { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IsDeletedAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime IsUpdatedAt { get; set; }
     
        public InventoryPOSTDto()
        {
            IsDateCread = DateTime.Now;
            IsShipped = false;
            IsDeleted = false;
            IsDeletedAt = DateTime.Now;
            IsUpdated = false;
            IsUpdatedAt = DateTime.MinValue;
        }
    }
}
