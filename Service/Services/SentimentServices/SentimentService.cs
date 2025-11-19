using CamCon.Shared.Extensions;
using Domain;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.SentimentServices
{
    public class SentimentService : ISentimentService
    {
        private readonly IConfiguration _configuration;

        private readonly IBaseService _baseService;

        private readonly string defaultRequestUrl;

        private RequestModel request = new();

        public SentimentService(IConfiguration configuration, IBaseService baseService)
        {
            _configuration = configuration;
            _baseService = baseService;
            request.RequestUrl = defaultRequestUrl = $"{_configuration["BaseAPI:Url"]}/api/ai";
        }
        public async Task<List<NewsFeedCommentModel>> AnalyzeSentimentsAsync(List<string> badWords)
        {
            request.RequestUrl = defaultRequestUrl;
            request.RequestType = Enums.RequestType.POST;
            request.Data = badWords.Wrap("sentiments");

            var response = await _baseService.SendAsync<List<NewsFeedCommentModel>>(request);

            return response;
        }
    }
}
