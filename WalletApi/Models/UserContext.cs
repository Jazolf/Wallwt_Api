using Microsoft.EntityFrameworkCore;

namespace WalletApi.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> option)
            : base(option)
        {
        }
        public DbSet<UserItems> UserItems { get; set; }
        public object UsertItems { get; internal set; }
    }
}
