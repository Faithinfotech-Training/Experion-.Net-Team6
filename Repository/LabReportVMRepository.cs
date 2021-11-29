﻿using System;
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
                return await (from patient in db.TblPatient
                              from doctor in db.TblDoctor
                              from appointment in db.TblAppointment
                              from log in db.TblPatientLog
                              from test in db.TblPrescriptionTest
                              from testName in db.TblMasterLabTest
                              from report in db.TblLabReport
                              from staff in db.TblStaff
                              where appointment.PatientId == patient.PatientId
                              where appointment.DoctorId == doctor.DoctorId
                              where log.AppointmentId == appointment.AppointmentId
                            
                              where test.LogId == log.LogId
                              where testName.TestId == test.TestOneId
                              where testName.TestId == test.TestTwoId
                              where testName.TestId == test.TestThreeId
                          
                              select new LabReportViewModel
                              {
                                  LabReportId = report.LabReportId,
                                  PatientId = patient.PatientId,
                                  PatientName = patient.PatientName,
                                  StaffId = staff.StaffId,
                                  StaffName = staff.StaffName,
                                  DoctorName = doctor.DoctorName,
                                  DateOfAppointment = appointment.DateofAppointment,
                                  TestOneName = testName.TestName,
                                  TestTwoName=testName.TestName,
                                  TestThreeName=testName.TestName,
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
                              from testname in db.TblMasterLabTest
                              from patient in db.TblPatient
                              from doctor in db.TblDoctor 
                              from date in db.TblAppointment
                              where testname.TestId==report.TestOneId
                              where testname.TestId==report.TestTwoId
                              where testname.TestId==report.TestTwoId
                              where report.PatientId == id
                              select new LabReportViewModel
                              {
                                  LabReportId = report.LabReportId,
                                  PatientId = patient.PatientId,
                                  PatientName= patient.PatientName,
                                  DoctorName= doctor.DoctorName,
                                 

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
