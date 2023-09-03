namespace APINegocio.Aplications.Dtos
{
    public class SendersPUTDto
    {
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderDirection { get; set; }
        public string SenderPhone { get; set; }
        public string SenderPostalCode { get; set; }
        public string SenderEmail { get; set; }
        public string SenderCode { get; set; }
        public DateTime IsCreadSender { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IsModifiedSenderDate { get; set; }
        public bool IsModifiedPostalCode { get; set; }
        public bool IsModifiedSender { get; set; }
        public bool IsAsset { get; set; }

        public SendersPUTDto()
        {
            IsCreadSender = DateTime.MinValue;
            IsDeleted = false;
            IsModifiedSenderDate = DateTime.Now;
            IsAsset = true;
            IsModifiedSender = true;
            IsModifiedPostalCode = true;
        }
    }
}
