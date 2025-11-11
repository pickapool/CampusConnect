using CamCon.Shared;
using CamCon.Shared.Extensions;
using Domain;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.NewsFeedServices
{
    public class NewsFeedService : INewsFeedService
    {
        private readonly IConfiguration _configuration;

        private readonly IBaseService _baseService;

        private readonly string defaultRequestUrl;

        private RequestModel request = new();

        public NewsFeedService(IConfiguration configuration, IBaseService baseService)
        {
            _configuration = configuration;
            _baseService = baseService;
            request.RequestUrl = defaultRequestUrl = $"{_configuration["BaseAPI:Url"]}/api/post";
        }
            
        public async Task CreatePost(NewsFeedModel model)
        {
            request.RequestUrl = defaultRequestUrl;
            request.RequestType = Enums.RequestType.POST;
            request.Data = model.Wrap("newsfeed");

            await _baseService.SendAsync<Result>(request);

        }

        public Task<List<NewsFeedModel>> GetNewsFeedById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<PaginationResponseModel> GetNewsFeeds(PaginationRequestModel model)
        {
            request.RequestUrl = $"{defaultRequestUrl}/getall";
            request.RequestType = Enums.RequestType.POST;
            request.Data = model.Wrap("request");

            return await _baseService.SendAsync<PaginationResponseModel>(request);
        }

        public Task<NewsFeedModel> GetPostById(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
