using Domain.Models;

namespace Service.Interfaces
{
    public interface INotificationService
    {
        Task<NotifyModel> GetByIdAsync(Guid notifyId);
        Task<List<NotifyModel>> GetAll();
    }
}
