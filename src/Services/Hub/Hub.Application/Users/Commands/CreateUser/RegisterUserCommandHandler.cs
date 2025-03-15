using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Hub.Application.Data;
using Hub.Domain.Models;

namespace Hub.Application.Users.Commands.CreateUser
{
    public class RegisterUserCommandHandler(IApplicationDbContext dbContext, IUserRepository userRepository)
        : ICommandHandler<RegisterUserCommand, RegisterUserResult>
    {
        public async Task<RegisterUserResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var register = new RegisterUser
            {
                UserName = command.Register.UserName,
                Password = command.Register.Password
            };

            var isRegistered = await userRepository.RegisterUser(register);

            return new RegisterUserResult(isRegistered);
        }
    }
}
