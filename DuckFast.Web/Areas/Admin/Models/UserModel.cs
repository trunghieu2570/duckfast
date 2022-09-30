namespace DuckFast.Web.Areas.Admin.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? DisplayName { get; set; }
    }
}
