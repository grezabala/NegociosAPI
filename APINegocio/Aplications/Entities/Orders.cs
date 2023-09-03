namespace APINegocio.Aplications.Entities
{
    public class Orders
    {
        public Orders()
        {
            Customers = new HashSet<Customers>();
            Senders = new HashSet<Senders>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int SenderId { get; set; }
        public DateTime DateOrder { get; set; }
        public string OrderCode { get; set; }
        public string OrderName { get; set; }
        public DateTime IsCreadOrderDate { get; set; }
        public bool IsCread { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime IsDeletedAt { get; set; } //New
        public bool IsAsset { get; set; }
        public bool IsModified { get; set; }
        public DateTime IsModifiedOrderDate { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }   
        public virtual ICollection<Senders> Senders { get; set; }
    }
}
