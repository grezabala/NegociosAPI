namespace APINegocio.Aplications.Entities
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string DescrictionInventory { get; set; }
        public string ReferenceInventory { get; set; }
        public int NumberInventory { get; set; }
        public string CodigoInventory { get; set; }
        public DateTime DateCread { get; set; }
        public int StoreId { get; set; }
        public int ShoppingId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime IsDateCread { get; set; }
        public bool IsShipped { get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime IsDeletedAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime IsUpdatedAt { get; set; }
        public virtual Proveedores Proveedores { get; set; }
        public virtual Productos Proveedos { get; set; }
        public virtual Shopping Shopping { get; set; }
        public virtual Stores Stores { get; set; }
       
    }
}
