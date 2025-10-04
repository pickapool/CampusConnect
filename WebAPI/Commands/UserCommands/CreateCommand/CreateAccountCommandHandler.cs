using CamCon.Domain.Models;
using CamCon.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MVC.WebAPI.Controllers;
using WebAPI.Constants;

namespace WebAPI.Commands.UserCommands.CreateCommand
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result>
    {
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthController> _logger;
        public CreateAccountCommandHandler(UserManager<ApplicationUserModel> userManager, RoleManager<IdentityRole> roleManager, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(command.Request.Email);
                if (existingUser != null)
                {
                    return UserErrors.UserExist(existingUser.Email);
                }
                if (await _roleManager.RoleExistsAsync(Roles.User) == false)
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole(Roles.User));

                    if (roleResult.Succeeded == false)
                    {
                        var roleErros = roleResult.Errors.Select(e => e.Description);
                        _logger.LogError($"Failed to create user role. Errors : {string.Join(",", roleErros)}");
                        return UserErrors.FailedToCreateUser(string.Join(",", roleErros));
                    }
                }

                ApplicationUserModel user = new()
                {
                    Email = command.Request.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = command.Request.Email,
                    Name = command.Request.Name,
                    EmailConfirmed = true
                };

                var createUserResult = await _userManager.CreateAsync(user, command.Request.Password);
                if (createUserResult.Succeeded == false)
                {
                    var errors = createUserResult.Errors.Select(e => e.Description);
                    _logger.LogError($"Failed to create user. Errors: {string.Join(", ", errors)}");
                    return UserErrors.FailedToCreateUser(string.Join(", ", errors));
                }

                var addUserToRoleResult = await _userManager.AddToRoleAsync(user: user, role: Roles.User);

                if (addUserToRoleResult.Succeeded == false)
                {
                    var errors = addUserToRoleResult.Errors.Select(e => e.Description);
                    _logger.LogError($"Failed to add role to the user. Errors : {string.Join(",", errors)}");
                }
                return Result.Success();
            }
            catch (Exception ex)
            {
                return StatusCodeErrors.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
