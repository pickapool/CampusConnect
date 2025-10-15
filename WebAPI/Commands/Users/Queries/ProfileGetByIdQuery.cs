using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationDBContextService;
using WebAPI.Interfaces;

namespace WebAPI.Commands.Users.Queries
{
    public record ProfileGetByIdQuery(Guid id) :IRequest<Result<ProfileInfo>>;

    public class ProfileGetByIdQueryHandler : AppDatabaseBase, IRequestHandler<ProfileGetByIdQuery, Result<ProfileInfo>>
    {
        public ProfileGetByIdQueryHandler(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<ProfileInfo>> Handle(ProfileGetByIdQuery request, CancellationToken cancellationToken)
        {
            var profile = await GetDBContext().ProfileInformations.FirstOrDefaultAsync( p => p.ProfileInformationId == request.id);

            if(profile == null)
                return Result.Failure<ProfileInfo>(new Error(StatusCodes.Status404NotFound, "Profile Not found."));

            return Result.Success(profile);
        }
    }
}
