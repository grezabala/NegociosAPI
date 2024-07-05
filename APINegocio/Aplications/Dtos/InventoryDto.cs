using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Dtos
{
    public partial class InventoryDto
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string DescrictionInventory { get; set; }
        public string ReferenceInventory { get; set; }
        public int NumberInventory { get; set; }
        public string CodigoInventory { get; set; }
        public DateTime DateCread { get; set; }
        public int StoreId { get; set; }
        public int StoresStoreId { get; set; }
        public int ShoppingId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime IsDateCread { get; set; }
        public bool IsShipped { get; set; }
        public bool IsStatus { get; set; }

    }

    public partial class InventoryPOSTDto
    {
        public string InventoryName { get; set; }
        public string DescrictionInventory { get; set; }
        public string ReferenceInventory { get; set; }
        public int NumberInventory { get; set; }
        public string CodigoInventory { get; set; }
        public int StorId { get; set; }
        public int Stock { get; set; }
        public int ShoppingId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }

    }

    public partial class InventoryPUTDto
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public string DescrictionInventory { get; set; }
        public string ReferenceInventory { get; set; }
        public int NumberInventory { get; set; }
        public string CodigoInventory { get; set; }
        public int StoreId { get; set; }
        public int Stock { get; set; }
        public int ShoppingId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
    }

}
