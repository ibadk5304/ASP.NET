using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using nscccoursemap_ibadk5304.Data;

namespace nscccoursemap_ibadk5304
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NSCCCourseMapContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("NSCCCourseMapContext")));
            
    //          "MyDbConnectionPROD":"Server=tcp:w0439222.database.windows.net,1433;Initial Catalog=NSCCCourseMapDB;Persist Security Info=False;User ID=w0439222;Password=Ik4125688;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
    // "IdentityDataContextConnection":"Server=tcp:w0439222.database.windows.net,1433;Initial Catalog=NSCCCourseMapDB;Persist Security Info=False;User ID=w0439222;Password=Ik4125688;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            
    //         services.AddDbContext<NSCCCourseMapContext>(options =>
    //         options.UseSqlServer(Configuration.GetConnectionString("MyDbConnectionPROD")));
            services.AddControllersWithViews();
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Courses");
                options.Conventions.AuthorizeFolder("/DiplomaPrograms");
                options.Conventions.AuthorizeFolder("/AdvisingAssignments");
                options.Conventions.AuthorizeFolder("/CoursePrequisites");
                options.Conventions.AuthorizeFolder("/CourseOfferings");
                options.Conventions.AuthorizeFolder("/AcademicYear");
                options.Conventions.AuthorizeFolder("/Instructors");
                options.Conventions.AuthorizeFolder("/Semesters");
                options.Conventions.AuthorizeFolder("/DiplomaProgramYears");

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
