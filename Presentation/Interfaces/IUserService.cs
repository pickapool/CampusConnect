using CamCon.Domain.Models;

namespace Presentation.Interfaces
{
    public interface IUserService
    {
        Task<TokenModel> Authenticate(LoginModel loginModel);
    }
}
