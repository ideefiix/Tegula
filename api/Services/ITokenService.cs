using api.Models.Dtos;

namespace api.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, PlayerDTO user);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}