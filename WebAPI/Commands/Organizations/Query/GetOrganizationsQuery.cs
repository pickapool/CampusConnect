using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationDBContextService;
using WebAPI.Interfaces;

namespace WebAPI.Commands.Organizations.Query
{
    public record GetOrganizationsQuery : IRequest<Result<List<MyOrganizationModel>>>;
    
    public class GetOrganizationsQueryHandler : AppDatabaseBase, IRequestHandler<GetOrganizationsQuery, Result<List<MyOrganizationModel>>>
    {
        public GetOrganizationsQueryHandler(AppDbContext context) : base(context) { }

        public async Task<Result<List<MyOrganizationModel>>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizations = await GetDBContext().MyOrganizations
                .Include(m => m.User)
                .ThenInclude( u => u.ProfileInformation)
                .ToListAsync(cancellationToken);

            return Result.Success(organizations);
        }
    }
}
