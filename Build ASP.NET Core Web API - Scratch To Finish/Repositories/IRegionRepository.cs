using Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Domain;
namespace Build_ASP.NET_Core_Web_API___Scratch_To_Finish.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Ragion>> GetAllAsync();
        Task<Ragion?> GetRagionById(Guid id);
        Task<Ragion> CreateNewReagion(Ragion ragion);
        Task<Ragion?> Update(Guid id, Ragion ragion);
        Task<Ragion?> DelatetReagion(Guid id);

    }
}
