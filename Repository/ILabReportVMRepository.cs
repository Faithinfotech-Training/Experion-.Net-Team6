using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using cmsRestApi.ViewModel;

namespace cmsRestApi.Repository
{
    public interface ILabReportVMRepository
    {
        Task<List<LabReportViewModel>> GetAllLabReport();

        Task<List<LabReportViewModel>> GetLabReport(int id);

        Task<int> AddLabReport(TblLabReport report);
    }
}
