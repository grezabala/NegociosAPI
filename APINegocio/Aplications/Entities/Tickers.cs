namespace APINegocio.Aplications.Entities
{
    public partial class Tickers
    {
        public Tickers()
        {
            DetalleTickers = new HashSet<DetalleTicker>();
        }

        public int TickerId { get; set; }
        public int CustomerId { get; set; }
        public string TickerTitulo { get; set; }
        public string Pago { get; set; }
        public string CashierName { get; set; }
        public string Direction { get; set; }
        public int RNC { get; set; }
        public int NIF { get; set; }
        public decimal TotalAmountItbis { get; set; }
        public decimal TotalAmountPay { get; set; }
        public int TotalProduct { get; set; }
        public string Description { get; set; }
        public int TransactionNumber { get; set; }
        public string CodeTicker { get; set; }
        public DateTime? CreationDate { get; set; } 
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public bool IsModified { get; set; }
        public bool IsImprection { get; set; }
        public bool IsStatus { get; set; }
        public DateTime? DateImprect { get; set; }
        public DateTime? IsModifiedDate { get; set; }
        public DateTime? IsDeletedAt { get; set; } //New

        public virtual ICollection<DetalleTicker> DetalleTickers { get; set; }
        public virtual Customers Customers { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
