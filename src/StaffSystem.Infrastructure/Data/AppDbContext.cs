using Microsoft.EntityFrameworkCore;
using StaffSystem.Core.Interfaces;
using StaffSystem.Core.ProjectAggregate.Identity;

namespace StaffSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext, IDbContext
    {
        public virtual DbSet<User> Users { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Staff.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
