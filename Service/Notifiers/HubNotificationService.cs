using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Notifiers
{
    public class HubNotificationService
    {
        private HubConnection? _hubConnection;
        private readonly LayoutNotifierService layoutNotifierService;
        private readonly IConfiguration configuration;

        public HubNotificationService(LayoutNotifierService layoutNotifierService, IConfiguration configuration)
        {
            this.layoutNotifierService = layoutNotifierService;
            this.configuration = configuration;
        }

        public async Task StartAdminConnection()
        {
            if (_hubConnection != null && _hubConnection.State == HubConnectionState.Connected)
                return;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"{configuration["BaseAPI:Url"]}/hubs/notifications")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<Guid>("AdminNotification", (notification) =>
            {

                layoutNotifierService?.NotificationReceived(notification);

            });

            await _hubConnection.StartAsync();
        }

        public async Task StartUserConnection()
        {
            if (_hubConnection != null && _hubConnection.State == HubConnectionState.Connected)
                return;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"{configuration["BaseAPI:Url"]}/hubs/notifications")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<Guid>("UserNotification", (notification) =>
            {

                layoutNotifierService?.NotificationReceived(notification);

            });

            await _hubConnection.StartAsync();
        }

        public async Task StopConnectionAsync()
        {
            if (_hubConnection != null)
                await _hubConnection.StopAsync();
        }
    }
}
