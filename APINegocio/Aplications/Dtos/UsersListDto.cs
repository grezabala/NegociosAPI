namespace APINegocio.Aplications.Dtos
{
    public class UsersListDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsAsset { get; set; }
    }
}
