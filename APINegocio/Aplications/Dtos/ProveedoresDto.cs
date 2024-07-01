namespace APINegocio.Aplications.Dtos
{
    public class ProveedoresDto
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
}
