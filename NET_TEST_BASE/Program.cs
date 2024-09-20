
using Microsoft.EntityFrameworkCore;
using DataAccesLayer.Data;
using NET_TEST_BASE.Repositories;
using NET_TEST_BASE.Services;
using NET_TEST_BASE.UnitOfWork;
using DataAccesLayer.Repositories;
using DataAccesLayer.Services;
using DataAccesLayer.UnitOfWork;

namespace NET_TEST_BASE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                // Sobrescribimos la cadena de conexión si está definida como variable de entorno
                var envConnectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
                if (!string.IsNullOrEmpty(envConnectionString))
                {
                    connectionString = envConnectionString;
                }

                options.UseSqlServer(connectionString);
            });

            // Registrar los servicios y repositorios
            builder.Services.AddScoped<IUnitOfWork, UnitOfWorkT>();
            builder.Services.AddScoped<IPagoService, PagoService>();
            builder.Services.AddScoped<IPagoRepository, PagoRepository>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            //automigraciones
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();
            }
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
