using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PeterWebApi.Models;

namespace PeterWebApi
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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase(Configuration.GetConnectionString("defaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore );    


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //if (!context.Paises.Any())
            //{

            //    context.Paises.AddRange(
            //        new List<Pais>() {
            //            new Pais() { Nombre="El Salvador", Provincias = new List<Provincia>() { new Provincia() { Nombre ="San Salvador"  }, new Provincia() { Nombre = "Santa Ana" } } },
            //            new Pais() { Nombre="Peru" , Provincias = new List<Provincia>() { new Provincia() { Nombre ="Pacumacu"  }, new Provincia() { Nombre = "Parana" } } },
            //            new Pais() { Nombre="Mexico", Provincias = new List<Provincia>() { new Provincia() { Nombre ="DF"  }, new Provincia() { Nombre = "Guadalajara" } } },
            //            new Pais() { Nombre="Estados Unidos", Provincias = new List<Provincia>() { new Provincia() { Nombre ="New York"  }, new Provincia() { Nombre = "Iowa" } } },
            //            new Pais() { Nombre="Canada", Provincias = new List<Provincia>() { new Provincia() { Nombre ="Montreal"  }, new Provincia() { Nombre = "Toronto" } } },
            //        }
            //        );
            //    context.SaveChanges();

            //}

        }
    }
}
