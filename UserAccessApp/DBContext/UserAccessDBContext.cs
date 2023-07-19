using Microsoft.EntityFrameworkCore;
using UserAccessApp.Models;

namespace UserAccessApp.DBContext
{
    public class UserAccessDBContext : DbContext
    {
        public UserAccessDBContext(DbContextOptions<UserAccessDBContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<LoanDetails> LoanDetails { get; set; }
        
    }
}
