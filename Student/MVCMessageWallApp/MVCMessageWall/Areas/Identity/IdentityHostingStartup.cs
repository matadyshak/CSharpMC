using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCMessageWall.Areas.Identity.Data;
using MVCMessageWall.Data;

[assembly: HostingStartup(typeof(MVCMessageWall.Areas.Identity.IdentityHostingStartup))]
namespace MVCMessageWall.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MVCMessageWallContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MVCMessageWallContextConnection")));

                services.AddDefaultIdentity<MVCMessageWallUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MVCMessageWallContext>();
            });
        }
    }
}