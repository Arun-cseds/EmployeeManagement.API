using EmployeeManagement.Core.Abstraction;
using EmployeeManagement.Core.Abstraction.Repositories;
using EmployeeManagement.Core.DTOs;
using EmployeeManagement.Core.Entities;
using EmployeeManagement.Infrastructure.DBContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {

        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _passwordHasher;
        
        private readonly EmployeesDbContext _dbContext;


        public UserRepository(IConfiguration configuration, EmployeesDbContext dbContext)
        {
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<User>();
          
            _dbContext = dbContext;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public string GenerateToken(int userId, string email, string role)
        {
            // Secret Key
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            // Claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<AuthResponseDto> RegisterUserAsync(RegisterDto registerDto)
        {
            // Check if email already exists
            var existingUser = await GetByEmailAsync(registerDto.Email);

            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            // Create user
            var user = new User
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                Role = "Employee"
            };

            // Hash password
            user.PasswordHash = _passwordHasher.HashPassword(user, registerDto.Password);

            // Save user
            await AddAsync(user);
            await SaveChangesAsync();

            // Generate JWT
            var token = GenerateToken(user.UserId, user.Email, user.Role);

            // Return response
            return  new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Role = user.Role
            };
        }

        

        public  async Task<AuthResponseDto> LoginUserAsync(LoginDto loginDto)
        {
            // Find user by email
            var user = await GetByEmailAsync(loginDto.Email);

            if (user == null)
            {
                throw new Exception("Invalid email or password.");
            }

            // Verify password
            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                loginDto.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Invalid email or password.");
            }

            // Generate JWT token
            var token = GenerateToken(
                user.UserId,
                user.Email,
                user.Role);

            // Return response
            return   new AuthResponseDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                Token = token
            };
        }


    }
}

