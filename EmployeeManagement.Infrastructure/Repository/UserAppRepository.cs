using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Infrastructure.Repository
{
    internal class UserAppRepository : IUserAppRepository
    {
        // In-memory storage mimicking a data source for demo/testing purposes.
        // This repository does not persist data; it resets on application restart.
        private readonly List<UserApp>? _users = new();

        public UserAppRepository()
        {
            Seed();
        }

        /// <summary>
        /// Retrieves all users from the in-memory collection.
        /// This method returns a copy of the list to avoid exposing internal references.
        /// </summary>
        public Task<IList<UserApp>> GetAllASync(CancellationToken cancellation = default)
        {
            var users = _users.ToList();

            return Task.FromResult((IList<UserApp>)users);
        }

        /// <summary>
        /// Retrieves a user by username using case-insensitive matching.
        /// Returns null if the user does not exist.
        /// </summary>
        public Task<UserApp?> GetByUsernameAsync(string username, CancellationToken cancellation = default)
        {
            var user = _users.SingleOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(user);
        }

        /// <summary>
        /// Seeds the in-memory collection with predefined test users.
        /// This is only intended for initial demo purposes and not for production use.
        /// </summary>
        private void Seed()
        {
            var user1 = new UserApp("yeuri1271", "Admin123", "Yeuri", "Reyes");
            var user2 = new UserApp("madelyn1104", "User111", "Madelyn", "Pujols");
            var user3 = new UserApp("ally023", "guess122", "Ally", "Reyes");

            _users.AddRange(new List<UserApp> { user1, user2, user3 });
        }
    }
}
