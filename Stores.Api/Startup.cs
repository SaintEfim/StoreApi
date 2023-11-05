using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Stores.Persistence;
using Stores.Persistence.Repository;
using Stores.Domain.Interfaces;
using Stores.Seeding;

namespace Stores.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            // Добавьте строку подключения к вашей базе данных
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PSQL")).LogTo(Console.WriteLine));

            // Добавьте сервисы репозитория
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<Seeder>();

            // Добавьте конфигурацию Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();
                    seeder.SeedData().Wait();
                }
            }

            app.UseRouting();

            // Подключите Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store V1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
