using cmsRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public interface IPatientRepo
    {
        //--- get patient by id ---//
        Task<TblPatient> GetPatientById(int id);
        //--- get patient  ---//
        Task<TblPatient> getPatient(int id);
        //--- get patients ---//
        Task<List<TblPatient>> GetPatients();
        //--- add event ---//
        Task<TblPatient> AddPatient(TblPatient patient);

        //--- update event ---//
        Task<TblPatient> UpdatePatient(TblPatient patient);
        //
        Task<TblPatient> updatePatientByActive(int id);
    }

}
