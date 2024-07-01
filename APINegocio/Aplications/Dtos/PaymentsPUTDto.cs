namespace APINegocio.Aplications.Dtos
{
    public class PaymentsPUTDto
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string Toquen { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Reservado { get; set; }
        public string Aplicado { get; set; }
        public DateTime IsCreadtPayment { get; set; }
        public bool IsCreadtRefund { get; set; }
        public string Creditado { get; set; }
        public bool IsRefund { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime IsUpdatedAt { get; set; }
        public bool IsStatud { get; set; }
        public string PaymentCode { get; set; }

        //public PaymentsPUTDto()
        //{
        //    Fecha = DateTime.Now;
        //    IsCreadtPayment = DateTime.Now;
        //    IsCreadtRefund = true;
        //    IsRefund = true;
        //    IsDeleted = false;
        //    IsDeletedAt = null;
        //    IsStatud = true;
        //    IsUpdatedAt = DateTime.Now;
        //    IsUpdated = true;
        //}
    }
}
