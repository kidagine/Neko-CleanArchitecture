using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.Core.ApplicationService.Services;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Infrastructure.SQLData;
using NekoPetShop.Infrastructure.SQLData.Repositories;
using NekoPetShop.Core.Helpers;

namespace NekoPetShop.UI.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
			Environment = environment;
        }

        public IConfiguration Configuration { get; }
		public IHostingEnvironment Environment { get; }

		public void ConfigureServices(IServiceCollection services)
        {
			Byte[] secretBytes = new byte[40];
			Random rand = new Random();
			rand.NextBytes(secretBytes);

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = false,
					ValidateIssuer = false,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
					ValidateLifetime = true, 
					ClockSkew = TimeSpan.FromMinutes(5) 
				};
			});

			services.AddCors();

			if (Environment.IsDevelopment())
			{
				services.AddDbContext<NekoPetShopContext>(opt =>
				{
					opt.UseSqlite("Data Source=petApp.db");
				});
			}
			else
			{
				services.AddDbContext<NekoPetShopContext>(opt =>
				{
					opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
				});
			}
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserService, UserService>();

			services.AddScoped<IColorRepository, ColorRepository>();
			services.AddScoped<IColorService, ColorService>();

			services.AddScoped<IOwnerRepository, OwnerRepository>();
			services.AddScoped<IOwnerService, OwnerService>();

			services.AddScoped<IPetRepository, PetRepository>();
			services.AddScoped<IPetService, PetService>();

			services.AddTransient<IDBInitializer, DBInitializer>();
			services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddMvc().AddJsonOptions(options => {
				options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 5;
            });

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
					NekoPetShopContext context = scope.ServiceProvider.GetService<NekoPetShopContext>();
					IDBInitializer dbInitializer = scope.ServiceProvider.GetService<IDBInitializer>();
					dbInitializer.Seed(context);
                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
					NekoPetShopContext context = scope.ServiceProvider.GetService<NekoPetShopContext>();
					IDBInitializer dbInitializer = scope.ServiceProvider.GetService<IDBInitializer>();
					dbInitializer.Seed(context);
				}
                app.UseDeveloperExceptionPage();
                app.UseHsts();
            }

			app.UseCors(builder =>
			{
				builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
			});

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseMvc();
        }
    }
}
