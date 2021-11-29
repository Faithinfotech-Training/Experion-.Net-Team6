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
        public int? TestOneId { get; set; }
        public int? TestTwoId { get; set; }
        public int? TestThreeId { get; set; }
        public string ObservedResultOne { get; set; }
        public string ObservedResultTwo { get; set; }
        public string ObservedResultThree { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
        public virtual TblPatient Patient { get; set; }
        public virtual TblStaff Staff { get; set; }
        public virtual TblMasterLabTest TestOne { get; set; }
        public virtual TblMasterLabTest TestThree { get; set; }
        public virtual TblMasterLabTest TestTwo { get; set; }
    }
}
