using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IList<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Employee employee, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
