﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Document.Domain;
using Document.Inftrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Document.Api
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
            services.AddScoped<ICustomerDocumentRepository, DocumentRepository>();

            // dotnet add package Microsoft.EntityFrameworkCore.InMemory
            services.AddDbContext<DocumentDbContext>(options => options.UseInMemoryDatabase()
                .ConfigureWarnings(c => c.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            // dotnet add package Swashbuckle.AspNetCore 

            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new OpenApiInfo {
            //        Title = "Learning ASP.Net Core 3.0 Rest-API",
            //        Version = "v1",
            //        Description = "Demonstrating auto-generated API documentation",
            //        Contact = new OpenApiContact
            //        {
            //            Name = "Kenneth Fukizi",
            //            Email = "example@example.com",
            //        },
            //        License = new OpenApiLicense
            //        {
            //            Name = "MIT",
            //        }
            //    });
            //});

            // dotnet add package NSwag.AspNetCore
            services.AddOpenApiDocument(options =>
            {
                options.Title = "Documents API";
                options.DocumentName = "Learning ASP.Net Core 3.0 Rest-API";
                options.Version = "v1";
                options.Description = "Demonstrating auto-generated API documentation";
            });
        




            // dotnet add package mediatr
            // dotnet add package mediatr.extensions.microsoft.dependencyinjection
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json",
            //    "LEARNING ASP.CORE 3.0 V1");
            //});

            // open url in your browser https://localhost:5001/swagger

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
