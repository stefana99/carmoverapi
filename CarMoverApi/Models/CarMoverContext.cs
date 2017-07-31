using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CarMoverApi.Models
{
    public class CarMoverContext : DbContext
    {
        public CarMoverContext(DbContextOptions<CarMoverContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}