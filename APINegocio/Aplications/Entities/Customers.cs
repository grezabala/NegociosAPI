namespace APINegocio.Aplications.Entities
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Direction { get;  set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CodeCustomer { get; set; } //Agregado 26/06/24
        public string Country { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? IsUpdatedDate { get; set; } 
        public bool IsDeleted { get; set; }
        public bool IsStatu { get; set; }
        public bool IsModified { get; set; }
        public DateTime? IsDeletedAt { get; set; } //New
    }
}
