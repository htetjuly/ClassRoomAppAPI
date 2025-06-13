using Microsoft.EntityFrameworkCore;
using ClassRoomApp.Data.Domain;

namespace ClassRoomApp.Data.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for ClassRoom
        public DbSet<ClassRoom> ClassRooms { get; set; }

        // Add more DbSets as needed
        // public DbSet<Assignment> Assignments { get; set; }
        // public DbSet<ApplicationUser> Users { get; set; }

     
    }
}
