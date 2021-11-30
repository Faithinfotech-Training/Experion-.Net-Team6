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
        public string TestOne { get; set; }
        public string TestTwo { get; set; }
        public string TestThree { get; set; }
        public string ObservedResultOne { get; set; }
        public string ObservedResultTwo { get; set; }
        public string ObservedResultThree { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
        public virtual TblPatient Patient { get; set; }
        public virtual TblStaff Staff { get; set; }
    }
}
