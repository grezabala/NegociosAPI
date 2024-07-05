namespace APINegocio.Aplications.Dtos
{
    public partial class CityDto
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string Code { get; set; }
    }

    public partial class CityPOSTDto 
    {
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string Code { get; set; }

    }

    public partial class CityPUTDto 
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string Code { get; set; }

    }
}
