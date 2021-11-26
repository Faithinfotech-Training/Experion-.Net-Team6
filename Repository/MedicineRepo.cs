using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public class MedicineRepo: IMedicineRepo
    {
        ClinicManagementSystemDBContext _db;

        public MedicineRepo(ClinicManagementSystemDBContext db)
        {
            _db = db;
        }
        public async Task<List<TblMasterMedicine>> GetMedicines()
        {
            if (_db != null)
            {
                return await _db.TblMasterMedicine.ToListAsync();
            }
            return null;
        }
        public async Task<TblMasterMedicine> AddMedicine(TblMasterMedicine medicine)
        {
            //--- member function to add medicine ---//
            if (_db != null)
            {
                await _db.TblMasterMedicine.AddAsync(medicine);
                await _db.SaveChangesAsync();
                return medicine;
            }
            return null;

        }
        public async Task<TblMasterMedicine> UpdateMedicine(TblMasterMedicine medicine)
        {
            //member function to update patient
            if (_db != null)
            {
                _db.TblMasterMedicine.Update(medicine);
                await _db.SaveChangesAsync();
                return medicine;
            }
            return null;
        }
        public async Task<TblMasterMedicine> GetMedicineById(int id)
        {
            var med = await _db.TblMasterMedicine.SingleOrDefaultAsync(u => u.MedicineId == id);
            if (med == null)
            {
                return null;
            }
            return med;
        }
    }
}
