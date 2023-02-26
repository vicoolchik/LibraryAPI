using FluentValidation;
using FluentValidation.AspNetCore;
using LibraryAPI.Validation;
using LibraryApplication.DTOs;
using LibraryApplication.Interfaces;
using LibraryApplication.MappingProfiles;
using LibraryApplication.Services;
using LibraryInfrastructure.Context;
using LibraryInfrastructure.Data.IRepository;
using LibraryInfrastructure.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog.AspNetCore;

namespace LibraryAPI
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

            // Add FluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddTransient<IValidator<SaveBookDTO>, SaveBookDTOValidator>();
            services.AddTransient<IValidator<ReviewDTO>, ReviewDTOValidator>();
            services.AddTransient<IValidator<int>, RatingDTOValidator>();

            // Add services and repository interfaces to DI
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            // Add AutoMapper mapping profiles
            services.AddAutoMapper(typeof(LibraryMappingProfile));

            // Add EF Core in-memory database context
            services.AddDbContext<LibraryContext>(options =>
                options.UseInMemoryDatabase(databaseName: "LibraryDb"));

            // Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // Add logging
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Console()
                    .CreateLogger();
                loggingBuilder.AddSerilog(Log.Logger, dispose: true);
            });
            services.AddSingleton(LoggerFactory.Create(builder => builder.AddSerilog()));
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
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
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            // Use Serilog for request logging
            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestId", httpContext.TraceIdentifier);
                    diagnosticContext.Set("RequestHost", httpContext.Request.Host);
                    diagnosticContext.Set("RequestProtocol", httpContext.Request.Protocol);
                    diagnosticContext.Set("RequestMethod", httpContext.Request.Method);
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                    diagnosticContext.Set("RequestPath", httpContext.Request.Path);
                    diagnosticContext.Set("RequestQueryString", httpContext.Request.QueryString.ToString());
                };
                options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
