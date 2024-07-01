namespace APINegocio.Aplications.Dtos
{
    public class TickersDto
    {
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
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public bool IsLocked { get; set; }
        public bool IsModified { get; set; }
        public DateTime IsModifiedDate { get; set; }
        public bool IsImprection { get; set; }
        public DateTime DateImprect { get; set; }
    }
}
