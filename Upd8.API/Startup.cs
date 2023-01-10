using Microsoft.EntityFrameworkCore;
using Upd8.API.Configuration;
using Upd8.Data.Context;
using IStartup = Upd8.API.Interfaces.IStartup;

namespace Upd8.API
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }
        private readonly string CorsOrigins = "_corsOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Upd8Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerProvider"));
            });

            services.AddAutoMapper(typeof(Startup));
            services.RegisterServices();
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();
            app.UseCors(CorsOrigins);

            app.MapControllers();
        }
    }
}
