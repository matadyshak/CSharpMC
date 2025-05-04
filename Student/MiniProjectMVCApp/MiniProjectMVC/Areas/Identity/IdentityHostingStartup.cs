using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniProjectMVCContactData.Areas.Identity.Data;
using MiniProjectMVCContactData.Data;

[assembly: HostingStartup(typeof(MiniProjectMVCContactData.Areas.Identity.IdentityHostingStartup))]
namespace MiniProjectMVCContactData.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MiniProjectMVCContactDataContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MiniProjectMVCContactDataContextConnection")));

                services.AddDefaultIdentity<MiniProjectMVCContactDataUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MiniProjectMVCContactDataContext>();
            });
        }
    }
}