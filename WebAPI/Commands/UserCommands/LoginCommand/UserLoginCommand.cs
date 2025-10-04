using CamCon.Domain.Models;
using CamCon.Shared;
using MediatR;

namespace MVC.WebAPI.Commands.UserCommands.LoginCommand
{
    public record class UserLoginCommand(LoginModel? request) : IRequest<Result<TokenModel>>;
}
