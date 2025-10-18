using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationDBContextService;
using WebAPI.Interfaces;

namespace WebAPI.Commands.Notifications.Queries
{
    public record GetAllNotificationsQuery : IRequest<Result<List<NotifyModel>>>;
   
    public class GetAllNotificationsQueryHandler : AppDatabaseBase, IRequestHandler<GetAllNotificationsQuery, Result<List<NotifyModel>>>
    {
        public GetAllNotificationsQueryHandler(AppDbContext context) : base(context) { }

        public async Task<Result<List<NotifyModel>>> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var notifications = await GetDBContext().Notifications.ToListAsync(cancellationToken);

                return Result.Success(notifications);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<NotifyModel>>(new Error(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}
