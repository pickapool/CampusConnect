using CamCon.Shared;
using Domain.Models;

namespace Service.Interfaces
{
    public interface IPageRequestService
    {
        Task<Result> CreatePageRequestAsync(AdminPageRequestModel model);
        Task<Result> UpdatePageRequestAsync(AdminPageRequestModel model, Guid notificationId);
    }
}
