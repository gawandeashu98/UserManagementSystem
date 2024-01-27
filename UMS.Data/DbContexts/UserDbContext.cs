using Microsoft.EntityFrameworkCore;
using UMS.Messages.Entities;

namespace USM.Data.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {}

        public DbSet<User> User { get; set; }
    }
}
