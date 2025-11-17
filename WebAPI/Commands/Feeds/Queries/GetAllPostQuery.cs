using CamCon.Domain;
using CamCon.Shared;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationDBContextService;
using WebAPI.Interfaces;
using PaginationRequestModel = CamCon.Domain.PaginationRequestModel;
using PaginationResponseModel = CamCon.Domain.PaginationResponseModel;

namespace WebAPI.Commands.Feeds.Queries
{
    public record GetAllPostQuery(PaginationRequestModel request) : IRequest<Result<PaginationResponseModel>>;

    public class GetAllPostQueryHandler(AppDbContext context) : AppDatabaseBase(context), IRequestHandler<GetAllPostQuery, Result<PaginationResponseModel>>
    {
        public async Task<Result<PaginationResponseModel>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {

            if (request is null) return Result.Success(new PaginationResponseModel());

            var list = GetDBContext().NewsFeeds.AsQueryable().AsNoTracking();

            var result = await list
                .Include( c => c.Images)
                .Include( o => o.Likes)
                .Include( o => o.MyOrganization)
                .OrderByDescending( c => c.CreatedAt)
                .Skip(request.request.StartIndex)
                .Take(request.request.Count)
                .ToListAsync(cancellationToken: cancellationToken);

            return Result.Success(new PaginationResponseModel()
            {
                Count = list.Count(),
                Records = result
            });
        }
    }
}
