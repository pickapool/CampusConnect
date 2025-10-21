using CamCon.Domain;
using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebAPI.ApplicationDBContextService;
using WebAPI.Commands.Notifications.Events;
using WebAPI.Commands.Users.Commands.ProfileCommands;
using WebAPI.Interfaces;

namespace WebAPI.Commands.AdminPageRequests.Commands
{
    public record UpdateRequestAdminCommand(AdminPageRequestModel Request, Guid NotificationId) : IRequest<Result>;

    public class UpdateRequestAdminCommandHandler : AppDatabaseBase, IRequestHandler<UpdateRequestAdminCommand, Result>
    {

        private readonly IMediator _mediator;
        public UpdateRequestAdminCommandHandler(AppDbContext context, IMediator mediator) : base(context)
        {
            _mediator = mediator;
        }

        public async Task<Result> Handle(UpdateRequestAdminCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pageRequest = await GetDBContext().RequestPages.FirstOrDefaultAsync(rp => rp.AdminPageRequestId == request.Request.AdminPageRequestId);

                var notify = await GetDBContext().Notifications.FirstOrDefaultAsync(rp => rp.NotifyId == request.NotificationId);

                if (pageRequest is null || notify is null)
                    return Result.Failure(new Error(StatusCodes.Status404NotFound, "Page request not found."));

                if (request.Request.MyOrganization is not null)
                    GetDBContext().Entry(request.Request.MyOrganization).State = EntityState.Unchanged;
                if(request.Request.User is not null)
                    GetDBContext().Entry(request.Request.User).State = EntityState.Unchanged;

                pageRequest.PageRequestStatus = request.Request.PageRequestStatus;

                notify.UpdatedAt = DateTime.UtcNow;
                notify.DataJson = JsonSerializer.Serialize(pageRequest);

                await GetDBContext().SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new UserNotificationEvent(notify.NotifyId, request.Request.Id));

                var profile = await GetDBContext().ProfileInformations.FirstOrDefaultAsync(p => p.ProfileInformationId == request.Request.User.ProfileInformationId, cancellationToken: cancellationToken);

                if(profile is not null)
                    await _mediator.Send(new UserUpdateProfileCommand(profile, true), cancellationToken);

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}
