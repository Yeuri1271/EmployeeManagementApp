namespace EmployeeManagement.Application.Dtos
{
    public class LoginResponseDto
    {
        public string UserName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
