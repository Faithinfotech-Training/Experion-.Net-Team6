using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblMasterMedicine
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public bool? IsActive { get; set; }
    }
}
