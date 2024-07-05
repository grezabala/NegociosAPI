namespace APINegocio.Aplications.Dtos
{
    public partial class TickersDto
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
        public DateTime? CreationDate { get; set; }
        public bool IsLocked { get; set; }
        public bool IsStatus { get; set; }
      
    }

    public partial class TickersPOSTDto
    {
        public int CustomerId { get; set; }
        public string TickerTitulo { get; set; }
        public string Pago { get; set; }
        public string CashierName { get; set; }
        public string Direction { get; set; }
        public decimal TotalAmountItbis { get; set; }
        public decimal TotalAmountPay { get; set; }
        public int TotalProduct { get; set; }
        public string Description { get; set; }
        public int TransactionNumber { get; set; }
        public string CodeTicker { get; set; }

    }

    public partial class TickersPUTDto
    {

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
   
    }
}
