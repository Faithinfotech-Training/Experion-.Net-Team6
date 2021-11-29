using cmsRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public interface IPrescMedicineRepo
    {
        //Get PrescMedicines//
        Task<List<TblPrescriptionMedicine>> GetPrescMedicines();
        //Get PrescMedicine By Id//
        Task<TblPrescriptionMedicine> GetPrescMedicineById(int id);
        //--- add PrescMedicine ---//
        Task<TblPrescriptionMedicine> AddPrescMedicine(TblPrescriptionMedicine prescmedicine);
        //--- update PrescMedicine ---//
        Task<TblPrescriptionMedicine> UpdatePrescMedicine(TblPrescriptionMedicine prescmedicine);
    }
}
