using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;

namespace cmsRestApi.Repository
{
    public interface ILabTestRepository
    {
        Task<List<TblPrescriptionTest>> GetPrescriptionTests();
        Task<TblPrescriptionTest> GetPrescriptionTestbyId(int id);
        Task<int> AddPrescriptionTest(TblPrescriptionTest test);
        Task<int> UpdatePrescriptionTest(TblPrescriptionTest test);
    }
}
