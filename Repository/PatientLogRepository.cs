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
                return await (
                              from appointment in db.TblAppointment
                              join doctor in db.TblDoctor on appointment.DoctorId equals doctor.DoctorId
                              join patient in db.TblPatient on appointment.PatientId equals patient.PatientId
                              where patient.PatientId == id
                              join log in db.TblPatientLog on appointment.AppointmentId equals log.AppointmentId
                              join medicine in db.TblPrescriptionMedicine on log.LogId equals medicine.LogId into LogMedicineDetails
                              from n in LogMedicineDetails.DefaultIfEmpty()
                              join test in db.TblPrescriptionTest on log.LogId equals test.LogId into LogTestDetails
                              from m in LogTestDetails.DefaultIfEmpty()

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
                                  DateofAppointment = appointment.DateofAppointment,
                                  Notes = log.Notes,
                                  Observations = log.Observations,
                                  MedicineOne = n.MedicineOneId,
                                  MedicineTwo = n.MedicineTwo,
                                  MedicineThree = n.MedicineThree,
                                  MedicineFour = n.MedicineFour,
                                  MedicineOneDosage=n.MedicineOneDosage,
                                  MedicineTwoDosage=n.MedicineTwoDosage,
                                  MedicineThreeDosage=n.MedicineThreeDosage,
                                  MedicineFourDosage=n.MedicineFourDosage,
                                LabTestOne=m.TestOne,
                                LabTestTwo=m.TestTwo,
                                 LabTestThree=m.TestThree

                              }
                              ).ToListAsync();

            }
            return null;

        }

        
    }
}
