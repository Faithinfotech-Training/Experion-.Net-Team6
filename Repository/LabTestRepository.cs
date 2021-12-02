using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using cmsRestApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace cmsRestApi.Repository
{
    public class LabTestRepository : ILabTestRepository
    {
        ClinicManagementSystemDBContext db;

        public LabTestRepository(ClinicManagementSystemDBContext _db)
        {
            this.db = _db;
        }

        public async Task<List<TblPrescriptionTest>> GetPrescriptionTests()
        {
            if (db != null)
            {
                return await db.TblPrescriptionTest.ToListAsync();
            }
            return null;
        }

        public async Task<List<LabViewForLabTechnician>> GetLabTestView()
        {
            if (db != null)
            {
                return await (from log in db.TblPatientLog
                              from patient in db.TblPatient
                              from doctor in db.TblDoctor
                              from test in db.TblPrescriptionTest
                              from appointment in db.TblAppointment
                              where log.PatientId == patient.PatientId
                              where log.DoctorId == doctor.DoctorId
                              where log.LogId == test.LogId
                              where log.AppointmentId == appointment.AppointmentId
                              select new LabViewForLabTechnician
                              {
                                  LogId=log.LogId,
                                  PatientName = patient.PatientName,
                                  DoctorName = doctor.DoctorName,
                                  Test1 = test.TestOne,
                                  Test2 = test.TestTwo,
                                  Test3 = test.TestThree,
                                  Date = appointment.DateofAppointment,
                                  Status=test.Status
                              }

                              ).ToListAsync();
            }
            return null;
        }

        public async Task<int> AddPrescriptionTest(TblPrescriptionTest test)
        {
            if (db != null)
            {
                await db.TblPrescriptionTest.AddAsync(test);
                await db.SaveChangesAsync();
            }
            return test.PrescriptionTestId;
        }

        public async Task<TblPrescriptionTest> GetPrescriptionTestbyId(int id)
        {
            var prescriptiontest = await db.TblPrescriptionTest.FirstOrDefaultAsync(p => p.LogId == id);
            if (prescriptiontest == null)
            {
                return null;
            }
            return prescriptiontest;
        }

        public async Task<TblPrescriptionTest> updateTestStatus(int LogId)
        {
            if (db != null)
            {
                TblPrescriptionTest test = await db.TblPrescriptionTest.FirstOrDefaultAsync(t => t.LogId == LogId);
                try
                {
                    test.Status = "Generated";
                    db.TblPrescriptionTest.Update(test);
                    await db.SaveChangesAsync();
                    return test;

                }
                catch (Exception)
                {
                    return null;

                }

            }
            return null;
        }

        public async Task<List<ReportFormView>> GetFormView(int LogId)
        {
            if (db != null)
            {
                return await (from log in db.TblPatientLog
                              from test in db.TblPrescriptionTest
                              from patient in db.TblPatient
                              where log.LogId == LogId
                              where log.PatientId == patient.PatientId
                              where test.LogId == log.LogId
                              select new ReportFormView
                              {
                                  LogId = log.LogId,
                                  PatientId = patient.PatientId,
                                  PatientName = patient.PatientName,
                                  TestOne = test.TestOne,
                                  TestTwo = test.TestTwo,
                                  TestThree = test.TestThree
                              }
                              ).ToListAsync();
            }
            return null;
        }

        public async Task<int> UpdatePrescriptionTest(TblPrescriptionTest test)
        {
            if (db != null)
            {
                db.TblPrescriptionTest.Update(test);
                await db.SaveChangesAsync();
            }
            return test.PrescriptionTestId;
        }
    }
}
