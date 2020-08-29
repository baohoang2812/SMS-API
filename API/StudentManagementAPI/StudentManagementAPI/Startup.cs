using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentManagement.Data;
using StudentManagement.Data.Config;
using StudentManagement.Data.Global;
using StudentManagement.Data.Repositories;
using StudentManagement.Data.Repository;
using StudentManagement.Data.Services;
using System.Text;

namespace StudentManagementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppConfig.SetConfig(configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Student Management API",
                    Description = "API for Student Management",
                });
            });
            services.AddDbContext<SMSContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SMSContext"));
            });
            ConfigureDependencyInjection(services);
            Global.ConfigureMapper(services);
            services.AddSwaggerGenNewtonsoftSupport();
        }
        public void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>()
                .AddScoped<DbContext, SMSContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<IClassRepository, ClassRepository>()
                .AddScoped<IClassService, ClassService>()
                .AddScoped<IStudentService, StudentService>()
                .AddScoped<IAdminService, AdminService>()
                .AddScoped<IAdminRepository, AdminRepository>();
            var tokenValue = Configuration.GetSection("AppSettings:Token").Value;
            var url = Configuration.GetSection("AppSettings:Url").Value;
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   options.SaveToken = true;
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {                      
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidAudience = url,
                       ValidIssuer = url,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenValue))
                   };
               });
        }

      
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
                builder.AllowCredentials();
            });
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Management API v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
