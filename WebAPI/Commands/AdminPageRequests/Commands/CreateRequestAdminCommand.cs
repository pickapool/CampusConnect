using CamCon.Domain;
using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebAPI.ApplicationDBContextService;
using WebAPI.Commands.Notifications.Commands;
using WebAPI.Interfaces;

namespace WebAPI.Commands.AdminPageRequests.Commands
{
    public record CreateRequestAdminCommand(AdminPageRequestModel Request) : IRequest<Result>;

    public class CreateRequestAdminCommandHandler : AppDatabaseBase, IRequestHandler<CreateRequestAdminCommand, Result>
    {
        public CreateRequestAdminCommandHandler(AppDbContext context, IMediator Mediator) : base(context)
        {
            this.Mediator = Mediator;
        }

        public IMediator Mediator { get; }

        public async Task<Result> Handle(CreateRequestAdminCommand request, CancellationToken cancellationToken)
        {
            try
            {

                if(request.Request.User is not null)
                    GetDBContext().Entry(request.Request.User).State = EntityState.Unchanged;
                if (request.Request.MyOrganization is not null)
                    GetDBContext().Entry(request.Request.MyOrganization).State = EntityState.Unchanged;

                await GetDBContext().RequestPages.AddAsync(request.Request, cancellationToken);

                await GetDBContext().SaveChangesAsync(cancellationToken);

                var notification = new NotifyModel<AdminPageRequestModel>
                {
                    NotificationType = Enums.NotificationType.PageRequest,
                    DataJson = JsonSerializer.Serialize(request.Request),
                };

                await Mediator.Send(new CreateNotificationCommand(notification), cancellationToken);

                return Result.Success("Admin request created successfully.");
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error(StatusCodes.Status500InternalServerError, ex.Message));
            }
        }
    }
}
