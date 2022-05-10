using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Database;
using TPL.Repository.Interfaces;
using TPL.Repository;
using TPL.Servicies;
using TPL.Servicies.Interfaces;
using System.Reflection;
using System.IO;
using TPL.Middleware;
using TPL.Data.Atributes;
using TPL.Services.Interfaces;
using TPL.Services;
using FluentValidation.AspNetCore;
using FluentValidation;
using TPL.Data.Entities;
using TPL.Data.Validations;
using TPL.Data.Dtos;
using Microsoft.AspNetCore.Http;
using TPL.Data.Common;

namespace TPL
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddFluentValidation();
            services.AddControllersWithViews();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();

                    });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TPL", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                            new OpenApiSecurityScheme
                            {
                                Scheme = "Bearer",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                            }, new List<string>()
                    }
               
            });
              
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("custom:role", "Admin"));
                options.AddPolicy("Basic", policy => policy.RequireClaim("custom:role", "User"));
            });

            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddDbContext<WebApiContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("WebApiConection")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<IStationRepository, StationRepository>();
            services.AddScoped<IRouteStationService, RouteStationService>();
            services.AddScoped<IRouteStationRepository, RouteStationRepository>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<ILineRepository, LineRepository>();
            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IConfigurationService, ConfigurationService>();

            services.AddTransient<IValidator<UserCreateDto>, UserValidator>();
            // services.AddMvc().AddFluentValidation;


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TPL v1"));
            }

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
