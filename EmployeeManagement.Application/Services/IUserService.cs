using EmployeeManagement.Core.DTOs;
namespace EmployeeManagement.Application.Services
{
    public interface IUserService
    {
        Task<AuthResponseDto> RegisterUserAsync(RegisterDto registerDto);

        Task<AuthResponseDto> LoginUserAsync(LoginDto loginDto);

        string GenerateToken(int userId, string email, string role);
      

    }
}
