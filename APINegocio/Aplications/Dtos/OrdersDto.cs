namespace APINegocio.Aplications.Dtos
{
    public partial class OrdersDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int SenderId { get; set; }
        public DateTime? DateOrder { get; set; }
        public string OrderCode { get; set; }
        public string OrderName { get; set; }
        public DateTime? IsCreadOrderDate { get; set; }
        public bool IsCread { get; set; }
        public bool IsAsset { get; set; }
     
    }

    public partial class OrdersPOSTDto
    {
        public int CustomerId { get; set; }
        public int SenderId { get; set; }
        public string OrderCode { get; set; }
        public string OrderName { get; set; }

    }

    public partial class OrdersPUTDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int SenderId { get; set; }
        public string OrderName { get; set; }
        public string OrderCode { get; set; }

    }
}
