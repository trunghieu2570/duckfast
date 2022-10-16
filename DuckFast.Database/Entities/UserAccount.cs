using Microsoft.AspNetCore.Identity;

namespace DuckFast.Database.Entities
{
    public class UserAccount: IdentityUser
    {
        [PersonalData]
        public string? DisplayName { get; set; }
    }
}
