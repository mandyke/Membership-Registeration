using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using NSE.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Models;
using NSE.Infrastructure;
using NSE.Services;

namespace NSE
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MyConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

           
            services.AddTransient<IInvoice, InvoiceRepo>();
            services.AddTransient<IMeeting, MeetingRepo>();
            services.AddTransient<IMeetingType, MeetingTypeRepo>();
            services.AddTransient<IApplication, ApplicationRepo>();
            services.AddTransient<IApplicationType, ApplicationTypeRepo>();
            services.AddTransient<IApplicationProcessing, ApplicationProcessingRepo>();
            services.AddTransient<IApplicationHistory, ApplicationHistoryRepo>();
            services.AddTransient<ICertification, CertificationRepo>();
            services.AddTransient<ICertificationType, CertificationTypeRepo>();
            services.AddTransient<ICoperateEntity, CoperateEntityRepo>();
            services.AddTransient<IEmailTemplate, EmailTemplateRepo>();
            services.AddTransient<IExecoMember, ExecoMemberRepo>();
            services.AddTransient<IExecoType, ExecoTypeRepo>();
            services.AddTransient<IInstitution, InstitutionRepo>();
            services.AddTransient<IInstitutionType, InstitutionTypeRepo>();
            services.AddTransient<IMember, MemberRepo>();
            services.AddTransient<IMembershipProfession, MembershipProfessionRepo>();
            services.AddTransient<IMembershipOfSocieties, MembershipOfSocietiesRepo>();
            services.AddTransient<IPayment, PaymentRepo>();
            services.AddTransient<IPaymentType, PaymentTypeRepo>();
            services.AddTransient<INotification, NotificationRepo>();
            services.AddTransient<IPermission, PermissionRepo>();
            services.AddTransient<IProfession, ProfessionRepo>();
            services.AddTransient<IActualTest, ActualTestRepo>();
            services.AddTransient<IEmploymentStatus, EmploymentStatusRepo>();
            services.AddTransient<IInductionResult, InductResultRepo>();
            services.AddTransient<IInductionTest, InductionTestRepo>();
            services.AddTransient<IRequirements, RequirementsRepo>();
            services.AddTransient<IZone, ZoneRepo>();
            services.AddTransient<IRenewal, RenewalRepo>();
            services.AddTransient<IProfileUsers, ProfileusersRepo>();
            services.AddTransient<IOtherSpecialization, OtherSpecializationRepo>();
           
            services.AddTransient<IRenewalType, RenewalTypeRepo>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

           
        }
    }
}
