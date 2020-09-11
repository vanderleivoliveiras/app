using Microsoft.EntityFrameworkCore;
using FCA_Login_WebApi.Models;

namespace FCA_Login_WebApi.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AuthUser> AuthUsers { get; set; }
        public DbSet<FCA_Login_WebApi.Models.AuthUser> AuthUser { get; set; }
    }
}