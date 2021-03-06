using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialNetwork.WebUI.Hubs;
using SocialNetwork.WebUI.Services.Abstract;
using SocialNetwork.WebUI.Services.Concrete;
using SocialProject.WebUI.Entities;
using SocialProject.WebUI.Services.Abstract;
using SocialProject.WebUI.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialProject.WebUI
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
            services.AddRazorPages();
            services.AddScoped<IPostRepository,PostRepository>();
            services.AddScoped<INotficationRepository,NotificationRepository>();
            services.AddScoped<IFriendRepository,FriendRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddDbContext<CustomIdentityDbContext>(
                options => options
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SocialMediaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=True;MultipleActiveResultSets=True"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy => {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetIsOriginAllowed(orign => true);
                });
            });
            services.AddSignalR();





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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default", "{controller=Account}/{action=LogIn}/{id?}");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
