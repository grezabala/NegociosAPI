namespace APINegocio.Aplications.Dtos
{
    public class InventoryPUTDto
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

        public InventoryPUTDto()
        {
            IsUpdatedAt = DateTime.Now;
            IsUpdated = true;
            IsDateCread = DateTime.MinValue; 
            IsShipped = false;
            IsDeleted = false;
            IsDateCread = DateTime.MinValue;
            IsDeletedAt = DateTime.MinValue;
        }
    }
}
