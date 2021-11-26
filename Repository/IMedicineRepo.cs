using cmsRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public interface IMedicineRepo
    {
        //Get Medicines//
        Task<List<TblMasterMedicine>> GetMedicines();
        //Get Medicine By Id//
        Task<TblMasterMedicine> GetMedicineById(int id);
        //--- add Medicine ---//
        Task<TblMasterMedicine> AddMedicine(TblMasterMedicine medicine);
        //--- update Medicine ---//
        Task<TblMasterMedicine> UpdateMedicine(TblMasterMedicine medicine);
    }
}
