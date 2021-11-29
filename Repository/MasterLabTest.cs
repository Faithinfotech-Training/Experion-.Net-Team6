using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace cmsRestApi.Repository
{
    public class MasterLabTest : IMasterLabTest
    {
        ClinicManagementSystemDBContext db;

        public MasterLabTest(ClinicManagementSystemDBContext _db)
        {
            this.db = _db;
        }
        public async Task<TblMasterLabTest> GetLabTestbyId(int id)
        {
            var labtest = await db.TblMasterLabTest.FirstOrDefaultAsync(labtest => labtest.TestId == id );
            if (labtest == null)
            {
                return null;
            }
            return labtest;
        }

        public async Task<List<TblMasterLabTest>> GetLabTests()
        {
            if (db != null)
            {
                return await db.TblMasterLabTest.ToListAsync();
            }
            return null;
        }
    }
}
