using CDP.Domain;
using CDP.Persistence.Models;

namespace CDP.Persistence.Contracts
{
    public interface IFarmPersist
    {
        Task<PageList<Farm>> GetAllFarmsAsync(int userId, PageParams pageParams);

        Task<Farm> GetFarmByIdAsync(int userId, int farmId);
    }
}
