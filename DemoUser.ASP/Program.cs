using DemoUser.Domain.Repositories;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using BLLEnt = DemoUser.BLL.Entities;
using BLLServ = DemoUser.BLL.Services;
using DALEnt = DemoUser.DAL.Entities;
using DALServ = DemoUser.DAL.Services;

namespace DemoUser.ASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Appelle du fichier de configuration appsettings.json
            IConfiguration configuration = builder.Configuration;
            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //Services d'intégration des couches BLL et DAL
            builder.Services.AddScoped<DbConnection>(serviceProvider => new SqlConnection(
                configuration.GetConnectionString("DemoUser.Database")));
            //Intégration des services de la BLL
            builder.Services.AddScoped<IUserRepository<BLLEnt.User>, BLLServ.UserService>();
            //Intégration des services de la DAL
            builder.Services.AddScoped<IUserRepository<DALEnt.User>, DALServ.UserService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
