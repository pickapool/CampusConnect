using CamCon.Shared;
using CamCon.Shared.Extensions;
using Domain;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Service.Interfaces;

namespace Service.Services.PageRequestServices
{
    public class PageRequestService : IPageRequestService
    {
        private readonly IConfiguration _configuration;

        private readonly IBaseService _baseService;

        private readonly string defaultRequestUrl;

        private RequestModel request = new();

        public PageRequestService(IConfiguration configuration, IBaseService baseService)
        {
            _configuration = configuration;
            _baseService = baseService;
            request.RequestUrl = defaultRequestUrl = $"{_configuration["BaseAPI:Url"]}/api/pagerequest"; ;
        }

        public async Task<Result> CreatePageRequestAsync(AdminPageRequestModel model)
        {
            request.RequestUrl = $"{defaultRequestUrl}/create";
            request.RequestType = Enums.RequestType.POST;
            request.Data = model.Wrap("request");

            var response = await _baseService.SendAsync<Result>(request);

            return response;
        }

        public async Task<Result> UpdatePageRequestAsync(AdminPageRequestModel model, Guid notificationId)
        {
            request.RequestUrl = $"{defaultRequestUrl}/{notificationId}";
            request.RequestType = Enums.RequestType.PUT;
            request.Data = model;

            var response = await _baseService.SendAsync<Result>(request);

            return response;
        }
    }
}
