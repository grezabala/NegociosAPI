namespace APINegocio.Aplications.Dtos
{
    public partial class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Direction { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string CodeCustomer { get; set; } //Agregado 26/06/24
        public string CustomerCode { get; set; }
        public string Country { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsStatu { get; set; }
    }

    public partial class CustomerPOSTDto
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Direction { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string CodeCustomer { get; set; }

    }

    public partial class CustomerPUTDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Direction { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string CodeCustomer { get; set; }

    }
}
