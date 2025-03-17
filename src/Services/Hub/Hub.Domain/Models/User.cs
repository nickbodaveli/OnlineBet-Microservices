using Microsoft.AspNetCore.Identity;

namespace Hub.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
    }
}
