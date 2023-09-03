namespace APINegocio.Aplications.Dtos
{
    public class OrdersPUTDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int SenderId { get; set; }
        public string OrderName { get; set; }
        public DateTime DateOrder { get; set; }
        public string OrderCode { get; set; }
        public DateTime IsCreadOrderDate { get; set; }
        public bool IsCread { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAsset { get; set; }
        public bool IsModified { get; set; }
        public DateTime IsModifiedOrderDate { get; set; }

        public OrdersPUTDto()
        {
            IsCreadOrderDate = DateTime.MinValue;
            IsDeleted = false;
            IsAsset = true;
            IsModified = true;
            IsModifiedOrderDate = DateTime.Now;
        }
    }
}
