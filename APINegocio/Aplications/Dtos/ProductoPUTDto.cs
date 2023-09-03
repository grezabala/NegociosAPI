namespace APINegocio.Aplications.Dtos
{
    public class ProductoPUTDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Referencia { get; set; }
        public DateTime IsDateModified { get; set; }
        public bool IsModified { get; set; }

        public ProductoPUTDto()
        {
            IsDateModified = DateTime.Now;
            IsModified = true;
        }
    }
}
