using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SampleApp
{
    // Use the `--scenario basic` switch to run this version of the sample.
    //
    // Register Health Check Middleware at the URL: /health
    // 
    // By default, health checks return a 200-Ok with 'Healthy'.
    // - No health checks are registered by default. The app is healthy if it's reachable.
    // - The default response writer writes the HealthCheckStatus as text/plain content.
    //
    // This is the simplest way to perform health checks. It's suitable for systems that want to check for 'liveness' of an app.

    #region snippet1
    public class BasicStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHealthChecks("/health");

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    "Navigate to /health to see the health status.");
            });
        }
    }
    #endregion
}
