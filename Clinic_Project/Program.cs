using Clinic_Project.DataAccess.DbContext;
using Clinic_Project.DataAccess.Repositories;
using Clinic_Project.Models;
using Clinic_Project.Models.DoctorAgg;
using Clinic_Project.Models.patientAgg;
using Clinic_Project.Models.SkillAgg;
using Clinic_Project.Models.TurnAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

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
            builder.Services.AddScoped<TurnRepository>();

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            //var configuration = new ConfigurationBuilder()
	           // .SetBasePath(Directory.GetCurrentDirectory())
	           // // reloadOnChange will allow you to auto reload the minimum level and level switches
	           // .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
	           // .Build();

            //string logDbConnectionString = _configuration.GetValue<string>("Modules:Logging:logDb");

			Log.Logger = new LoggerConfiguration()
				//.MinimumLevel.Verbose()
				.ReadFrom.Configuration(builder.Configuration.GetSection("Logging"))
				.WriteTo.Logger(x =>
		            {
			            //x.Filter.ByIncludingOnly(y => y.Properties.ContainsKey());
			            x.WriteTo.File(builder.Configuration.GetSection("Logging:Serilog:FilePath").Value);
			            x.MinimumLevel.Error();
		            })
	            .WriteTo.Seq(builder.Configuration.GetSection("Logging:Serilog:ServerUrlSeq").Value)
				.WriteTo.Logger(x =>
				{
					x.WriteTo.MSSqlServer(
						connectionString: builder.Configuration
							.GetSection("Logging:Serilog:ConnectionStrings:SqlConnectionString").Value,
						sinkOptions: new MSSqlServerSinkOptions()
						{
							TableName = "Log",
							AutoCreateSqlTable = true
						});
					x.Filter.ByIncludingOnly(y => y.Properties.ContainsKey("SqlCrud"));
					x.MinimumLevel.Verbose();
				})
				.CreateLogger();
            



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