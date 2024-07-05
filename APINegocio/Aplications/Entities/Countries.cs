namespace APINegocio.Aplications.Entities
{
    public class Countries
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int StorId { get; set; }
        public int ProveedorId { get; set; }
        public string CodeCountries { get; set; } //Agregado 26/06/24
        public string Note { get; set; }
        public bool? IsRecurring { get; set; }
        public DateTime? WhenDate { get; set; }
        public DateTime? IsDateCreadCountry { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; } //New
        public bool IsStatud { get; set; } //New 04/08
        public bool? IsUpdated { get; set; }
        public DateTime? IsUpdatedAt { get; set; }
    }
}
