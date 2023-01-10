namespace Upd8.API.Interfaces
{
    public interface IStartup
    {
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services);
        public void Configure(WebApplication app, IWebHostEnvironment environment);
    }
}
