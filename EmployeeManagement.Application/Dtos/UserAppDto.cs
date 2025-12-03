namespace EmployeeManagement.Application.Dtos
{
    public class UserAppDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
    }
}
