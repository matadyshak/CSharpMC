using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCNameEntry.Areas.Identity.Data;
using MVCNameEntry.Data;

[assembly: HostingStartup(typeof(MVCNameEntry.Areas.Identity.IdentityHostingStartup))]
namespace MVCNameEntry.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MVCNameEntryContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MVCNameEntryContextConnection")));

                services.AddDefaultIdentity<MVCNameEntryUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MVCNameEntryContext>();
            });
        }
    }
}