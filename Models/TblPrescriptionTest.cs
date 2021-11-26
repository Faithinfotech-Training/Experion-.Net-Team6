using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblPrescriptionTest
    {
        public int PrescriptionTestId { get; set; }
        public int? LogId { get; set; }
        public int? TestId { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
        public virtual TblMasterLabTest Test { get; set; }
    }
}
