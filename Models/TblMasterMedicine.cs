using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblMasterMedicine
    {
        public TblMasterMedicine()
        {
            TblPrescriptionMedicine = new HashSet<TblPrescriptionMedicine>();
        }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicine { get; set; }
    }
}
