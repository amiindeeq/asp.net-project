using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using shift6.Data;

namespace shift6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var _conn = builder.Configuration.GetConnectionString("mydb");
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<dbContext>(p=>p.UseSqlServer(_conn)); 
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.Name = "testApp";
                options.Cookie.Path= "/";   
                options.Cookie.HttpOnly=true; //more secure, only the server can read the cookie
                options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                options.Cookie.IsEssential = true;

            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
                options.LoginPath = "/accounts/login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(3);
            
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); //middleware
            app.UseAuthorization();
            app.UseSession(); //middleware for session

            //here application route starts
            app.MapControllerRoute(
                name:"wararka",
                pattern:"wararka/{id?}",
                defaults: new {controller="News", action="find"}
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}