using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(UserApp userApp);
    }
}
