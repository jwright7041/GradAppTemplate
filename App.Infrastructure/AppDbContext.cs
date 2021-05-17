using App.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Media> Medias { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) {}
    }
}