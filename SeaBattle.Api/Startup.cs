using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SeaBattle.Application.Interfaces;
using SeaBattle.Infrastructure.Repositories;
using SeaBattle.Infrastructure.Services;

namespace SeaBattle.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SeaBattle.Api", Version = "v1" });
            });
            services.AddScoped<IBattleService, BattleService>();
            services.AddScoped<IBattleRepository, BattleRepository>();
            services.AddScoped<IBattleStatisticService, BattleStatisticService>();
            services.AddScoped<IShipService, ShipService>();
            services.AddScoped<ICoordinatesParser, CoordinatesParser>();
            services.AddScoped<ICoordinatesValidator, CoordinatesValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SeaBattle.Api v1"));
            }
            
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;
    
                await context.Response.WriteAsJsonAsync(new { error = exception.Message });
            }));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            
        }
    }
}