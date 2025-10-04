using CamCon.Domain;

namespace Presentation.Interfaces
{
    public interface IBaseService
    {
        Task<T> SendAsync<T>(RequestModel request);
    }
}
