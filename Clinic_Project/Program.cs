using Clinic_Project.DataAccess.DbContext;
using Clinic_Project.DataAccess.Repositories;
using Clinic_Project.Models;
using Clinic_Project.Models.DoctorAgg;
using Clinic_Project.Models.patientAgg;
using Clinic_Project.Models.SkillAgg;
using Clinic_Project.Models.TurnAgg;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MedicalClinicContext>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("Medical-string")));
            builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
            builder.Services.AddTransient<ISkillRepository, SkillRepository>();
            builder.Services.AddTransient<ITurnRepository, TurnRepository>();
            builder.Services.AddTransient<IPatientRipository, PatientRipository>();



            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}