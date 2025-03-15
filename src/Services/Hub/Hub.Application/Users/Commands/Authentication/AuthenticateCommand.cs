using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Hub.Application.Dtos;
using Hub.Domain.Models;

namespace Hub.Application.Users.Commands.Authentication
{
    public record AuthenticateCommand(LoginUserDto Authenticate)
     : ICommand<AuthenticateResult>;

    public record AuthenticateResult(LoginResponse LoginResponse);
}
