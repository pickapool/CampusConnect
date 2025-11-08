using CamCon.Domain;
using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationDBContextService;
using WebAPI.Interfaces;

namespace WebAPI.Commands.Feeds.Queries
{
    public record GetAllPostQuery(PaginationRequestModel request) : IRequest<Result<List<NewsFeedModel>>>;

    public class GetAllPostQueryHandler(AppDbContext context) : AppDatabaseBase(context), IRequestHandler<GetAllPostQuery, Result<List<NewsFeedModel>>>
    {
        public async Task<Result<List<NewsFeedModel>>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {

            if (request is null) return Result.Success(new List<NewsFeedModel>());

            var result = await GetDBContext().NewsFeeds
                .Include( c => c.Images)
                .Include( o => o.MyOrganization)
                .Skip(request.request.StartIndex)
                .Take(request.request.Count)
                .ToListAsync(cancellationToken: cancellationToken);

            return Result.Success(result);
        }
    }
}
