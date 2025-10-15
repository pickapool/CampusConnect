﻿using Blazored.LocalStorage;
using Domain.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Service;
using Service.Interfaces;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mobile.Authentication
{
    public class CustomAuthenticationState : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IJSRuntime _jsRuntime;
        private readonly IUserService _userService;
        private readonly AppStateService _appstateService;

        public CustomAuthenticationState(ILocalStorageService localStorage, IJSRuntime jsRuntime, IUserService userService, AppStateService appStateService)
        {
            _localStorage = localStorage;
            _jsRuntime = jsRuntime;
            _userService = userService;
            _appstateService = appStateService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_jsRuntime is IJSInProcessRuntime)
            {
                //do nothing
            }
            else if (_jsRuntime is null)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            try
            {
                var currentToken = await _localStorage.GetItemAsStringAsync("token");
                if (!string.IsNullOrEmpty(currentToken))
                {
                    var claims = ParseClaimsFromJwt(currentToken);
                    var expClaim = claims?.FirstOrDefault(c => c.Type == "exp")?.Value;
                    if (expClaim != null && long.TryParse(expClaim, out long exp))
                    {
                        var expirationTime = DateTimeOffset.FromUnixTimeSeconds(exp);
                        if (expirationTime < DateTimeOffset.UtcNow)
                        {
                            await _localStorage.RemoveItemAsync("token");
                            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                        }
                    }
                    await GetAccount(currentToken);

                    var identity = new ClaimsIdentity(claims, "jwt");

                    return new AuthenticationState(new ClaimsPrincipal(identity));
                }
            }
            catch
            {
               
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        private IEnumerable<Claim>? ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return keyValuePairs?.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
        public async Task NotifyUserAuthentication(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));

            var userId = authenticatedUser.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            await GetAccount(userId);

            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            NotifyAuthenticationStateChanged(authState);
        }
        public void NotifyUserLogout()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private async Task GetAccount(string token)
        {
            try
            {
                //Can be remove if production ready
                await Task.Delay(3000);

                var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));

                var userId = authenticatedUser.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;


                var user = await _userService.GetUserById(userId!);

                _appstateService.CurrentUser = user;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
