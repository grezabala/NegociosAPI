namespace APINegocio.Aplications.Entities
{
    public class Stores
    {
        public int StorId { get; set; }
        public string StoresName { get; set;}
        public int Stock { get; set; } //Agregado el 27/06/24
        public string CodeStore { get; set; } //Agregado el 27/06/24
        public string StoresDescription { get; set; }
        public int StoresCount { get; set; } = 0;
        public int StoresTotal { get; set; }
        public string Biography { get; set; }
        public string WebSite { get; set; }
        public string FacebookAccount { get; set; }
        public string InstagramAccount { get; set; }
        public string Address { get; set; }
        public string AceptPyments { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string WhatsAppNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string OtherNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IsCreadDateStore { get; set; }
        public DateTime IsModified { get; set; }
        public DateTime IsDeletedAt { get; set; } //New
        public bool IsStatud { get; set; } //New
    }
}
