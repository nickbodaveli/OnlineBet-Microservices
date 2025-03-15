using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Application.Dtos
{
    public record RefreshTokenDto
    (
        bool IsLogedIn,
        string JwtToken,
        string RefreshToken
    );
}
