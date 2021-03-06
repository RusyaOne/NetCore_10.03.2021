using Fiction.Infrastructure;
using Fiction.Models;
using Fiction.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;

namespace Fiction
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
            services.AddControllersWithViews(configure =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                configure.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddDbContext<FictionDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<FictionDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddScoped<IMessageSender, SmsMessageSender>();
            services.AddScoped<ICharactersRepository, SqlCharactersRepository>();
            services.AddScoped<IStoryRepository, SqlStoryRepository>();

            services.AddSingleton<IRestClient, RestClient>();
            services.AddSingleton<IExternalImageServiceClient, ExternalImageServiceClient>();
            services.AddSingleton<IProcessingChannel, ImageProcessingChannel>();

            services.AddMemoryCache();

            services.AddHostedService<LoadImageService>();
            services.AddHostedService<UploadImageService>();

            services.Configure<FictionConfiguration>(Configuration.GetSection("Fiction"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWriteToConsole("This is custom middleware's output");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}