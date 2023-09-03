namespace APINegocio.Aplications.Dtos
{
    public class ShoppingPUTDto
    {
        public int ShoppingId { get; set; }
        public string ShoppingName { get; set; }
        public string ShoppingDescription { get; set; }
        public int ShoppingStatus { get; set; }
        public int ShoppingCount { get; set; }
        public string ShoppingTitle { get; set; }
        public string ShoppingCode { get; set; }
        public int NumberShopping { get; set; }
        public DateTime IsShoppingDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAsset { get; set; }
        public DateTime IsModifedShopping { get; set; }
        public bool IsModified { get; set; }

        public ShoppingPUTDto()
        {
            IsShoppingDate = DateTime.Now;
            IsDeleted = false;
            IsAsset = true;
            IsModifedShopping = DateTime.Now;
            IsModified = true;
        }
    }
}
