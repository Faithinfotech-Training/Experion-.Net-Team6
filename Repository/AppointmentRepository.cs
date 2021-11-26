using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace cmsRestApi.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        ClinicManagementSystemDBContext db;

        public AppointmentRepository(ClinicManagementSystemDBContext _db)
        {
            this.db = _db;
        }

        public async Task<List<TblAppointment>> GetAppointment()
        {
            if (db != null)
            {
                return await db.TblAppointment.ToListAsync();
            }
            return null;
        }

        public async Task<TblAppointment> GetAppointmentbyId(int id)
        {
            var appointment = await db.TblAppointment.FirstOrDefaultAsync(staff => staff.AppointmentId == id);
            if (appointment == null)
            {
                return null;
            }
            return appointment;
        }

        public async Task<int> AddAppointment(TblAppointment appointment)
        {
            if (db != null)
            {
                await db.TblAppointment.AddAsync(appointment);
                await db.SaveChangesAsync();
            }
            return appointment.AppointmentId;
        }


        public async Task<int> UpdateAppointment(TblAppointment appointment)
        {
            if (db != null)
            {
                db.TblAppointment.Update(appointment);
                await db.SaveChangesAsync();
            }
            return appointment.AppointmentId;
        }

        public async Task<List<TblAppointment>> GetAppointmentbyDoctorId(int id)
        {
            if (db != null)
            {
                return await (from appointment in db.TblAppointment
                              join patient in db.TblPatient on appointment.PatientId equals patient.PatientId
                              where appointment.DoctorId == id
                              select new TblAppointment {
                                  AppointmentId = appointment.AppointmentId,
                                  PatientId = appointment.PatientId,
                                  DoctorId = appointment.DoctorId,
                                  DateofAppointment=appointment.DateofAppointment,
                                  IsActive=appointment.IsActive,
                                  Patient= new TblPatient() { PatientName= patient.PatientName}

                              }
                              ).ToListAsync();

            }
            return null;
        }
    }
}
