using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCore_EFCoreInMemory.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspnetCore_EFCoreInMemory
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
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());

            // Add framework services.
            services.AddMvc();
        }

        //public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        //{
        //    loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        //    loggerFactory.AddDebug();

        //    var context = app.ApplicationServices.GetService<ApiContext>();
        //    AdicionarDadosTeste(context);

        //    app.UseMvc();
        //}

        private void AdicionarDadosTeste(ApiContext context)
        {
            var testeUsuario1 = new Models.Usuario
            {
                Id = "usuario1",
                Nome = "Macoratti",
                Email = "macoratti@yahoo.com"
            };
            context.Usuarios.Add(testeUsuario1);
            var testePost1 = new Models.Post
            {
                Id = "post1",
                UsuarioId = testeUsuario1.Id,
                Conteudo = "Primeiro Post(post1) do Usuario : usuario1"
            };
            context.Posts.Add(testePost1);
            context.SaveChanges();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var context = serviceProvider.GetService<ApiContext>();
            AdicionarDadosTeste(context);

            app.UseMvc();
        }

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseMvc();
        //}
    }
}
