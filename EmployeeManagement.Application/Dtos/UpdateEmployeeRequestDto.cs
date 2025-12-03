namespace EmployeeManagement.Application.Dtos
{
    public class UpdateEmployeeRequestDto
    {
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime BirthDate { get; set; }
        public string IdentityNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Position { get; set; } = default!;
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
    }
}
