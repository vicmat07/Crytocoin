using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Data.Profiles;
using Hahn.ApplicatonProcess.July2021.Data.Repository;
using Hahn.ApplicatonProcess.July2021.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.Application.Tests;
using FluentValidation.AspNetCore;
using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Domain.Validators;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using AutoMapper;

namespace Challenge
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
            services.AddControllers();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("Hanh"));
            services.AddScoped<ApplicationTest>();
            services.AddAutoMapper(typeof(UserProfile));
            services.AddControllers().AddFluentValidation(x => x
                                        .RegisterValidatorsFromAssemblyContaining<CreateUserValidator>());

            //Can be done as this as well, this option you have to register one by one; the one above, register all contained in this assembly:

            //services.AddControllers().AddFluentValidation();
            //services.AddScoped<IValidator<User>, CreateUserValidator>();
                }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationTest applicationTest)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                applicationTest.Seed();
                
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
