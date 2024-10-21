namespace APINegocio.Aplications.Entities
{
    public partial class Senders
    {
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderDirection { get; set; }
        public string SenderPhone { get; set; }
        public string SenderPostalCode { get; set; }
        public string SenderEmail { get; set; }
        public string SenderCode { get; set; }
        public DateTime? IsCreadSender { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedAt { get; set; } //New
        public DateTime? IsModifiedSenderDate { get; set; }
        public bool IsModifiedPostalCode { get; set; }
        public bool IsModifiedSender { get; set; }
        public bool IsAsset { get; set; }
        public virtual Orders Orders { get; set; }

    }
}
