using CamCon.Domain.Enitity;
using CamCon.Shared;
using MediatR;

namespace WebAPI.Commands.UserCommands.CreateCommand
{
    public record class CreateAccountCommand(SignupModel? Request) : IRequest<Result>;
}
