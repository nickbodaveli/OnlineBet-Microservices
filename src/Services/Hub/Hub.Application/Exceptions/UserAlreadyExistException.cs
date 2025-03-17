using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlocks.Exceptions;

namespace Hub.Application.Exceptions
{
    public class UserAlreadyExistException : AlreadyExistException
    {
        public UserAlreadyExistException() : base("User")
        {
        }
    }
}
