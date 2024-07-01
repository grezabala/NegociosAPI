namespace APINegocio.Aplications.Dtos
{
    public class ProductosDto
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Referencia { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedDate { get; set; } 
        public bool IsAsset { get; set; }
    }
}
