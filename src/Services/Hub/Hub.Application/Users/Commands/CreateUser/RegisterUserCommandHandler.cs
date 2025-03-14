using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Hub.Application.Data;

namespace Hub.Application.Users.Commands.CreateUser
{
    public class RegisterUserCommandHandler(IApplicationDbContext dbContext)
        : ICommandHandler<RegisterUserCommand, RegisterUserResult>
    {
        public async Task<RegisterUserResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            return new RegisterUserResult(true);
        }
    }
}
