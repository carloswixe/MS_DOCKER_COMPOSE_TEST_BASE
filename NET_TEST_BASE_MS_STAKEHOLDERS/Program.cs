
using Microsoft.EntityFrameworkCore;
using DataAccesLayer.Repositories;
using DataAccesLayer.Services;
using NET_TEST_BASE_MS_STAKEHOLDERS.Repositories;
using NET_TEST_BASE_MS_STAKEHOLDERS.Services;
using DataAccesLayer.Data;
using DataAccesLayer.UnitOfWork;

namespace NET_TEST_BASE_MS_STAKEHOLDERS
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
            builder.Services.AddScoped<IOrdenanteRepository, OrdenanteRepository>();
            builder.Services.AddScoped<IOrdenanteService, OrdenanteService>();
            builder.Services.AddScoped<IBeneficiarioRepository, BeneficiarioRepository>();
            builder.Services.AddScoped<IBeneficiarioService, BeneficiarioService>();

            // Add services to the container.

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
