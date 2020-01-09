using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Areas.Identity.Data;
using TestApp.Models;

[assembly: HostingStartup(typeof(TestApp.Areas.Identity.IdentityHostingStartup))]
namespace TestApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TestAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TestAppContextConnection")));

                services.AddDefaultIdentity<TestAppUser>()
                    .AddEntityFrameworkStores<TestAppContext>();
            });
        }
    }
}