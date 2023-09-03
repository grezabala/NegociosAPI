using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Authentication.Interfaz
{
    public interface IAuthenticationAIPNegocio
    {
        Task<Users> Registrar(Users users, string password);
        Task<Users> Login(string Email, string password);
        Task<bool> ExisteUser(string Email);
    }
}
