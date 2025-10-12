using CamCon.Shared;
using CamCon.Shared.Extensions;
using Domain;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Service.Interfaces;

namespace Service.Services.DepartmentServices
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IConfiguration _configuration;

        private readonly IBaseService _baseService;

        private readonly string defaultRequestUrl;

        private RequestModel request = new();

        public DepartmentService(IConfiguration configuration, IBaseService baseService)
        {
            _configuration = configuration;
            _baseService = baseService;
            request.RequestUrl = defaultRequestUrl = $"{_configuration["BaseAPI:Url"]}/api/dept";
        }

        public async Task<Result> CreateDepartmentAsync(DepartmentModel model)
        {
            request.RequestType = Enums.RequestType.POST;
            request.Data = model.Wrap("department");
            request.RequestUrl = $"{defaultRequestUrl}/create";

            return await _baseService.SendAsync<Result>(request);
        }

        public Task<Result> DeleteDepartmentAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DepartmentModel>> GetAllDepartmentsAsync()
        {
            request.RequestType = Enums.RequestType.GET;
            request.Data = null;
            request.RequestUrl = defaultRequestUrl;

            var response = await _baseService.SendAsync<List<DepartmentModel>>(request);

            return response;
        }

        public Task<DepartmentModel?> GetDepartmentByIdAsync(Guid departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> UpdateDepartmentAsync(DepartmentModel mode)
        {
            throw new NotImplementedException();
        }
    }
}
