using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using cmsRestApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace cmsRestApi.Repository
{
    public class LabReportVMRepository: ILabReportVMRepository
    {
        ClinicManagementSystemDBContext db;

        public LabReportVMRepository(ClinicManagementSystemDBContext _db)
        {
            db = _db;
        }

        //Crud Operations
        #region get lab report

        public async Task<List<LabReportViewModel>> GetAllLabReport()
        {
            if (db != null)
            {
                return await (from report in db.TblLabReport
                              join
                               patient in db.TblPatient on
                               report.PatientId equals patient.PatientId
                              join
                              staff in db.TblStaff on
                              report.StaffId equals staff.StaffId
                              join
                              test in db.TblMasterLabTest on
                              report.TestId equals test.TestId
                              join
                              log in db.TblPatientLog on
                              report.LogId equals log.LogId
                              join
                              doctor in db.TblDoctor on
                              log.DoctorId equals doctor.DoctorId
                              join
                              apoointment in db.TblAppointment on
                              log.AppointmentId equals apoointment.AppointmentId
                              select new LabReportViewModel
                              {
                                  LabReportId = report.LabReportId,
                                  PatientId = patient.PatientId,
                                  PatientName = patient.PatientName,
                                  StaffId = staff.StaffId,
                                  StaffName = staff.StaffName,
                                  DoctorName = doctor.DoctorName,
                                  DateOfAppointment = apoointment.DateofAppointment,
                                  TestId = test.TestId,
                                  TestName = test.TestName,
                                  NormalRange = test.NormalRange,
                                  ObservedResult = report.ObservedResult
                              }
                                ).ToListAsync();
            }
            return null;    
        }

        #endregion

        #region get single lab report

        public async Task<List<LabReportViewModel>> GetLabReport(int id)
        {
            if (db != null)
            {
                return await (from report in db.TblLabReport
                              join
                               patient in db.TblPatient on
                               report.PatientId equals patient.PatientId
                              join
                              staff in db.TblStaff on
                              report.StaffId equals staff.StaffId
                              join
                              test in db.TblMasterLabTest on
                              report.TestId equals test.TestId
                              join
                              log in db.TblPatientLog on
                              report.LogId equals log.LogId
                              join
                              doctor in db.TblDoctor on
                              log.DoctorId equals doctor.DoctorId
                              join
                              apoointment in db.TblAppointment on
                              log.AppointmentId equals apoointment.AppointmentId
                              where report.LabReportId == id
                              select new LabReportViewModel
                              {
                                  LabReportId = report.LabReportId,
                                  PatientId = patient.PatientId,
                                  PatientName = patient.PatientName,
                                  StaffId = staff.StaffId,
                                  StaffName = staff.StaffName,
                                  DoctorName = doctor.DoctorName,
                                  DateOfAppointment = apoointment.DateofAppointment,
                                  TestId = test.TestId,
                                  TestName = test.TestName,
                                  NormalRange = test.NormalRange,
                                  ObservedResult = report.ObservedResult
                              }
                                ).ToListAsync();
            }
            return null;
        }

        #endregion


        #region Add a lab report

        public async Task<int> AddLabReport(TblLabReport report)
        {
            if (db != null)
            {
                await db.TblLabReport.AddAsync(report);
                await db.SaveChangesAsync(); //commit
                return report.LabReportId;
            }
            return 0;
        }

        #endregion
    }
}
