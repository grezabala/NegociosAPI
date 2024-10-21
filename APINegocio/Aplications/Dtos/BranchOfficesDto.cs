namespace APINegocio.Aplications.Dtos
{
    public partial class BranchOfficesDto
    {
        public int BranchId { get; set; }
        public string BranchOfficesName { get; set; }
        public string Description { get; set; }
        public string BranchOfficesCode { get; set; }
        public string Direccion { get; set; }
        public string Contacts { get; set; }
        public string Referencia { get; set; }
        public string WebSite { get; set; }
        public string FacebookAccount { get; set; }
        public string InstagramAccount { get; set; }
        public string WhatsAppNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string OtherNumber { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public bool IsStatud { get; set; }
        public DateTime? IsCreadAt { get; set; }

    }

    public partial class BranchOfficesPOSTDto
    {
        public string BranchOfficesName { get; set; }
        public string Description { get; set; }
        public string BranchOfficesCode { get; set; }
        public string Direccion { get; set; }
        public string Contacts { get; set; }
        public string Referencia { get; set; }
        public string WebSite { get; set; }
        public string FacebookAccount { get; set; }
        public string InstagramAccount { get; set; }
        public string WhatsAppNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string OtherNumber { get; set; }

        //public float Latitud { get; set; }
        //public float Longitud { get; set; }

    }
    public partial class BranchOfficesPUTDto
    {
        public int BranchId { get; set; }
        public string BranchOfficesName { get; set; }
        public string Description { get; set; }
        public string BranchOfficesCode { get; set; }
        public string Direccion { get; set; }
        public string Contacts { get; set; }
        public string Referencia { get; set; }
        public string WebSite { get; set; }
        public string FacebookAccount { get; set; }
        public string InstagramAccount { get; set; }
        public string WhatsAppNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string OtherNumber { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }

    }
}