using Hotel.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Hotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();

       
            builder.Services.AddDbContext<HotelsDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

            
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Logowanie/Index"; 
                options.AccessDeniedPath = "/Home/Error"; 
            });

            
            builder.Services.AddAuthorization(options =>
            {
          
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
            });

            var app = builder.Build();

          
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }

          
            app.UseHttpsRedirection();
            app.UseStaticFiles();

           
            app.UseRouting();

            
            app.UseAuthentication();
            app.UseAuthorization();

         
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

           
            app.MapControllers();

            app.Run();
        }
    }
}