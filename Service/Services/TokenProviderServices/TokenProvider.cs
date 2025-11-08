using Blazored.LocalStorage;
using Domain.Models;
using Service.Interfaces;
using System.Text.Json;

namespace Service.Services.TokenProviderServices
{
    public class TokenProvider : ITokenProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public TokenProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public void ClearToken()
        {
            _localStorageService.RemoveItemAsync("token");
        }

        public async Task<TokenModel?> GetToken()
        {
            var token = await _localStorageService.GetItemAsync<TokenModel>("token");
            return token;
        }

        public void SetToken(TokenModel token)
        {
            _localStorageService.SetItemAsync("token", token);
        }
    }
}
