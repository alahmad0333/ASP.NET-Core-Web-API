using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories.IRepositoriesReagion
{
    public interface IRegionRepository
    {
        Task<List<Ragion>> GetAllAsync(string? FilterOn = null ,string? FilterQuery = null ,
            string? sortBy = null , bool isAscending = true , int pageNumber = 1 , int pageSize = 1000 );
        Task<Ragion?> GetRagionById(Guid id);
        Task<Ragion> CreateNewReagion(Ragion ragion);
        Task<Ragion?> Update(Guid id, Ragion ragion);
        Task<Ragion?> DelatetReagion(Guid id);
    }
}
