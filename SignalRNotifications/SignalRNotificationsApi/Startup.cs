using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SignalRNotificationsApi.Hubs;
using SignalRNotificationsApi.Infra;

namespace SignalRNotificationsApi
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
            services.AddCors(o => o.AddPolicy("CorsPolicy",
                builder => { builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials(); }));

            // Setup options with DI
            services.AddOptions();

            services.AddSingleton<InMemoryContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddSignalR();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseSignalR(routes => { routes.MapHub<NotifyHub>("/notifications"); });

            app.UseMvc();
        }
    }
}