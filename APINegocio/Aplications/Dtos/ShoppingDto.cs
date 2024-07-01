namespace APINegocio.Aplications.Dtos
{
    public partial class ShoppingDto
    {
        public int ShoppingId { get; set; }
        public int OrderId { get; set; }
        public string ShoppingName { get; set; }
        public string ShoppingDescription { get; set; }
        public int ShoppingStatus { get; set; }
        public int ShoppingCount { get; set; }
        public string ShoppingTitle { get; set; }
        public string ShoppingCode { get; set; }
        public int NumberShopping { get; set; }
        public bool IsAsset { get; set; }
        public DateTime? IsShoppingDate { get; set; }
    }

    public partial class ShoppingPOSTDto
    {
        public int OrderId { get; set; }
        public string ShoppingName { get; set; }
        public string ShoppingDescription { get; set; }
        public int ShoppingStatus { get; set; }
        public int ShoppingCount { get; set; }
        public string ShoppingTitle { get; set; }
        public string ShoppingCode { get; set; }
        public int NumberShopping { get; set; }

    }

    public partial class ShoppingPUTDto
    {
        public int ShoppingId { get; set; }
        public int OrderId { get; set; }
        public string ShoppingName { get; set; }
        public string ShoppingDescription { get; set; }
        public int ShoppingStatus { get; set; }
        public int ShoppingCount { get; set; }
        public string ShoppingTitle { get; set; }
        public string ShoppingCode { get; set; }
        public int NumberShopping { get; set; }

    }

}
