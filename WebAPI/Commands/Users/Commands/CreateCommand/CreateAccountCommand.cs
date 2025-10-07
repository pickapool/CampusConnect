using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;

namespace WebAPI.Commands.Users.Commands.CreateCommand
{
    public record class CreateAccountCommand(SignupModel? Request) : IRequest<Result>;
}
