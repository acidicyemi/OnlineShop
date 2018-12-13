using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using shop.Data;
using shop.Data.Interfaces;
using shop.Data.Repository;

namespace shop
{
    public class Startup
    {
        private IConfigurationRoot configurationRoot;
        public IConfiguration configuration { get; }
        public Startup(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            this.configuration = configuration;
            configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            services.AddTransient<ISellerRepository, SellerRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IPcategoryRepository, PcategoryRepository>();
            services.AddTransient<IScategoryRepository, ScategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
