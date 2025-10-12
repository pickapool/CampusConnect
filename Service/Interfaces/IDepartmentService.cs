using CamCon.Shared;
using Domain.Models;

namespace Service.Interfaces
{
    public interface IDepartmentService
    {
        Task<Result> CreateDepartmentAsync(DepartmentModel model);
        Task<Result> UpdateDepartmentAsync(DepartmentModel mode);
        Task<Result> DeleteDepartmentAsync(Guid departmentId);
        Task<DepartmentModel?> GetDepartmentByIdAsync(Guid departmentId);
        Task<List<DepartmentModel>> GetAllDepartmentsAsync();
    }
}
