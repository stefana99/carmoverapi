using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CarMoverApi.Models
{
    public class CarMoverContext : DbContext
    {
        public CarMoverContext(DbContextOptions<CarMoverContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(x => x.FaceBookUserId);
          //  builder.Entity<User>().Property(f => f.FaceBookUserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            base.OnModelCreating(builder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}