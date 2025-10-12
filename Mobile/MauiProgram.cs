using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mobile.Authentication;
using Mobile.Global;
using MudBlazor.Services;
using Service.Interfaces;
using Service.Services.BaseService;
using Service.Services.DepartmentServices;
using Service.Services.OrganizationServices;
using Service.Services.TokenProviderServices;
using Service.Services.UserServices;
using System.Reflection;

namespace Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            AddAppSetting(builder);

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationState>();
            builder.Services.AddHttpClient();
            builder.Services.AddMudServices();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenProvider, TokenProvider>();
            builder.Services.AddScoped<IOrganizationService, OrganizationService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();

            AddHttpCerficate();

            return builder.Build();
        }
        private static void AddHttpCerficate()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            var httpClient = new HttpClient(handler);
        }
        private static void AddAppSetting(MauiAppBuilder builder)
        {
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Mobile.appsettings.mobile.json");

            if (stream != null)
            {
                builder.Configuration.AddJsonStream(stream);
            }

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["BaseAPI:Url"]!) });
        }
    }
}
