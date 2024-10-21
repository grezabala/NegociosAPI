namespace APINegocio.Aplications.Dtos
{
    public partial class ProveedoresDto
    {
        public int ProveedorId { get; set; }
        public string ProveedorName { get; set; }
        public string ProveedorDescription { get; set; }
        public string ProveedorDirection { get; set; }
        public string ProveedorReference { get; set; }
        public string ProveedorCode { get; set; }
        public DateTime? CreadProveedor { get; set; }
        public bool IsAsset { get; set; }
    }

    public partial class ProveedoresPOSTDto
    {
        public string ProveedorName { get; set; }
        public string ProveedorDescription { get; set; }
        public string ProveedorDirection { get; set; }
        public string ProveedorReference { get; set; }
        public string ProveedorCode { get; set; }

    }

    public partial class ProveedoresPUTDto
    {
        public int ProveedorId { get; set; }
        public string ProveedorName { get; set; }
        public string ProveedorDescription { get; set; }
        public string ProveedorDirection { get; set; }
        public string ProveedorReference { get; set; }
        public string ProveedorCode { get; set; }

    }
}
