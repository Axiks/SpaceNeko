namespace NekoSpace.API.Contracts.Models.User
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string About { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}
