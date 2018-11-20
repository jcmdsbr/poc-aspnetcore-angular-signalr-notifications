using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SignalRNotificationsApi.Core;

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
            services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
            {
                policy
                    .WithOrigins(Configuration["angular-web"])
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));

            services.AddSingleton<InMemoryContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddSignalR();

            services.AddMvc().AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseFileServer();
            app.UseSignalR(root => root.MapHub<NotifyHub>("/notifications"));
            app.UseMvc();
        }
    }
}