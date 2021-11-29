using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;

namespace cmsRestApi.Repository
{
    public interface IMasterLabTest
    {
        Task<List<TblMasterLabTest>> GetLabTests();
        Task<TblMasterLabTest> GetLabTestbyId( int id);
    }
}
