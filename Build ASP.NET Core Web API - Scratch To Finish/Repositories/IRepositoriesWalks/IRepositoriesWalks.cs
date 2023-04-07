using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories.IRepositoriesWalks
{
    public interface IRepositoriesWalks
    {
        Task<Walk> CreateNewWalk(Walk walk);
    }
}
