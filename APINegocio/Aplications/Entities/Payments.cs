namespace APINegocio.Aplications.Entities
{
    public class Payments
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string Toquen { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Reservado { get; set; }
        public string Aplicado { get; set; }
        public DateTime IsCreadtPayment { get; set; }
        public bool IsCreadtRefund { get; set;}
        public string Creditado { get; set;}
        public bool IsRefund { get; set;}
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime IsUpdatedAt { get; set; }
        public bool IsStatud { get; set; }
    }
}
