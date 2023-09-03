namespace APINegocio.Aplications.Entities
{
    public class DetalleTicker
    {
        public int DetalleId { get; set; }
        public int TickerId { get; set;}
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Itbis { get; set; }
        public decimal Descounts { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal TotalDescout { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IsDeletedAt { get; set; } //New
        public DateTime LastUpdated { get; set; } //New
        public bool IsModified { get; set; }
        public DateTime IsModifiedDate { get; set;}

        public virtual Tickers Tickers { get; set; }
        public virtual Productos Productos { get; set; }
       
    }
}
