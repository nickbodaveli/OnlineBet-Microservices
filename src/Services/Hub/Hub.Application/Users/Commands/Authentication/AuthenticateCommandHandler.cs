using BuildingBlocks.CQRS;
using Hub.Application.Data;

namespace Hub.Application.Users.Commands.Authentication
{
    public class AuthenticateCommandHandler(IApplicationDbContext dbContext, IUserRepository userRepository)
          : ICommandHandler<AuthenticateCommand, AuthenticateResult>
    {
        public async Task<AuthenticateResult> Handle(AuthenticateCommand command, CancellationToken cancellationToken)
        {
            var authenticate = new Hub.Domain.Models.LoginUser
            {
                UserName = command.Authenticate.UserName,
                Password = command.Authenticate.Password
            };

            var authenticatedResponse = await userRepository.Login(authenticate);

            return new AuthenticateResult(authenticatedResponse);
        }
    }
}
