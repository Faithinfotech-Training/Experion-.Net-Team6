using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblPrescriptionMedicine
    {
        public int PrescriptionMedicineId { get; set; }
        public int? LogId { get; set; }
        public int? MedicineId { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
        public virtual TblMasterMedicine Medicine { get; set; }
    }
}
