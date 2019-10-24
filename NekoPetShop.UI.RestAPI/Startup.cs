using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NekoPetShop.Core.ApplicationService;
using NekoPetShop.Core.ApplicationService.Services;
using NekoPetShop.Core.DomainService;
using NekoPetShop.Infrastructure.SQLData;
using NekoPetShop.Infrastructure.SQLData.Repositories;

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

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
        {
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

			services.AddScoped<IColorRepository, ColorRepository>();
			services.AddScoped<IColorService, ColorService>();

			services.AddScoped<IOwnerRepository, OwnerRepository>();
			services.AddScoped<IOwnerService, OwnerService>();

			services.AddScoped<IPetRepository, PetRepository>();
			services.AddScoped<IPetService, PetService>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddMvc().AddJsonOptions(options => {
				options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 3;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    NekoPetShopContext context = scope.ServiceProvider.GetService<NekoPetShopContext>();
                    DBInitializer.Seed(context);
                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    NekoPetShopContext context = scope.ServiceProvider.GetService<NekoPetShopContext>();
                    DBInitializer.Seed(context);
                }
                app.UseDeveloperExceptionPage();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

			app.UseCors(builder =>
			{
				builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
			});

			app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
