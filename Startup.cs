using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cmsRestApi.Models;
using cmsRestApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
            services.AddScoped<IEventRepo, EventRepo>();
            services.AddScoped<IAnnouncementRepo, AnnouncementRepo>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IPatientLogRepository, PatientLogRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();


            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IPaymentRepo, PaymentRepo>();



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
            //register a JWT authentication schema
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Configure authentication schema with JWT bearer
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))

                    };

                });

            services.AddMvc();
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
