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

    public class NotificationHandler : INotificationHandler<NotificationEvent>
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<NotificationHandler> _logger;

        public NotificationHandler(
            IHubContext<NotificationHub> hubContext,
            ILogger<NotificationHandler> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task Handle(NotificationEvent notification, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Sending user notification: {NotificationId}", notification.NotificationId);

                await _hubContext.Clients.All.SendAsync("UserNotification", notification.NotificationId, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending user notification: {NotificationId}", notification.NotificationId);
            }
        }
    }
}
