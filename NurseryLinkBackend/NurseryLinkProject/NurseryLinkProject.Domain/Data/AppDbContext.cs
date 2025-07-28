using Microsoft.EntityFrameworkCore;
using NurseryLinkProject.Domain.Entities;

namespace NurseryLinkProject.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NurseryClass> NurseryClasses { get; set; }
        public DbSet<ParentStudent> ParentStudents { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<SupplyRequest> SupplyRequests { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Toilet> Toilets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
