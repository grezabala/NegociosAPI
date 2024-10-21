namespace APINegocio.Aplications.Dtos
{
    public partial class PaymentsDto
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string Toquen { get; set; }
        public decimal Monto { get; set; }
        public DateTime? Fecha { get; set; }
        public string Reservado { get; set; }
        public string Aplicado { get; set; }
        public string Creditado { get; set; }
        public string PaymentCode { get; set; } //Agregado 26/06/24
        public bool IsStatud { get; set; }
    }

    public partial class PaymentsPOSTDto
    {
        public int OrderId { get; set; }
        public string Toquen { get; set; }
        public decimal Monto { get; set; }
        public string Reservado { get; set; }
        public string Aplicado { get; set; }
        public string Creditado { get; set; }
        public string PaymentCode { get; set; }

    }

    public partial class PaymentsPUTDto
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string Toquen { get; set; }
        public decimal Monto { get; set; }
        public string Reservado { get; set; }
        public string Aplicado { get; set; }
        public string Creditado { get; set; }
        public string PaymentCode { get; set; }
    }
}
