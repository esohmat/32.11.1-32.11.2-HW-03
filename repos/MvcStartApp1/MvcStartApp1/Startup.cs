
using Microsoft.EntityFrameworkCore;
using MvcStartApp1.Data;
using MvcStartApp1.Data.Interfaces;
using MvcStartApp1.Data.Repositories;
using MvcStartApp1.Middlewares;

namespace MvcStartApp1.Middlewares
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = _configuration.GetConnectionString("DefaultConnection")!;

            services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(connection));

            services.AddControllersWithViews();

            //services.AddScoped<IBlogRepository, BlogRepository>();             
            services.AddScoped<IRequestLogRepository, RequestLogRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseAuthorization();

            app.UseMiddleware<LoggingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Map("/about", About);
            app.Map("/config", Config);

            app.Run(async context =>
            {
                await context.Response.WriteAsync($"Welcome to the {_env.ApplicationName}!");
            });
        }

        private void About(IApplicationBuilder branch)
        {
            branch.Run(async context =>
            {
                await context.Response.WriteAsync($"{_env.ApplicationName} - Tutorial");
            });
        }

        private void Config(IApplicationBuilder branch)
        {
            branch.Run(async context =>
            {
                await context.Response.WriteAsync($"Config: {_env.EnvironmentName}");
            });
        }
    }
}