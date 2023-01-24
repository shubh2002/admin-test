using System;
using InventoryManagement.Authentication;
using InventoryManagement.Logging;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using Microsoft.Extensions.Azure;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using Azure.Core.Extensions;
using InventoryManagement.Configuration;

namespace InventoryManagement
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
            var connection = Configuration.GetConnectionString("InventoryDatabase");
            GlobalDiagnosticsContext.Set("connectionString", connection);
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(60);//You can set Time   
            });
            services.Configure<BlobStorage>(Configuration.GetSection(BlobStorage.Key));
            services.AddSingleton<ILog, LogNLog>();
            services.AddDbContext<yournotebookContext>(options => options.UseSqlServer(connection));
            services.AddSingleton<IFileService, FileService>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddIdentity<ApplicationUser, CustomRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

                options.LoginPath = "/Authenticate/Login";
                options.AccessDeniedPath = "/Authenticate/Login";
                options.SlidingExpiration = true;
            });
            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration["BlobStorage:ConnectionString:blob"], preferMsi: true);
                builder.AddQueueServiceClient(Configuration["BlobStorage:ConnectionString:queue"], preferMsi: true);
            });

        }
       
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILog logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.ConfigureExceptionHandler(logger);

            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Authenticate}/{action=Login}/{id?}");
            });
        }
    }
    internal static class StartupExtensions
    {
        public static IAzureClientBuilder<BlobServiceClient, BlobClientOptions> AddBlobServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddBlobServiceClient(serviceUri);
            }
            else
            {
                return builder.AddBlobServiceClient(serviceUriOrConnectionString);
            }
        }
        public static IAzureClientBuilder<QueueServiceClient, QueueClientOptions> AddQueueServiceClient(this AzureClientFactoryBuilder builder, string serviceUriOrConnectionString, bool preferMsi)
        {
            if (preferMsi && Uri.TryCreate(serviceUriOrConnectionString, UriKind.Absolute, out Uri serviceUri))
            {
                return builder.AddQueueServiceClient(serviceUri);
            }
            else
            {
                return builder.AddQueueServiceClient(serviceUriOrConnectionString);
            }
        }
    }
}
