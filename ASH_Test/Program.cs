using ASH_Test.DbContexts;
using ASH_Test.Interfaces;
using ASH_Test.Services;
using Microsoft.EntityFrameworkCore;

namespace ASH_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            
            // need to flesh out options with conection string etc.
            builder.Services.AddDbContext<EmployeeContext>(o => o.UseSqlServer("connectionString"));
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
            

            // Add services to the container.

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