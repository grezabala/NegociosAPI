namespace APINegocio.Aplications.Entities
{
    public class BranchOffices
    {
        public int BranchOfficesId { get; set; }
        public string BranchOfficesName { get; set;}
        public string DireccionBranch { get; set; }
        public string ContactoBranch { get; set; }
        public string ReferenciaBranch { get; set; }
        public string WebSite { get; set; }
        public string FacebookAccount { get; set; }
        public string InstagramAccount { get; set; }
        public string WhatsAppNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string OtherNumber { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public bool IsDeletedBy { get; set; }
        public bool IsCreadBy { get; set; }
        public DateTime IsDeletedAt { get; set;}
        public DateTime IsCreadAt { get; set; }
        public bool IsUpdatedBy { get; set; }
        public DateTime IsUpdatedAt { get; set;}
        public bool IsStatud { get; set; }
    }
}
