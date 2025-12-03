using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Infrastructure.Repository
{
    /// <summary>
    /// In-memory implementation of IEmployeeRepository used for testing/demo purposes.
    /// This repository does not persist data; the list resets every time the application restarts.
    /// </summary>
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();

        /// <summary>
        /// Initializes the repository and loads predefined seed data.
        /// </summary>
        public EmployeeRepository()
        {
            SeedEmployee();
        }

        /// <summary>
        /// Adds a new employee to the in-memory list.
        /// Returns the same employee instance for convenience.
        /// </summary>
        public Task<Employee> AddAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            _employees.Add(employee);

            return Task.FromResult(employee);
        }

        /// <summary>
        /// Deletes an employee by Id.
        /// Returns true if the employee existed and was removed; otherwise false.
        /// </summary>
        public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var existing = _employees.FirstOrDefault(emp => emp.Id == id);

            if (existing != null)
            {
                _employees.Remove(existing);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        /// <summary>
        /// Retrieves all employees in the system.
        /// Returns the internal list as an IList for read-only consumption by the caller.
        /// </summary>
        public Task<IList<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult((IList<Employee>)_employees);
        }

        /// <summary>
        /// Retrieves an employee by its unique identifier.
        /// Returns null if no employee matches the provided Id.
        /// </summary>
        public Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_employees.FirstOrDefault(emp => emp.Id == id));
        }

        /// <summary>
        /// Updates an existing employee.
        /// Looks for the index of the employee and replaces the stored entity.
        /// Returns false if the employee does not exist.
        /// </summary>
        public Task<bool> UpdateAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            //Searches for the index; if a match is found, returns the object; otherwise, returns -1.
            var existingIndex = _employees.FindIndex(emp => emp.Id == employee.Id);

            if (existingIndex == 1)
                return Task.FromResult(false);

            else
            {
                _employees[existingIndex] = employee;
                return Task.FromResult(true);
            }
        }

        /// <summary>
        /// Populates the repository with initial employees.
        /// Useful for demo/testing scenarios where data is required from startup.
        /// </summary>
        private void SeedEmployee()
        {
            var employee1 = new Employee(
                "John",
                "Doe",
                new DateOnly(1990, 5, 12),
                "402-2507347-3",
                "john.doe@example.com",
                "Backend Developer",
                new DateOnly(2020, 1, 10),
                isActive: true);

            var employee2 = new Employee(
                "Jane",
                "Smith",
                new DateOnly(1988, 3, 25),
                "402-2507347-3",
                "jane.smith@example.com",
                "Project Manager",
                new DateOnly(2018, 7, 1),
                isActive: true);


            var employee3 = new Employee(
                "Carlos",
                "Perez",
                new DateOnly(1995, 9, 3),
                "402-2507347-3",
                "carlos.perez@example.com",
                "QA Engineer",
                new DateOnly(2021, 11, 20),
                isActive: true);

            _employees.AddRange(new List<Employee> { employee1, employee2, employee3 });

        }
    }
}
