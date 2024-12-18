// Services/IAuthService.cs
using GestaoUsuario.Models;

namespace GestaoUsuario.Services
{
    public interface IAuthService
    {
        Task<string> Register(User user);
        Task<string> Login(User user);
    }
}
