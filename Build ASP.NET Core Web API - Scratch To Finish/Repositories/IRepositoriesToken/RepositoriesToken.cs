using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories.IRepositoriesToken
{
    public class RepositoriesToken : IRepositoriesToken
    {
        private readonly IConfiguration configuration;

        public RepositoriesToken(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string CreateToken(IdentityUser user, List<string> roles)
        {
            // create clim form roles for another informtion 
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach (var role in roles) {

                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]??null!));

            var credentials = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"], claims,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials : credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
