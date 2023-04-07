using Microsoft.AspNetCore.Identity;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories.IRepositoriesToken
{
    public interface IRepositoriesToken
    {
       string CreateToken(IdentityUser user, List<string> roles);
    }
}
