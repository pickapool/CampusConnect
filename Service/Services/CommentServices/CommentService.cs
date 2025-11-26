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

namespace Service.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly IConfiguration _configuration;

        private readonly IBaseService _baseService;

        private readonly string defaultRequestUrl;

        private RequestModel request = new();

        public CommentService(IConfiguration configuration, IBaseService baseService)
        {
            _configuration = configuration;
            _baseService = baseService;
            request.RequestUrl = defaultRequestUrl = $"{_configuration["BaseAPI:Url"]}/api/comment";
        }


        public async Task<NewsFeedCommentModel> AddCommentAsync(NewsFeedCommentModel model)
        {
            request.RequestType = Enums.RequestType.POST;
            request.Data = model.Wrap("request");
            request.RequestUrl = defaultRequestUrl;

            return await _baseService.SendAsync<NewsFeedCommentModel>(request);
        }

        public async Task<NewsFeedCommentModel> DeleteComment(Guid guid)
        {
            request.RequestType = Enums.RequestType.DELETE;
            request.Data = null;
            request.RequestUrl = $"{defaultRequestUrl}/{guid}";

            return await _baseService.SendAsync<NewsFeedCommentModel>(request);
        }

        public async Task<NewsFeedCommentModel> FlaggedComment(Guid guid)
        {
            request.RequestType = Enums.RequestType.DELETE;
            request.Data = null;
            request.RequestUrl = $"{defaultRequestUrl}/flagged/{guid}";

            return await _baseService.SendAsync<NewsFeedCommentModel>(request);

        }

        public async Task<List<NewsFeedCommentModel>> GetCommentsByNewsFeedIdAsync(Guid newsFeedId)
        {
            request.RequestType = Enums.RequestType.GET;
            request.Data = null;
            request.RequestUrl = $"{defaultRequestUrl}/{newsFeedId}";

            return await _baseService.SendAsync<List<NewsFeedCommentModel>>(request);
        }
    }
}
