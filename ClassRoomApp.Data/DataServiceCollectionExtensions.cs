using ClassRoomApp.Data.Domain;
using ClassRoomApp.Data.Repositories;
using ClassRoomApp.Data.Repositories;
using ClassRoomApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomApp.Data
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //register repositories if needed 
            services.AddScoped<IClassroomRepository, ClassroomRepository>();

            return services;
        }
    }
}
