using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Notifiers
{
    public class HubNotificationService : IAsyncDisposable
    {
        private HubConnection? _hubConnection;
        private HubConnection? _hubConnection2;
        private HubConnection? _hubConnection3;
        private readonly LayoutNotifierService layoutNotifierService;
        private readonly IConfiguration configuration;
        private bool _disposed = false;

        public HubNotificationService(LayoutNotifierService layoutNotifierService, IConfiguration configuration)
        {
            this.layoutNotifierService = layoutNotifierService;
            this.configuration = configuration;
        }

        public async Task StartAdminNotificationConnection()
        {
            if (_hubConnection != null && _hubConnection.State == HubConnectionState.Connected)
                return;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl($"{configuration["BaseAPI:Url"]}/hubs/notifications")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<Guid>("AdminNotification", (notificationId) =>
            {

                layoutNotifierService?.AdminNotificationReceived(notificationId);

            });

            await _hubConnection.StartAsync();
        }

        public async Task StartAllNotificationConnection()
        {
            if (_hubConnection2 != null && _hubConnection2.State == HubConnectionState.Connected)
                return;

            _hubConnection2 = new HubConnectionBuilder()
                .WithUrl($"{configuration["BaseAPI:Url"]}/hubs/notifications", options =>
                {
                    options.HttpMessageHandlerFactory = handler =>
                    {
                        return handler;
                    };

                    options.Transports = HttpTransportType.WebSockets;
                })
                .WithAutomaticReconnect()
                .Build();

            _hubConnection2.On<Guid>("AllNotification", (notificationId) =>
            {
                layoutNotifierService?.AllNotificationReceived(notificationId);

            });

            await _hubConnection2.StartAsync();
        }

        public async Task StartUserNotificationConnection(string? accessToken = null)
        {
            if (_hubConnection3 != null && _hubConnection3.State == HubConnectionState.Connected)
                return;

            _hubConnection3 = new HubConnectionBuilder()
                .WithUrl($"{configuration["BaseAPI:Url"]}/hubs/notifications?access_token={accessToken}", options =>
                {
                    options.HttpMessageHandlerFactory = handler =>
                    {
                        return handler;
                    };
                    options.AccessTokenProvider = () => Task.FromResult(accessToken);
                    options.Transports = HttpTransportType.WebSockets;
                })
                .WithAutomaticReconnect()
                .Build();

            _hubConnection3.On<Guid>("UserNotification", (notificationId) =>
            {
                Console.WriteLine($"UserNotification received: {notificationId}");
                layoutNotifierService?.UserNotificationReceived(notificationId);
            });

            await _hubConnection3.StartAsync();
        }

        public async Task StopConnectionAsyncAdmin()
        {
            if (_hubConnection != null)
                await _hubConnection.StopAsync();
        }

        public async Task StopConnectionAsyncUser()
        {
            if (_hubConnection3 != null)
                await _hubConnection3.StopAsync();
        }

        public async Task StopConnectionAsyncAll()
        {
            if (_hubConnection2 != null)
                await _hubConnection2.StopAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed)
                return;

            _disposed = true;

            if (_hubConnection != null)
            {
                try
                {
                    if (_hubConnection.State == HubConnectionState.Connected)
                    {
                        await _hubConnection.StopAsync();
                    }

                    await _hubConnection.DisposeAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error disposing hub connection: {ex.Message}");
                }
                finally
                {
                    _hubConnection = null;
                }
            }
        }
    }
}
