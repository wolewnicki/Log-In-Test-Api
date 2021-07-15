using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using auth_api.services;
using auth_api.Data;
using auth_api.Repositories;
using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace auth_api
{
    public class Startup
    {
        public Startup(IConfiguration conf)
        {
            Conf = conf;
        }

        public IConfiguration Conf { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt => 
            {
                opt.AddPolicy("ALL", 
                x => x.AllowAnyOrigin());
            });
            services.AddControllers();
            services.AddScoped<PasswordService>();
            services.AddTransient<UserRepository>();
            services.AddDbContext<DataContext>(opt => 
            opt.UseNpgsql(Conf.GetConnectionString("Auth")));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("ALL");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
