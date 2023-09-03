namespace APINegocio.Aplications.Dtos
{
    public class CountriesPOSTDto
    {
        public string CountryName { get; set; }
        public int StorId { get; set; }
        public int ProveedorId { get; set; }
        public string Note { get; set; }
        public bool? IsRecurring { get; set; }
        public DateTime WhenDate { get; set; }
        public DateTime? IsDateCreadCountry { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; } //New
        public bool IsStatud { get; set; }
        public bool? IsUpdated { get; set; }
        public DateTime? IsUpdatedAt { get; set; }

        public CountriesPOSTDto()
        {
            IsRecurring = null;
            IsDateCreadCountry = null;
            IsDeleted = null;
            IsStatud = true;
            IsUpdated = false;
            IsUpdatedAt = null;
        }
    }
}
