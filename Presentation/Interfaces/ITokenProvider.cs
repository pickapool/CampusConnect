using Domain.Models;

namespace Presentation.Interfaces
{
    public interface ITokenProvider
    {
        void SetToken(TokenModel token);
        TokenModel GetToken();
        void ClearToken();
    }
}
