using Blazored.LocalStorage;
using Domain.Models;
using Presentation.Interfaces;
using System.Text.Json;

namespace Presentation.Services.TokenProviderServices
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
            return await _localStorageService.GetItemAsync<TokenModel>("token");
        }

        public void SetToken(TokenModel token)
        {
            _localStorageService.SetItemAsync("token", token);
        }
    }
}
