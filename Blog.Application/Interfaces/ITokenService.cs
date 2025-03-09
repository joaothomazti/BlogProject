using Blog.Domain.Models;

namespace Blog.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
