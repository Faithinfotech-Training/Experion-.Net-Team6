using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public class PrescMedicineRepo : IPrescMedicineRepo
    {

        ClinicManagementSystemDBContext _db;

        public PrescMedicineRepo(ClinicManagementSystemDBContext db)
        {
            _db = db;
        }
        // Get Presc Medicines
        public async Task<List<TblPrescriptionMedicine>> GetPrescMedicines()
        {
            if (_db != null)
            {
                return await _db.TblPrescriptionMedicine.ToListAsync();
            }
            return null;
        }
        // Add PrescMedicine
        public async Task<TblPrescriptionMedicine> AddPrescMedicine(TblPrescriptionMedicine prescmedicine)
        {
            //--- member function to add medicine ---//
            if (_db != null)
            {
                await _db.TblPrescriptionMedicine.AddAsync(prescmedicine);
                await _db.SaveChangesAsync();
                return prescmedicine;
            }
            return null;

        }
        //Update PrescMedicine
        public async Task<TblPrescriptionMedicine> UpdatePrescMedicine(TblPrescriptionMedicine prescmedicine)
        {
            //member function to update patient
            if (_db != null)
            {
                _db.TblPrescriptionMedicine.Update(prescmedicine);
                await _db.SaveChangesAsync();
                return prescmedicine;
            }
            return null;
        }
        // Get PrescMedicine By Id
        public async Task<TblPrescriptionMedicine> GetPrescMedicineById(int id)
        {
            var med = await _db.TblPrescriptionMedicine.SingleOrDefaultAsync(u => u.PrescriptionMedicineId == id);
            if (med == null)
            {
                return null;
            }
            return med;
        }
    }
}
