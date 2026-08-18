using EmployeeManagement.Core.Abstraction;
using EmployeeManagement.Core.Abstraction.Repositories;
using EmployeeManagement.Core.DTOs;
namespace EmployeeManagement.Application.Services
{
  public   class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string GenerateToken(int userId, string email, string role)
        {
           var token= _userRepository.GenerateToken(userId, email, role);
            return token;
        }
        public async   Task<AuthResponseDto> RegisterUserAsync(RegisterDto registerDto)
        {
          return await   _userRepository.RegisterUserAsync(registerDto);
        }

       public async  Task<AuthResponseDto> LoginUserAsync(LoginDto loginDto)
        {
            return await _userRepository.LoginUserAsync(loginDto);

        }

      

    }
}
