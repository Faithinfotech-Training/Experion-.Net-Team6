using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using cmsRestApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace cmsRestApi
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
            services.AddControllers();
            services.AddDbContext<ClinicManagementSystemDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IPrescMedicineRepo, PrescMedicineRepo>();
            services.AddScoped<IMedicineRepo, MedicineRepo>();
            services.AddScoped<IPatientRepo, PatientRepo>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IPatientLogRepository, PatientLogRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200", "https://b674-103-151-188-91.ngrok.io")
            .AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
