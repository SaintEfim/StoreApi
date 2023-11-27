using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Stores.Persistence;
using Stores.Persistence.Repository;
using Stores.Seeding;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Stores.Application.Queries;
using MediatR;
using Stores.Application.Commands;
using Stores.Domain.Entity;
using Stores.Persistence.Queries;
using Stores.Application.Interfaces;
using Stores.Persistence.Commands;

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
            var secretKey = Configuration.GetValue<string>("ApiSettings:Secret");
            var key = Encoding.ASCII.GetBytes(secretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStoresQuery).Assembly));

            // Добавьте строку подключения к вашей базе данных
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PSQL")).LogTo(Console.WriteLine));

            // Добавьте сервисы репозитория
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreInfoRepository, StoreInfoRepository>();
            services.AddScoped<Seeder>();
            services.AddScoped<IRequestHandler<GetStoresQuery, ICollection<Store>>, GetStoresHandler>();
            services.AddScoped<IRequestHandler<GetStoreByIdQuery, Store>, GetStoreByIdHandler>();
            services.AddScoped<IRequestHandler<AddStoreCommand, Unit>, AddStoreHandler>();


            // Добавьте конфигурацию Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Stores API", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                                  "Enter 'Bearer' [space] ant then your token in the text input below. \r\n\r\n" +
                                  "Example: \"Bearer 1234abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}