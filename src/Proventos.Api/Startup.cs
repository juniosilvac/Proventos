using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Proventos.Core.Interfaces;
using Proventos.Core.Services.ProventoUseCases;
using Proventos.Infrastructure.Contexts;
using Proventos.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Proventos.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {          

            //Infrastructure
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TestDB"));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Services
            services.AddMediatR(typeof(ObterProventosHandler));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
