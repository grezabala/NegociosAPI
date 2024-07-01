namespace APINegocio.Aplications.Dtos
{
    public class PaymentsDto
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
    }
}
