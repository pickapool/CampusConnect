using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.ApplicationDBContextService;
using WebAPI.Interfaces;

namespace WebAPI.Commands.Users.Commands.ProfileCommands
{
    public record UserUpdateProfileCommand(ProfileInfo profile) : IRequest<Result<ProfileInfo>>;

    public class UserUpdateProfileCommandHandler :AppDatabaseBase, IRequestHandler<UserUpdateProfileCommand, Result<ProfileInfo>>
    {
        public UserUpdateProfileCommandHandler(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<ProfileInfo>> Handle(UserUpdateProfileCommand request, CancellationToken cancellationToken)
        {

            var existingProfile = await GetDBContext().ProfileInformations
            .FirstOrDefaultAsync(p => p.ProfileInformationId == request.profile.ProfileInformationId, cancellationToken);

            if (existingProfile == null)
                return Result.Failure<ProfileInfo>(new Error(StatusCodes.Status404NotFound, "Profile Not found."));

            existingProfile.ProfilePicture = request.profile.ProfilePicture;

            await GetDBContext().SaveChangesAsync(cancellationToken);

            return Result.Success(existingProfile);
        }
    }
}
