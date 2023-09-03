namespace APINegocio.Aplications.Dtos
{
    public class ProveedoresPUTDto
    {
        public int ProveedorId { get; set; }
        public string ProveedorName { get; }
        public string ProveedorDescription { get; set; }
        public int ProveedorStatus { get; set; }
        public string ProveedorDirection { get; set; }
        public string ProveedorReference { get; set; }
        public string ProveedorCode { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreadProveedor { get; set; }
        public bool IsModified { get; set; }
        public DateTime IsDateModified { get; set; }
        public bool IsAsset { get; set; }

        public ProveedoresPUTDto()
        {
            IsModified = true;
            IsDateModified = DateTime.Now;
        }
    }
}
