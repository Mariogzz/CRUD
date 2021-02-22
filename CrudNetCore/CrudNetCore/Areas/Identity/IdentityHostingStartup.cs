using System;
using CrudNetCore.Areas.Identity.Data;
using CrudNetCore.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CrudNetCore.Areas.Identity.IdentityHostingStartup))]
namespace CrudNetCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthCrudNetCoreContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthCrudNetCoreContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AuthCrudNetCoreContext>();
            });
        }
    }
}