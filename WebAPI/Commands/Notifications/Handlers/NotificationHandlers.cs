using MediatR;
using Microsoft.AspNetCore.SignalR;
using WebAPI.Commands.Notifications.Events;
using WebAPI.NotifyHub;

namespace WebAPI.Commands.Notifications.Handlers
{
    public class AdminNotificationHandler : INotificationHandler<AdminNotificationEvent>
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<AdminNotificationHandler> _logger;

        public AdminNotificationHandler(
            IHubContext<NotificationHub> hubContext,
            ILogger<AdminNotificationHandler> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task Handle(AdminNotificationEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Sending admin notification: {NotificationId}", notification.NotificationId);

                await _hubContext.Clients.All.SendAsync("AdminNotification", notification.NotificationId, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending admin notification: {NotificationId}", notification.NotificationId);
            }
        }
    }

    public class AllNotificationHandler : INotificationHandler<AllNotificationEvent>
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<AllNotificationHandler> _logger;

        public AllNotificationHandler(
            IHubContext<NotificationHub> hubContext,
            ILogger<AllNotificationHandler> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task Handle(AllNotificationEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Sending notification: {NotificationId}", notification.NotificationId);

                await _hubContext.Clients.All.SendAsync("AllNotification", notification.NotificationId, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending user notification: {NotificationId}", notification.NotificationId);
            }
        }
    }

    public class UserNotificationHandler : INotificationHandler<UserNotificationEvent>
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<UserNotificationHandler> _logger;

        public UserNotificationHandler(
            IHubContext<NotificationHub> hubContext,
            ILogger<UserNotificationHandler> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task Handle(UserNotificationEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Sending user notification: {NotificationId}", notification.NotificationId);

                await _hubContext.Clients.User(notification.UserId).SendAsync("UserNotification", notification.NotificationId, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending user notification: {NotificationId}", notification.NotificationId);
            }
        }
    }
}
