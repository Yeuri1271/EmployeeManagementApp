namespace EmployeeManagement.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public DateOnly BirthDate { get; private set; }
        public string IdentityNumber { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public string Position { get; private set; } = default!;
        public DateOnly HireDate { get; private set; }
        public bool IsActive { get; private set; }

        // This property is automatically calculated based on the BirthDate value.
        // Logic: Check if the birthday for the current year hasn't occurred yet. If so, reduce the age by 1.
        public int Age
        {
            get
            {
                var today = DateOnly.FromDateTime(DateTime.UtcNow);
                var age = today.Year - BirthDate.Year;
                if (new DateOnly(today.Year, BirthDate.Month, BirthDate.Day) > today)
                {
                    age--;
                }

                return age;
            }
        }

        public Employee(string name,
        string lastName,
        DateOnly birthDate,
        string identityNumber,
        string email,
        string position,
        DateOnly hireDate,
        bool isActive)
        {
            Id = Guid.NewGuid();
            Update(name, 
                lastName,
                birthDate,
                identityNumber,
                email,
                position,
                hireDate,
                isActive);
        }

        public void Update(string name,
            string lastName,
            DateOnly birthDate,
            string identityNumber,
            string email,
            string position,
            DateOnly hireDate,
            bool isActive)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            IdentityNumber = identityNumber;
            Email = email;
            Position = position;
            HireDate = hireDate;
            IsActive = isActive;
        }
    }
}
