using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationDBContextService;
using WebAPI.Commands.Notifications.Events;
using WebAPI.Interfaces;

namespace WebAPI.Commands.Organizations.Query
{
    public record GetOrganizationsQuery : IRequest<Result<List<MyOrganizationModel>>>;
    
    public class GetOrganizationsQueryHandler : AppDatabaseBase, IRequestHandler<GetOrganizationsQuery, Result<List<MyOrganizationModel>>>
    {
        private readonly IMediator mediator;
        public GetOrganizationsQueryHandler(AppDbContext context, IMediator mediator) : base(context) => this.mediator = mediator;

        public async Task<Result<List<MyOrganizationModel>>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizations = await GetDBContext().MyOrganizations
                .Include(m => m.User)
                .ThenInclude( u => u!.ProfileInformation)
                .ToListAsync(cancellationToken);

            await mediator.Publish(new UserNotificationEvent(new Guid("8E83D189-CE65-4515-C353-08DE0E3B9093"), "7b6df5ff-f5c8-40ab-bd28-89ea52dcd3df"), cancellationToken);

            return Result.Success(organizations);
        }
    }
}
