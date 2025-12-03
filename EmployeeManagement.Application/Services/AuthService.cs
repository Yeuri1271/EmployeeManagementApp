using EmployeeManagement.Application.Dtos;
using EmployeeManagement.Application.Interfaces;

namespace EmployeeManagement.Application.Services
{
    public class AuthService
    {
        private readonly IUserAppRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IUserAppRepository userAppRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userAppRepository;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto loginRequest, CancellationToken cancellation = default)
        {
            var user = await _userRepository.GetByUsernameAsync(loginRequest.UserName);

            if (user == null)
                return null;


            if (!string.Equals(user.Password, loginRequest.Password))
                return null;

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task<IList<UserAppDto>> GetUsersAsync(CancellationToken cancellation = default)
        {
            var users = await _userRepository.GetAllASync(cancellation);

            return users.Select(user => new UserAppDto
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,

            }).ToList();
        }
    }
}
