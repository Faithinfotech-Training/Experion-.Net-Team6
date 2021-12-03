using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cmsRestApi.Models;

namespace cmsRestApi.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        ClinicManagementSystemDBContext db;

        public DoctorRepository(ClinicManagementSystemDBContext _db)
        {
            db = _db;
        }

        //Crud Operation

        #region get specialization

        public async Task<List<TblSpecialization>> GetAllSpecialization()
        {
            if (db != null)
            {
                return await db.TblSpecialization.ToListAsync();
            }
            return null;
        }

        #endregion

        #region get Doctor

        public async Task<List<TblDoctor>> GetAllDoctor()
        {
            if(db!=null)
            {
                return await db.TblDoctor.ToListAsync();
            }
            return null;
        }

        #endregion

        //CRUD
        #region get a doctor

        public async Task<TblDoctor> GetADoctor(int id)
        {
            if (db != null)
            {
                var doctor = db.TblDoctor.FirstOrDefault(doc => doc.DoctorId == id);
                return doctor;

            }
            return null;


        }

        #endregion

        #region Add Doctor

        public async Task<int> AddDoctor(TblDoctor doctor)
        {
            if(db != null)
            {
                await db.TblDoctor.AddAsync(doctor);
                await db.SaveChangesAsync(); //commit
                return doctor.DoctorId;
            }
            return 0;
        }

        #endregion

        #region Update doctor

        public async Task<List<TblDoctor>> PutDoctor(TblDoctor doctor)
        {
            if(db != null)
            {
                var doct = db.TblDoctor.FirstOrDefault(doc => doc.DoctorId == doctor.DoctorId);
                doct.DoctorName = doctor.DoctorName;
                doct.DoctorSpecializationId = doctor.DoctorSpecializationId;
                doct.DoctorQualification = doctor.DoctorQualification;
                doct.DoctorAge = doctor.DoctorAge;
                doct.DoctorGender = doctor.DoctorGender;
                doct.DoctorDateofBirth = doctor.DoctorDateofBirth;
                doct.DoctorContactNo = doctor.DoctorContactNo;
                doct.DoctorLocation = doctor.DoctorLocation;
                doct.IsActive = doctor.IsActive;
                await db.SaveChangesAsync();



                return await db.TblDoctor.ToListAsync();
            }
            return null;
        }

        #endregion
    }
}
