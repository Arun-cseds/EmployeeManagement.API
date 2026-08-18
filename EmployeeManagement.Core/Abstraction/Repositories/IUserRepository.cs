using EmployeeManagement.Core.DTOs;

namespace EmployeeManagement.Core.Abstraction.Repositories
{
    public  interface IUserRepository
    {
        Task<AuthResponseDto> RegisterUserAsync(RegisterDto registerDto);

        Task<AuthResponseDto> LoginUserAsync(LoginDto loginDto);

        string GenerateToken(int userId, string email, string role);
    }
}
