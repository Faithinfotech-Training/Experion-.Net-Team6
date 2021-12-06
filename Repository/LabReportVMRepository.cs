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

        public async Task<List<LabReportViewModel>> GetAllLabReportVM()
        {
            if (db != null)
            {
                return await (from patient in db.TblPatient
                              from doctor in db.TblDoctor
                              from appointment in db.TblAppointment
                              from log in db.TblPatientLog
                              from testName in db.TblPrescriptionTest
                              from report in db.TblLabReport
                              from staff in db.TblStaff
                              where report.PatientId == patient.PatientId
                              where log.DoctorId == doctor.DoctorId
                              where log.AppointmentId == appointment.AppointmentId
                              where report.LogId==log.LogId
                              where testName.LogId == log.LogId
                              where report.StaffId==staff.StaffId
                          
                              select new LabReportViewModel
                              {
                                  LogId=log.LogId,
                                  LabReportId = report.LabReportId,
                                  PatientId = patient.PatientId,
                                  PatientName = patient.PatientName,
                                  StaffId = staff.StaffId,
                                  StaffName = staff.StaffName,
                                  DoctorName = doctor.DoctorName,
                                  DateOfAppointment = appointment.DateofAppointment,
                                  TestOneName = testName.TestOne,
                                  TestTwoName=testName.TestTwo,
                                  TestThreeName=testName.TestThree,
                                  ObservedResultOne=report.ObservedResultOne,
                                  ObservedResultThree=report.ObservedResultThree,
                                  ObservedResultTwo=report.ObservedResultTwo
                                  
                                  
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
                              join patient in db.TblPatient on report.PatientId equals patient.PatientId
                              join log in db.TblPatientLog on report.LogId equals log.LogId
                              join date in db.TblAppointment on log.AppointmentId equals date.AppointmentId
                              join testName in db.TblPrescriptionTest on log.LogId equals testName.LogId
                              where patient.PatientId==id
                              select new LabReportViewModel
                              {
                                  LabReportId = report.LabReportId,
                                  PatientId = patient.PatientId,
                                  PatientName= patient.PatientName,
                                  DateOfAppointment = date.DateofAppointment,
                                  TestOneName=testName.TestOne,
                                  TestTwoName=testName.TestTwo,
                                  TestThreeName=testName.TestThree,
                                  ObservedResultOne=report.ObservedResultOne,
                                  ObservedResultTwo=report.ObservedResultTwo,
                                  ObservedResultThree=report.ObservedResultThree
                              }
                                ).ToListAsync();
            }
            return null;
        }

        #endregion  Get Lab report by report Id
        public async Task<List<LabReportViewModel>> GetLabReportByReportId(int id)
        {
            if (db != null)
            {
                return await (from report in db.TblLabReport
                              from patient in db.TblPatient
                              from date in db.TblAppointment
                              from staff in db.TblStaff
                              from log in db.TblPatientLog
                              from doctor in db.TblDoctor
                              where report.LabReportId == id
                              where report.PatientId==patient.PatientId
                              where report.StaffId == staff.StaffId
                              where report.LogId==log.LogId
                              where log.DoctorId==doctor.DoctorId
                              where log.AppointmentId==date.AppointmentId

                              select new LabReportViewModel
                              {
                                  LabReportId = report.LabReportId,
                                  PatientId = patient.PatientId,
                                  PatientName = patient.PatientName,
                                  StaffName = staff.StaffName,
                                  DoctorName=doctor.DoctorName,
                                  DateOfAppointment = date.DateofAppointment,
                                  TestOneName = report.TestOne,
                                  TestTwoName = report.TestTwo,
                                  TestThreeName = report.TestThree,
                                  ObservedResultOne = report.ObservedResultOne,
                                  ObservedResultTwo = report.ObservedResultTwo,
                                  ObservedResultThree = report.ObservedResultThree
                              }
                                ).ToListAsync();
            }
            return null;
        }

        #region 

        #endregion

        #region get all lab report
        public async Task<List<TblLabReport>> GetAllLabReport()
        {
            if (db != null)
            {
                return await db.TblLabReport.ToListAsync();


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

        #region delete a lab report
        public async Task<int> DeleteLabReport(int id)
        {
            if (db != null)
            {
                var itemToRemove = db.TblLabReport.SingleOrDefault(x => x.LabReportId == id); //returns a single item.

                if (itemToRemove != null)
                {
                    db.TblLabReport.Remove(itemToRemove);
                    await db.SaveChangesAsync();
                    return id;
                }
                return 0;
            }
            return 0;
        }
        #endregion

      



    }
}
