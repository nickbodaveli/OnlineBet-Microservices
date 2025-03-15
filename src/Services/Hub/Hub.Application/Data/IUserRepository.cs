using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hub.Domain.Models;

namespace Hub.Application.Data
{
    public interface IUserRepository
    {
        Task<LoginResponse> Login(LoginUser user);
        Task<LoginResponse> RefreshToken(RefreshTokenModel model);
        Task<bool> RegisterUser(RegisterUser user);
    }
}
