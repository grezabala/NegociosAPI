namespace APINegocio.Aplications.Entities
{
    public class Shopping
    {
        public Shopping()
        {
            Orders = new HashSet<Orders>();
        }
        public int ShoppingId { get; set; }
        public int OrderId { get; set; }
        public string ShoppingName { get; set; }
        public string ShoppingDescription { get; set; }
        public int ShoppingStatus { get; set; }
        public int ShoppingCount { get; set; }
        public string ShoppingTitle { get; set; }
        public string ShoppingCode { get; set; }
        public int NumberShopping { get; set; }
        public DateTime IsShoppingDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IsDeletedAt { get; set; } //New
        public bool IsAsset { get; set; }
        public DateTime IsModifedShopping { get; set; }
        public bool IsModified { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
