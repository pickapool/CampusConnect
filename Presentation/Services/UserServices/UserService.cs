using Domain;
using Domain.Models;
using Infrastructure.Extensions;
using Presentation.Interfaces;

namespace Presentation.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;

        private readonly IBaseService _baseService;

        private readonly string defaultRequestUrl;

        private RequestModel request = new();

        public UserService(IConfiguration configuration, IBaseService baseService)
        {
            _configuration = configuration;
            _baseService = baseService;
            defaultRequestUrl = $"{_configuration["BaseAPI:Url"]}/api/auth";
        }

        public async Task<TokenModel> Authenticate(LoginModel model)
        { 
            request.RequestUrl = $"{defaultRequestUrl}/login";
            request.RequestType = Enums.RequestType.POST;
            request.Data = model.Wrap("request"); 

            var response = await _baseService.SendAsync<TokenModel>(request);

            return response;
        }
    }
}
