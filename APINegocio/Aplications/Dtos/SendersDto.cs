namespace APINegocio.Aplications.Dtos
{
    public partial class SendersDto
    {
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderDirection { get; set; }
        public string SenderPhone { get; set; }
        public string SenderPostalCode { get; set; }
        public string SenderEmail { get; set; }
        public string SenderCode { get; set; }
        public bool IsAsset { get; set; }
        public DateTime? IsCreadSender { get; set; }
    }

    public partial class SendersPOSTDto
    {
        public string SenderName { get; set; }
        public string SenderDirection { get; set; }
        public string SenderPhone { get; set; }
        public string SenderPostalCode { get; set; }
        public string SenderEmail { get; set; }
        public string SenderCode { get; set; }
       

    }

    public partial class SendersPUTDto
    {
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderDirection { get; set; }
        public string SenderPhone { get; set; }
        public string SenderPostalCode { get; set; }
        public string SenderEmail { get; set; }
        public string SenderCode { get; set; }
       

    }
}
