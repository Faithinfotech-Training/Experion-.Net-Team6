using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblMasterMedicine
    {
        public TblMasterMedicine()
        {
            TblPrescriptionMedicineMedicineFive = new HashSet<TblPrescriptionMedicine>();
            TblPrescriptionMedicineMedicineFour = new HashSet<TblPrescriptionMedicine>();
            TblPrescriptionMedicineMedicineOne = new HashSet<TblPrescriptionMedicine>();
            TblPrescriptionMedicineMedicineThree = new HashSet<TblPrescriptionMedicine>();
            TblPrescriptionMedicineMedicineTwo = new HashSet<TblPrescriptionMedicine>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicineMedicineFive { get; set; }
        public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicineMedicineFour { get; set; }
        public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicineMedicineOne { get; set; }
        public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicineMedicineThree { get; set; }
        public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicineMedicineTwo { get; set; }
    }
}
