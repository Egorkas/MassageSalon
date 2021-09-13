using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassageSalon.BLL.Interfaces;
using MassageSalon.BLL.Services;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using MassageSalon.DAL.EF.Contexts;
using MassageSalon.DAL.EF.Repositories;
using MassageSalon.WebApi.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MassageSalon.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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

            services.AddControllers();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
