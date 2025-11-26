using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationDBContextService;
using WebAPI.Interfaces;
using WebAPI.Services.GeminiServices;

namespace WebAPI.Commands.AICommands
{
    public record GetListOfCommentsSentimentsQuery(List<string> Sentiments) : IRequest<Result<List<NewsFeedCommentModel>>>;

    public class GetListOfCommentsSentimentsQueryHandler : AppDatabaseBase, IRequestHandler<GetListOfCommentsSentimentsQuery, Result<List<NewsFeedCommentModel>>>
    {
        private readonly IGeminiService _geminiService;

        public GetListOfCommentsSentimentsQueryHandler(AppDbContext context, IGeminiService geminiService) : base(context)
        {
            _geminiService = geminiService;
        }

        public IGeminiService GeminiService { get; }

        public async Task<Result<List<NewsFeedCommentModel>>> Handle(GetListOfCommentsSentimentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await GetDBContext().NewsFeedComments.ToListAsync(cancellationToken);

            comments = comments.Where(c => !c.IsFlagged && !c.IsDeleted).ToList();
            //AI for sentiment analysis simulation
            var sentimentsAI = await _geminiService.ModerateCommentsAsync(comments, request.Sentiments);

            var results = comments.Where(c => sentimentsAI.Any(s => s == c.NewsFeedCommentId)).ToList();
           
            return Result.Success(results);
        }
    }
}
