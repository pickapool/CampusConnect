using CamCon.Domain.Models;
using CamCon.Shared;
using MediatR;

namespace WebAPI.Commands.UserCommands.CreateCommand
{
    public record class CreateAccountCommand(SignupModel? Request) : IRequest<Result>;
}
