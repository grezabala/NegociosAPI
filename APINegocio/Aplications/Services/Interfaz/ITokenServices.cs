using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Services.Interfaz
{
    public interface ITokenServices
    {
        string CreateToken(Users users);
    }
}
