namespace APINegocio.Aplications.Dtos
{
    public class UsersRegisterDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordUser { get; set; }
        public bool IsAsset { get; set; }
        public DateTime CreatedDate { get; set; } = default(DateTime);
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public UsersRegisterDto()
        {
            CreatedDate = default(DateTime);
            IsAsset = true;
        }
    }
}
