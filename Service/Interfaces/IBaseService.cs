using Domain;

namespace Service.Interfaces
{
    public interface IBaseService
    {
        Task<T> SendAsync<T>(RequestModel request);
    }
}
