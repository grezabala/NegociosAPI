﻿namespace APINegocio.Aplications.Entities
{
    public partial class Proveedores
    {
        public int ProveedorId { get; set; }
        public string ProveedorName { get; set; }
        public string ProveedorDescription { get; set; }
        public string ProveedorDirection { get; set; }
        public string ProveedorReference { get; set; }
        public string ProveedorCode { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; } //New
        public DateTime? CreadProveedor { get; set; }
        public bool IsModified { get; set; }
        public DateTime? IsDateModified { get; set; }
        public bool IsAsset { get; set; }

    }
}
