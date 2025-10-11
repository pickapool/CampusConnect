using CamCon.Shared;
using Domain.Models;

namespace Presentation.Interfaces
{
    public interface IOrganizationService
    {
        Task<Result> CreateOrganizationAsync(MyOrganizationModel model);
        Task<Result> UpdateOrganizationAsync(MyOrganizationModel mode);
        Task<Result> DeleteOrganizationAsync(Guid organizationId);
        Task<MyOrganizationModel?> GetOrganizationByIdAsync(Guid organizationId);
        Task<List<MyOrganizationModel>> GetAllOrganizationsAsync();
    }
}
