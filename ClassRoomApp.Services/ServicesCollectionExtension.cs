using ClassRoomApp.Services;
using ClassRoomApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomApp.Services
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IClassRoomService, ClassRoomServices>();
            //Add other services here 
            return services;
        }
    }
}
