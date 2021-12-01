using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public class PatientRepo : IPatientRepo
    {
        ClinicManagementSystemDBContext _db;

        public PatientRepo(ClinicManagementSystemDBContext db)
        {
            _db = db;
        }
       
        public async Task<List<TblPatient>> GetPatients()
        {
            if (_db != null)
            {
                return await _db.TblPatient.ToListAsync();
            }
            return null;


        }
        public async Task<TblPatient> GetPatientById(int id)
        {
            var user = await _db.TblPatient.SingleOrDefaultAsync(u => u.PatientId == id);
        if (user == null)
        {
            return null;
            }
            return user;
            }

        public async Task<TblPatient> getPatient(int id)
        {
            var user = await _db.TblPatient.SingleOrDefaultAsync(u => u.PatientId == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }



        public async Task<TblPatient> AddPatient(TblPatient patient)
        {
            //--- member function to add patient ---//
            if (_db != null)
            {
                await _db.TblPatient.AddAsync(patient);
                await _db.SaveChangesAsync();
                return patient;
            }
            return null;

        }
        public async Task<TblPatient> UpdatePatient(TblPatient patient)
        {
            //member function to update patient
            if (_db != null)
            {
                _db.TblPatient.Update(patient);
                await _db.SaveChangesAsync();
                return patient;
            }
            return null;
        }
        public async Task<TblPatient> updatePatientByActive(int id)
        {
            //member function to delete patient
            if (_db != null)
            {
                TblPatient patient = await _db.TblPatient.FirstOrDefaultAsync(em => em.PatientId == id);
                patient.IsActive = false;
                _db.TblPatient.Update(patient);
                await _db.SaveChangesAsync();
                return patient;
            }
            return null;
        }

    }
}
