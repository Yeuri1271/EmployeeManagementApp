using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IUserAppRepository
    {
        Task<IList<UserApp>> GetAllASync(CancellationToken cancellation = default);
        Task<UserApp> GetByUsernameAsync(string name, CancellationToken cancellation = default);
    }
}
