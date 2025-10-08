using Domain.Models;

namespace Presentation.Interfaces
{
    public interface IUserService
    {
        Task<TokenModel> Authenticate(LoginModel loginModel);
        Task<List<ApplicationUserModel>> GetAllUsers();
    }
}
