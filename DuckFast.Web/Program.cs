using DuckFast.Common.Services;
using DuckFast.Database;
using DuckFast.Web.Areas.Admin.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DuckFast.Database.Entities;

namespace DuckFast.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddDbContext<DuckFastDataContext>(options => options.UseNpgsql());
            builder.Services.AddDefaultIdentity<UserAccount>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DuckFastDataContext>();
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("SelfManagePolicy", policy => policy.RequireAuthenticatedUser());

            });

            builder.Services.AddScoped<IArticleService, ArticleService>();
            builder.Services.AddScoped<IUserAccountService, UserAccountService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapRazorPages();
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}