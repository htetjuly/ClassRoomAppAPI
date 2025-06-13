using ClassRoomApp.Data;
using ClassRoomApp.Services;
namespace ClassRoomApp.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // 1 . Read Connection string 
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // 2 . Register Data Layer 
            builder.Services.AddDataServices(connectionString); //get from DataServiceControllerEntension... 
            // 3 .  Register Service Layer 
            builder.Services.AddServiceLayer();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
