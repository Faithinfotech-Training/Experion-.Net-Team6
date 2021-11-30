using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblPrescriptionMedicine
    {
        public int PrescriptionMedicineId { get; set; }
        public int? LogId { get; set; }
        public string MedicineOneId { get; set; }
        public string MedicineOneDosage { get; set; }
        public string MedicineTwo { get; set; }
        public string MedicineTwoDosage { get; set; }
        public string MedicineThree { get; set; }
        public string MedicineThreeDosage { get; set; }
        public string MedicineFour { get; set; }
        public string MedicineFourDosage { get; set; }
        public string MedicineFive { get; set; }
        public string MedicineFiveDosage { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
    }
}
