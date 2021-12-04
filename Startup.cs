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
using Newtonsoft.Json.Serialization;

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
            services.AddScoped<IPrescMedicineRepo, PrescMedicineRepo>();
            services.AddScoped<ILabTestRepository, LabTestRepository>();
            services.AddScoped<ILabReportVMRepository, LabReportVMRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IPatientRepo, PatientRepo>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            //adding services
            services.AddControllers().AddNewtonsoftJson(
            options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }
            );
            services.AddCors();
        }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                app.UseCors(options =>
                options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod().AllowAnyHeader().AllowCredentials());

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                //Authentication : make authentication services available to the application
                app.UseAuthentication();

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

