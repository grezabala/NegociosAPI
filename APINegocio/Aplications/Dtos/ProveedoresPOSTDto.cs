namespace APINegocio.Aplications.Dtos
{
    public class ProveedoresPOSTDto
    {
        public string ProveedorName { get; }
        public string ProveedorDescription { get; set; }
        //public int? ProveedorStatus { get; set; }
        public string ProveedorDirection { get; set; }
        public string ProveedorReference { get; set; }
        public string ProveedorCode { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreadProveedor { get; set; }
        public bool IsModified { get; set; }
        public DateTime IsDateModified { get; set; }
        public bool IsAsset { get; set; }

        public ProveedoresPOSTDto()
        {
            IsAsset = true;
            IsDateModified = DateTime.MaxValue;
            IsDeleted = false;
            CreadProveedor = DateTime.Now;
            IsModified = false;
        }
    }
}
