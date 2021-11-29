using cmsRestApi.Models;
using cmsRestApi.ViewModel;
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

        public async Task<int> AddPatientLog(TblPatientLog log)
        {
            if (db != null)
            {
                await db.TblPatientLog.AddAsync(log);
                await db.SaveChangesAsync();
                return log.LogId;
            }
            return 0;
        }

        public async Task<List<PatientLogViewModel>> GetPatientLogViewModel(int id)
        {
            if (db != null)
            {
                //joining and getting 
                return await (from patient in db.TblPatient
                              from doctor in db.TblDoctor
                              from appointment in db.TblAppointment
                              from log in db.TblPatientLog
                              from medicine in db.TblPrescriptionMedicine
                              from medicineName in db.TblMasterMedicine
                              from test in db.TblPrescriptionTest
                              from testName in db.TblMasterLabTest
                              from spec in db.TblSpecialization
                              where patient.PatientId == id
                              where appointment.PatientId == patient.PatientId
                              where appointment.DoctorId == doctor.DoctorId
                              where doctor.DoctorSpecializationId == spec.SpecializationId
                              where log.AppointmentId == appointment.AppointmentId
                              where medicine.LogId == log.LogId
                              where medicineName.MedicineId == medicine.MedicineId
                              where test.LogId == log.LogId
                              where testName.TestId == test.TestId
                              select new PatientLogViewModel
                              {
                                  PatientId = patient.PatientId,
                                  PatientName = patient.PatientName,
                                  Age = patient.Age,
                                  Gender = patient.Gender,
                                  Location = patient.Location,
                                  ContactNo = patient.ContactNo,
                                  EmergencyContact = patient.EmergencyContact,
                                  IsActive = patient.IsActive,
                                  DoctorName = doctor.DoctorName,
                                  SpecializationName = spec.SpecializationName,
                                  DateofAppointment = appointment.DateofAppointment,
                                  Notes = log.Notes,
                                  Observations = log.Observations,
                                  MedicineName = medicineName.MedicineName,
                                  TestName =new TestView() { test1= testName.TestName,test2=testName.TestName ,test3=testName.TestName}

                              }
                              ).ToListAsync();

            }
            return null;

        }

    }
}
