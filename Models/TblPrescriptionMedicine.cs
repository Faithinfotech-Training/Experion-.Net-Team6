using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblPrescriptionMedicine
    {
        public int PrescriptionMedicineId { get; set; }
        public int? LogId { get; set; }
        public int? MedicineOneId { get; set; }
        public string MedicineOneDosage { get; set; }
        public int? MedicineTwoId { get; set; }
        public string MedicineTwoDosage { get; set; }
        public int? MedicineThreeId { get; set; }
        public string MedicineThreeDosage { get; set; }
        public int? MedicineFourId { get; set; }
        public string MedicineFourDosage { get; set; }
        public int? MedicineFiveId { get; set; }
        public string MedicineFiveDosage { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
        public virtual TblMasterMedicine MedicineFive { get; set; }
        public virtual TblMasterMedicine MedicineFour { get; set; }
        public virtual TblMasterMedicine MedicineOne { get; set; }
        public virtual TblMasterMedicine MedicineThree { get; set; }
        public virtual TblMasterMedicine MedicineTwo { get; set; }
    }
}
