using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.BLL.Services;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using MassageSalon.DAL.EF.Contexts;
using MassageSalon.DAL.EF.Repositories;
using MassageSalon.WEB.Mapper;
using MassageSalon.WEB.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<MassageSalonContext>(options => options.UseSqlServer(DbConnector.GetConnectionOptions()));
            services.AddScoped<IGenericRepository<Masseur>, GenericRepository<Masseur>>();
            services.AddScoped<IGenericRepository<Review>, GenericRepository<Review>>();
            services.AddScoped<IGenericRepository<Visitor>, GenericRepository<Visitor>>();
            services.AddScoped<IGenericRepository<Record>, GenericRepository<Record>>();

            services.AddScoped<IMasseurService, MasseurService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IVisitorService, VisitorService>();
            services.AddScoped<IRecordService, RecordService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}
