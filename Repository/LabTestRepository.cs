using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
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
            var prescriptiontest = await db.TblPrescriptionTest.FirstOrDefaultAsync(p => p.PrescriptionTestId == id);
            if (prescriptiontest == null)
            {
                return null;
            }
            return prescriptiontest;
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
