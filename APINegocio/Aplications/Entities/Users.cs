

namespace APINegocio.Aplications.Entities
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; } = default(DateTime);
        public DateTime LastModifiedDate { get; set; } = default(DateTime);
        public bool IsDeleted { get; set; }
        public DateTime IsDeletedAt { get; set; } //New
        public DateTime LastModifiedDateUtc { get; set; } //New
        public bool IsAsset { get; set; }

        //Campo para la encriptación del password
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
