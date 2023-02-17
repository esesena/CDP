using CDP.Domain;
using CDP.Persistence.Models;

namespace CDP.Persistence.Contracts
{
    public interface IEmployeePersist : IGeralPersist
    {
        Task<PageList<Employee>> GetAllEmployeesAsync(PageParams pageParams, bool includeFarms = false);
        Task<Employee> GetEmployeeByUserIdAsync(int userId, bool includeFarms = false);
    }
}
