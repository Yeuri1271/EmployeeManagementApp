namespace EmployeeManagement.Domain.Models
{
    /// <summary>
    /// Domain entity representing an application user.
    /// This class contains only user-related data and basic invariants,
    /// without any persistence or infrastructure concerns.
    /// </summary>
    public class UserApp
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;

        public UserApp(string userName, string password, string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
