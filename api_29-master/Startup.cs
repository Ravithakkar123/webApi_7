using AutoMapper;
using FoodWoodz.DAL.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Webapi.Mapping;

namespace Webapi
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
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                );
            });
            services.AddAutoMapper(typeof(CustomerProfile));
            services.AddControllers();
            services.AddDbContext<RestaurantDataContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("Connection")));
            services.AddScoped<FoodWoodz.DAL.Interface.ICustomer, FoodWoodz.DAL.Repository.CustomerRepository>();
            services.AddScoped<FoodWoodz.BLL.Interface.ICustomer, FoodWoodz.BLL.Repository.CustomerRepository>();
            services.AddScoped<Webapi.Interface.ICustomer,Webapi.Repository.CustomerRepository>();
            services.AddScoped<FoodWoodz.DAL.paggingHelper.Interface.IpaggingHelper, FoodWoodz.DAL.paggingHelper.Repository.PaggingHelper>();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                  .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                  .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseMvc();
        }
    }
}
