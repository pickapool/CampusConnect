using Domain.Models;

namespace Presentation.Interfaces
{
    public interface ITokenProvider
    {
        void SetToken(TokenModel token);
        Task<TokenModel?> GetToken();
        void ClearToken();
    }
}
