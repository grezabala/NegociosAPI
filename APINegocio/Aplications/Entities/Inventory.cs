namespace APINegocio.Aplications.Entities
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public int Stock { get; set; }
        public string DescrictionInventory { get; set; }
        public string ReferenceInventory { get; set; }
        public int NumberInventory { get; set; }
        public string CodigoInventory { get; set; }
        public DateTime? DateCread { get; set; }
        public int StoresStorId { get; set; }
        public int StorId { get; set; }
        public int ShoppingId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime? IsDateCread { get; set; }
        public bool IsShipped { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; }
        public bool IsUpdated { get; set; }
        public bool IsStatus { get; set; }
        public DateTime? IsUpdatedAt { get; set; }
        public virtual Proveedores Proveedores { get; set; }
        public virtual Productos Proveedos { get; set; }
        public virtual Shopping Shopping { get; set; }
        public virtual Stores Stores { get; set; }

    }

    /*
     
       {
  "inventoryName": "Compras",
  "descrictionInventory": "Inventario de la ultimas compra de este trismetres",
  "referenceInventory": "Compras trismestral",
  "numberInventory": 13,
  "codigoInventory": "CPTR-13",
  "dateCread": "2024-06-25T21:22:40.260Z",
  "storId": 1,
  "shoppingId": 1,
  "productoId": 4,
  "proveedorId": 3,
  "isDateCread": "2024-06-25T21:22:40.261Z",
  "isShipped": true,
  "isDeleted": true,
  "isDeletedAt": "2024-06-25T21:22:40.261Z",
  "isUpdated": true,
  "isUpdatedAt": "2024-06-25T21:22:40.261Z"
}
     
     
     */
}
