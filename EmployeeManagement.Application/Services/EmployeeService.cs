using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IList<EmployeeDto>> GetAllAsync(CancellationToken cancellation = default)
        {
            var employees = await _employeeRepository.GetAllAsync(cancellation);

            //Map from Employee to EmployeeDto and then return the object
            return employees
                .Select(x => MapToEmployeeDto(x))
                .ToList();
        }

        public async Task<EmployeeDto?> GetByIdAsync(Guid id, CancellationToken cancellation = default)
        {
            var employee = await _employeeRepository.GetByIdAsync(id, cancellation);

            //Map from Employee to EmployeeDto and then return the object
            return employee is null
                ? null
                : MapToEmployeeDto(employee);
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeRequestDto createEmployeeRequest, CancellationToken cancellation = default)
        {
           var employee = new Employee(
           createEmployeeRequest.Name,
           createEmployeeRequest.LastName,
           DateOnly.FromDateTime(createEmployeeRequest.BirthDate),
           createEmployeeRequest.IdentityNumber,
           createEmployeeRequest.Email,
           createEmployeeRequest.Position,
           DateOnly.FromDateTime(createEmployeeRequest.HireDate),
           isActive: true);

            var created = await _employeeRepository.AddAsync(employee, cancellation);

            return MapToEmployeeDto(created);
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateEmployeeRequestDto updateRequest, CancellationToken cancellation = default)
        {
            //check first if employee already exist
            var existingEmployee = await _employeeRepository.GetByIdAsync(id, cancellation);

            if (existingEmployee == null) return false;

            // Using the Update method defined in the Employee class within the Domain project.
            existingEmployee.Update(updateRequest.Name,
                updateRequest.LastName,
                DateOnly.FromDateTime(updateRequest.BirthDate),
                updateRequest.IdentityNumber,
                updateRequest.Email,
                updateRequest.Position,
                DateOnly.FromDateTime(updateRequest.HireDate),
                updateRequest.IsActive);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellation)
        {
            return await _employeeRepository.DeleteAsync(id, cancellation);
        }


        private static EmployeeDto MapToEmployeeDto(Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate.ToDateTime(TimeOnly.MinValue),
                IdentityNumber = employee.IdentityNumber,
                Email = employee.Email,
                Position = employee.Position,
                HireDate = employee.HireDate.ToDateTime(TimeOnly.MinValue),
                IsActive = employee.IsActive,
                Age = employee.Age,
            };
        }
    }
}

