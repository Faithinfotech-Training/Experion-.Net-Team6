using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblLabReport
    {
        public int LabReportId { get; set; }
        public int? PatientId { get; set; }
        public int? StaffId { get; set; }
        public int? LogId { get; set; }
        public int? TestId { get; set; }
        public string ObservedResult { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
        public virtual TblPatient Patient { get; set; }
        public virtual TblStaff Staff { get; set; }
        public virtual TblMasterLabTest Test { get; set; }
    }
}
