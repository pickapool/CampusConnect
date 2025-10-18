using CamCon.Domain.Enitity;

namespace WebAPI.Services.NotificationService
{
    public interface INotificationService
    {
        Task SendToAllAsync(Guid id);
        Task SendToAdmin(Guid id);
    }
}
