using CDP.Domain;
using CDP.Persistence.Models;

namespace CDP.Persistence.Contracts
{
    public interface IPlantingPersist
    {
        Task<PageList<Planting>> GetAllPlantingsAsync(PageParams pageParams, bool includePlots = false);
    }
}
