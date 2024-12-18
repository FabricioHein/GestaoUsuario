// Services/AuthService.cs
using GestaoUsuario.Interface;
using GestaoUsuario.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace GestaoUsuario.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;

            _configuration = configuration;
        }

        public async Task<string> Register(User user)
        {
            var existingUser = await this._userRepository.GetUserByEmailAsync(user.Email);

            if (existingUser == null)
            {
                // Hashing password, adding user, etc.
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                await this._userRepository.AddUserAsync(user);
                return "User registered successfully.";
            }

            return "Email is already registered.";


        }

        public async Task<string> Login(User user)
        {
            var dbUser = await this._userRepository.GetUserByEmailAsync(user.Username);
            if (dbUser == null || !BCrypt.Net.BCrypt.Verify(user.Password, dbUser.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, dbUser.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
