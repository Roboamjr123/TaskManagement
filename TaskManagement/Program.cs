using Microsoft.EntityFrameworkCore;
using TaskManagement.Database;
using TaskManagement.Helper;
using TaskManagement.Interface;
using TaskManagement.Repository;
using TaskManagement;

namespace TaskManagement
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddTransient<Seed>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("TaskManage"));
            });

            // Add CORS configuration here
            builder.Services.AddCors(options =>
            {
                var frontEndUrl = builder.Configuration.GetValue<string>("FrontEnd_Url");
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins(frontEndUrl)
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
                SeedData(app);
            void SeedData(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<Seed>();
                    service.SeedDataContext();
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors(); // Use CORS middleware
            app.MapControllers();

            app.Run();
        }
    }
}