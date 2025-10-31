using library_management_system;
using library_management_system.Ireposatoryinterfases;
using library_management_system.ReposetoryClasses;
using library_management_system.serviceesInterfasees;
using Library_mangement_system.Models;
using Library_mangement_system.Models.Entitys;
using Library_mangement_system.Models.Ireposatoryinterfases;
using Library_mangement_system.Models.IserviceesInterfasees;
using Library_mangement_system.Models.ReposetoryClasses;
using Library_mangement_system.Models.servicesClasses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Library_mangement_system
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add session
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });

            builder.Services.AddControllersWithViews(option =>
            {
                 //option.Filters.Add(fslandl);
            });

            //register the identity 
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
            })
                            .AddEntityFrameworkStores<AppDbContext>();
                              
           // var configuration = new ConfigurationBuilder()
           //.SetBasePath(Directory.GetCurrentDirectory())
           //.AddJsonFi le("appsettings.json")
           //.Build();

           // var connectionString = configuration.GetSection("constr").Value;

            builder.Services.AddDbContext<AppDbContext>
                (
                    option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );

            builder.Services.AddScoped<ILIibraryReposatory, LIibraryReposatory>();
            builder.Services.AddScoped<IbookReposatory , bookReposatory>();
            builder.Services.AddScoped<ICartReposatory , CartReposatory>();
            builder.Services.AddScoped<IorderReposatory , OrderReposatory>();
            builder.Services.AddScoped<ILibraryService, LibraryService>();
            builder.Services.AddScoped<Ibooksevice , Bookservice>();
            builder.Services.AddScoped<Icartservice , cartservice>();
            builder.Services.AddScoped<IorderServise, orderservise>();


            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<SeedData>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<SeedData>();
                await service.SeedLibrayrs();
               // await service.SeedBooks();
            }

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                }
            app.UseSession();         
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
