using IStartup = Upd8.API.Interfaces.IStartup;

namespace Upd8.API.Configuration
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<T>(this WebApplicationBuilder webAppBuilder) where T : IStartup
        {
            if (Activator.CreateInstance(typeof(T), webAppBuilder.Configuration) is not IStartup startup)
                throw new ArgumentException("Classe startup.cs inválida!");

            startup.ConfigureServices(webAppBuilder.Services);
            var app = webAppBuilder.Build();

            startup.Configure(app, app.Environment);
            app.Run();

            return webAppBuilder;
        }
    }
}
