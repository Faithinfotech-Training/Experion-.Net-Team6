using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using cmsRestApi.ViewModel;

namespace cmsRestApi.Repository
{
    public interface ILabTestRepository
    {
        Task<List<TblPrescriptionTest>> GetPrescriptionTests();
        Task<TblPrescriptionTest> GetPrescriptionTestbyId(int id);
        Task<int> AddPrescriptionTest(TblPrescriptionTest test);
        Task<int> UpdatePrescriptionTest(TblPrescriptionTest test);

        Task<List<LabViewForLabTechnician>> GetLabTestView();

        Task<List<ReportFormView>> GetFormView(int LogId);

        Task<TblPrescriptionTest>  updateTestStatus(int LogId);
    }
}
