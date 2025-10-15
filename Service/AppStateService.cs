using Domain.Models;

namespace Service
{
    public class AppStateService
    {
        public ApplicationUserModel CurrentUser { get; set; } = new();
    }
}
