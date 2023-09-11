using APINegocio.Aplications.Authentication.Interfaz;
using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace APINegocio.Aplications.Authentication.Repository
{
    public class RepoAuthenticationAIPNegocio : IAuthenticationAIPNegocio
    {
        private readonly APINegociosDbContext _APINegocioDbContext;

        public RepoAuthenticationAIPNegocio(APINegociosDbContext aPINegocioDbContext)
        {
            _APINegocioDbContext = aPINegocioDbContext;
        }

        public async Task<bool> ExisteUser(string Email)
        {
            if (await _APINegocioDbContext.Users.AnyAsync(e => e.Email == Email))
                return true;

            return false;
        }

        public async Task<Users> Login(string Email, string password)
        {
            var loginUser = await _APINegocioDbContext.Users.FirstOrDefaultAsync(e => e.Email == Email);
            if (loginUser == null)
                return null;

            if (!VerificarPasswordHash(password, loginUser.PasswordHash, loginUser.PasswordSalt))
                return null;

            return loginUser;
        }

        public async Task<Users> Registrar(Users users, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CrearPasswordHash(password, out passwordHash, out passwordSalt);
            users.PasswordHash = passwordHash;
            users.PasswordSalt = passwordSalt;

            await _APINegocioDbContext.Users.AddAsync(users);
            await _APINegocioDbContext.SaveChangesAsync();

            return users;
        }


        //Metodo para verificar si un usuario existe 
        private bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmc = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmc.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

        //Metodo para crear el password
        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
