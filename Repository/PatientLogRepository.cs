using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public class PatientLogRepository : IPatientLogRepository
    {

        ClinicManagementSystemDBContext db;

        public PatientLogRepository(ClinicManagementSystemDBContext db)
        {
            this.db = db;
        }

        public async Task<List<TblPatientLog>> GetPatientLog(int id)
        {

            if (db != null)
            {
                return await (from Patient in db.TblPatientLog
                              where Patient.PatientId == id
                              select new TblPatientLog
                              {
                                  LogId=Patient.LogId,
                                  PatientId=Patient.PatientId,
                                  DoctorId=Patient.DoctorId,
                                  AppointmentId=Patient.AppointmentId,
                                  IsActive=Patient.IsActive,
                                  Notes=Patient.Notes,
                                  Observations=Patient.Observations
                              }
                ).ToListAsync();

            }
            return null;
        }
    }
}
