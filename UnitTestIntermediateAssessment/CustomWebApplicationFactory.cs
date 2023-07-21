using EFAssessment.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestIntermediateAssessment;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.UseEnvironment("Test");
        builder.ConfigureServices(services =>
        {
            var myCustomDbContext = services.SingleOrDefault(descriptor =>
                descriptor.ServiceType == typeof(DbContextOptions<AppointmentDb>));
            if (myCustomDbContext == null) return;
            services.Remove(myCustomDbContext);
            services.AddDbContext<AppointmentDb>(options => options.UseInMemoryDatabase("testing_db"));
        });
    }

}