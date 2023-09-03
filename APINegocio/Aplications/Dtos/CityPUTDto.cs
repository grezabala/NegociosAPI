namespace APINegocio.Aplications.Dtos
{
    public class CityPUTDto
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime IsUpdateAt { get; set; }
        public bool IsStatu { get; set; }

        public CityPUTDto()
        {
            IsDeleted = false;
            IsDeletedAt = null;
            IsUpdated = true;
            IsStatu = true;
            IsUpdateAt = DateTime.Now;
        }
    }
}
