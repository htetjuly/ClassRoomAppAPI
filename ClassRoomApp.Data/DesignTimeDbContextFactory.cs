using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomApp.Data.Domain;

namespace ClassRoomApp.Data
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Use a hardcoded or configurable connection string
            optionsBuilder.UseSqlServer("Server=DESKTOP-56C6MVQ;Database=ClassroomWithTeacher;TrustServerCertificate=True;User ID=sa;Password=12345;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
