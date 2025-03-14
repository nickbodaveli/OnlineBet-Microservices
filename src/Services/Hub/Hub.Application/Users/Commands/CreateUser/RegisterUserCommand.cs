using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.CQRS;
using Hub.Application.Dtos;
using Hub.Domain.Models;

namespace Hub.Application.Users.Commands.CreateUser
{
    public record RegisterUserCommand(RegisterUserDto Register) 
        : ICommand<RegisterUserResult>;

    public record RegisterUserResult(bool isRegistered);
}
