namespace EmployeeManagement.Application.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; } = default!;
        public string LastName { get;  set; } = default!;
        public DateTime BirthDate { get;  set; }
        public string IdentityNumber { get;  set; } = default!;
        public string Email { get;  set; } = default!;
        public string Position { get;  set; } = default!;
        public DateTime HireDate { get;  set; }
        public bool IsActive { get;  set; }
        public int? Age { get;  set; }
    }
}
