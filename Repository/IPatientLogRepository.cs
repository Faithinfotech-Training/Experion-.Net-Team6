using cmsRestApi.Models;
using cmsRestApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public interface IPatientLogRepository
    {
        //Operations on Patient Log

        //get all Log
        Task<List<TblPatientLog>> GetPatientLog(int id);

        Task<List<PatientLogViewModel>> GetPatientLogViewModel(int id);

        Task<int> AddPatientLog(TblPatientLog log);

    }
}
