using LeilaoOnline.WebApp.Dados.EfCore;
using LeilaoOnline.WebApp.Dados.Interfaces;
using LeilaoOnline.WebApp.Services.Handlers;
using LeilaoOnline.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LeilaoOnline.WebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILeilaoDao, LeilaoDaoWithEfCore>();
            services.AddTransient<ICategoriaDao, CategoriaDaoWithEfCore>();
            services.AddTransient<IProdutoService, DefaultProdutoService>();
            services.AddTransient<IAdminService, ArchiveAdminService>();
            services.AddDbContext<AppDbContext>();
            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}