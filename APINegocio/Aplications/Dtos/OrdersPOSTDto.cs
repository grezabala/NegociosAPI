namespace APINegocio.Aplications.Dtos
{
    public class OrdersPOSTDto
    {
        public int CustomerId { get; set; }
        public int SenderId { get; set; }
        public DateTime? DateOrder { get; set; }
        public string OrderCode { get; set; }
        public string OrderName { get; set; }
        public DateTime? IsCreadOrderDate { get; set; }
        public bool IsCread { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; }
        public bool IsAsset { get; set; }
        public bool IsModified { get; set; }
        public DateTime? IsModifiedOrderDate { get; set; }

        //public OrdersPOSTDto()
        //{
        //    IsAsset = true;
        //    IsCread = true;
        //    IsDeleted = false;
        //    DateOrder = DateTime.Now;
        //    IsCreadOrderDate = DateTime.Now;
         
        //}
    }
}
