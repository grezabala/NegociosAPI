﻿namespace APINegocio.Aplications.Entities
{
    public partial class City
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime? IsUpdateAt { get; set; }
        public bool IsStatus { get; set; }
        public int? CountriesCountryId { get; set; }
        public virtual Countries Countries { get; set; }

    }
}
