namespace APINegocio.Aplications.Dtos
{
    public partial class CountriesDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int StorId { get; set; }
        public int ProveedorId { get; set; }
        public string CodeCountries { get; set; } //Agregado 26/06/24
        public string Note { get; set; }
        public bool? IsRecurring { get; set; }
        public DateTime WhenDate { get; set; }
        public bool IsStatud { get; set; }
    }

    public partial class CountriesPOSTDto
    {
        public string CountryName { get; set; }
        public int StorId { get; set; }
        public int ProveedorId { get; set; }
        public string Note { get; set; }

        public string CodeCountries { get; set; }
    }

    public partial class CountriesPUTDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int StorId { get; set; }
        public int ProveedorId { get; set; }
        public string CodeCountries { get; set; } //Agregado 26/06/24
        public string Note { get; set; }

    }
}
