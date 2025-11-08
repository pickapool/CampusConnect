using CamCon.Shared;
using CamCon.Shared.Extensions;
using Domain;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Service.Interfaces;

namespace Service.Services.ProfileServices
{
    public class ProfileService : IProfileService
    {
        private readonly IConfiguration _configuration;

        private readonly IBaseService _baseService;

        private readonly string defaultRequestUrl;

        private RequestModel request = new();

        public ProfileService(IConfiguration configuration, IBaseService baseService)
        {
            _configuration = configuration;
            _baseService = baseService;
            request.RequestUrl = defaultRequestUrl = $"{_configuration["BaseAPI:Url"]}/api/profile";
        }

        public async Task<ProfileInfo> UpdateProfile(ProfileInfo model)
        {
            request.RequestType = Enums.RequestType.PUT;
            request.Data = model.Wrap("profile");

            var response = await _baseService.SendAsync<ProfileInfo>(request);

            return response;
        }
    }
}
