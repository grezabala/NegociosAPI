using APINegocio.Aplications.Services.Interfaz;
using APINegocio.Aplications.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APINegocio.Aplications.Services
{
    public class TokenService : ITokenServices
    {
        //Variables
        private readonly SymmetricSecurityKey _securityKey;

        public TokenService(IConfiguration configuration)
        {
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

        public string CreateToken(Users users)
        {

            var claims = new List<Claim>()
            {
              new Claim(JwtRegisteredClaimNames.NameId, users.Email!)
            };

            //Variables
            var credencialesToken = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptior = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = credencialesToken
            };

            //Variable 
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptior);

            //Retornar la cadena 
            return tokenHandler.WriteToken(token);
        }
    }
}
