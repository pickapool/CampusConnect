using CamCon.Shared;
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
            request.RequestUrl = defaultRequestUrl = $"{_configuration["BaseAPI:Url"]}/api/sentiment";
        }
        public async Task<Result> AddSentimentAsync(SentimentModel sentiment)
        {
            request.RequestUrl = defaultRequestUrl;
            request.RequestType = Enums.RequestType.POST;
            request.Data = sentiment.Wrap("sentiment");

            var response = await _baseService.SendAsync<Result>(request);

            return response;
        }

        public async Task<Result> DeleteSentimentAsync(SentimentModel sentiment)
        {
            request.RequestUrl = defaultRequestUrl;
            request.RequestType = Enums.RequestType.DELETE;
            request.Data = sentiment.Wrap("sentiment");

            var response = await _baseService.SendAsync<Result>(request);

            return response;
        }

        public async Task<List<SentimentModel>> GetSentimentsAsync()
        {
            request.RequestUrl = defaultRequestUrl;
            request.RequestType = Enums.RequestType.GET;
            request.Data = null;

            var response = await _baseService.SendAsync<List<SentimentModel>>(request);

            return response;
        }
    }
}
