using Domain.Models;

namespace Service.Interfaces
{
    public interface ITokenProvider
    {
        void SetToken(TokenModel token);
        Task<TokenModel?> GetToken();
        void ClearToken();
    }
}
