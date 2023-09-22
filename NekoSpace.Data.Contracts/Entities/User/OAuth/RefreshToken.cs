using NekoSpace.Data.Models.User;

namespace NekoSpace.Data.Contracts.Entities.User.OAuth
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Guid JwtId { get; set; }
        public UserEntity User { get; set; }
        public string Token { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
        public DateTime ExpiryDate { get; set; }
    }
}
