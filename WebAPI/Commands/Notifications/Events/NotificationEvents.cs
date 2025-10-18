using MediatR;

namespace WebAPI.Commands.Notifications.Events
{
    public record NotificationEvent(Guid NotificationId) : INotification;

    public record AdminNotificationEvent(Guid NotificationId) : INotification;

    public record UserNotificationEvent(Guid NotificationId, string UserId) : INotification;
}
