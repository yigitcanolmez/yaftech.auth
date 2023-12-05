using Microsoft.AspNetCore.Identity;

namespace yaftech.auth.model
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }

    }
}
