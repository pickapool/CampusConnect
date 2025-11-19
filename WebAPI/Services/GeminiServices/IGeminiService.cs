using CamCon.Domain.Enitity;

namespace WebAPI.Services.GeminiServices
{
    public interface IGeminiService
    {
        Task<List<Guid>> ModerateCommentsAsync(List<NewsFeedCommentModel> comments, List<string> badWords);
    }
}
