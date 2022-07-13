using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace Gnoss.DevTools.ViewMaker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var projectDir = System.IO.Directory.GetCurrentDirectory();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddSession();
            services.Configure<RazorViewEngineOptions>(o =>
             {

                 o.ViewLocationFormats.Clear();
                 o.ViewLocationFormats.Add("~/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                 o.ViewLocationFormats.Add("~/GenericViews/{1}/{0}" + RazorViewEngine.ViewExtension);
                 o.ViewLocationFormats.Add("/Views/Administracion/{1}/{0}" + RazorViewEngine.ViewExtension);
                 o.ViewLocationFormats.Add("/Views/CMSPagina/{0}" + RazorViewEngine.ViewExtension);
                 o.ViewLocationFormats.Add("~/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
                 o.ViewLocationFormats.Add("~/Views/CMSPagina/{0}" + RazorViewEngine.ViewExtension);
                 o.ViewLocationFormats.Add("~/GenericViews/{1}/{0}" + RazorViewEngine.ViewExtension);
                 o.ViewLocationFormats.Add("~/GenericViews/Shared/{0}" + RazorViewEngine.ViewExtension);
                 o.ViewLocationFormats.Add("~/GenericViews/CMSPagina/{0}" + RazorViewEngine.ViewExtension);
                 DirectoryInfo directorioVistas = new DirectoryInfo(Path.Combine((string)AppContext.GetData("rutaBase"), "Views"));
                 DirectoryInfo[] directoriosVistas = directorioVistas.GetDirectories();
                 foreach (DirectoryInfo directorio in directoriosVistas)
                 {
                     o.ViewLocationFormats.Add($"~/Views/{directorio.Name}/{{0}}" + RazorViewEngine.ViewExtension);
                     o.ViewLocationFormats.Add($"~/GenericViews/{directorio.Name}/{{0}}" + RazorViewEngine.ViewExtension);
                 }

             });


            //services.Configure<RazorViewEngineOptions>(o =>
            //{
            //    o.ViewLocationExpanders.Add(new MyViewLocationExpander());
            //});

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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();


            //app.UseFileServer();
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {

                //endpoints.MapControllers();
                //endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");
            });
            
        }

       
    }
}
