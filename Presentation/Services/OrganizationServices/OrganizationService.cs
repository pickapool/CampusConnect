using CamCon.Shared;
using Domain;
using Domain.Models;
using Infrastructure.Extensions;
using Presentation.Interfaces;
using System.Reflection;

namespace Presentation.Services.OrganizationServices
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IConfiguration _configuration;

        private readonly IBaseService _baseService;

        private readonly string defaultRequestUrl;

        private RequestModel request = new();

        public OrganizationService(IConfiguration configuration, IBaseService baseService)
        {
            _configuration = configuration;
            _baseService = baseService;
            request.RequestUrl = defaultRequestUrl = $"{_configuration["BaseAPI:Url"]}/api/auth";
        }
        public async Task<Result> CreateOrganizationAsync(MyOrganizationModel model)
        {
            request.RequestUrl = $"{defaultRequestUrl}/create";
            request.RequestType = Enums.RequestType.POST;
            request.Data = model.Wrap("organization");

            var response = await _baseService.SendAsync<Result>(request);

            return response;
        }

        public Task<Result> DeleteOrganizationAsync(Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MyOrganizationModel>> GetAllOrganizationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MyOrganizationModel?> GetOrganizationByIdAsync(Guid organizationId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateOrganizationAsync(MyOrganizationModel mode)
        {
            throw new NotImplementedException();
        }
    }
}
