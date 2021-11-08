using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hangfire;
using MassageSalon.BLL.EmailSender;
using MassageSalon.BLL.Interfaces;
using MassageSalon.BLL.Services;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using MassageSalon.DAL.EF.Contexts;
using MassageSalon.DAL.EF.Repositories;
using MassageSalon.WEB.Controllers;
using MassageSalon.WEB.Mapper;
using MassageSalon.WEB.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MassageSalon.WEB
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
            services.AddHangfire(h => 
                h.UseSqlServerStorage("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MassageSalonNotificationServiceDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddHangfireServer();
            Configuration.Bind("Project", new Config());

            services.AddDbContext<MassageSalonContext>(options => options.UseSqlServer(DbConnector.GetConnectionOptions()));
            services.AddScoped<IGenericRepository<Masseur>, GenericRepository<Masseur>>();
            services.AddScoped<IGenericRepository<Review>, GenericRepository<Review>>();
            services.AddScoped<IGenericRepository<Visitor>, GenericRepository<Visitor>>();
            services.AddScoped<IGenericRepository<Record>, GenericRepository<Record>>();
            services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();
            services.AddScoped<IGenericRepository<Log>, GenericRepository<Log>>();
            services.AddScoped<IGenericRepository<Offer>, GenericRepository<Offer>>();

            services.AddScoped<IMasseurService, MasseurService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IVisitorService, VisitorService>();
            services.AddScoped<IRecordService, RecordService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ILoggerService, LoggerService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IEmailService, EmailService>();


            services.AddHttpContextAccessor();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory,
            IRecurringJobManager jobManager,
            IEmailService mail,
            IRecordService record)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHangfireDashboard("/dashboard");
            jobManager.AddOrUpdate("SendOneHourBefore",() => new HangFireService(record, mail).Reccuring(), "*/30 * * * *");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
