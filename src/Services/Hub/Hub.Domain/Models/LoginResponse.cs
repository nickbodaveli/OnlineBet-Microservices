using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub.Domain.Models
{
    public class LoginResponse
    {
        public bool IsLogedIn { get; set; } = false;
        public string JwtToken { get; set; }
        public string RefreshToken { get; internal set; }

        public void SetRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
