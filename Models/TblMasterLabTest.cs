using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblMasterLabTest
    {
        public TblMasterLabTest()
        {
            TblLabReportTestOne = new HashSet<TblLabReport>();
            TblLabReportTestThree = new HashSet<TblLabReport>();
            TblLabReportTestTwo = new HashSet<TblLabReport>();
            TblPrescriptionTestTestOne = new HashSet<TblPrescriptionTest>();
            TblPrescriptionTestTestThree = new HashSet<TblPrescriptionTest>();
            TblPrescriptionTestTestTwo = new HashSet<TblPrescriptionTest>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public string NormalRange { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblLabReport> TblLabReportTestOne { get; set; }
        public virtual ICollection<TblLabReport> TblLabReportTestThree { get; set; }
        public virtual ICollection<TblLabReport> TblLabReportTestTwo { get; set; }
        public virtual ICollection<TblPrescriptionTest> TblPrescriptionTestTestOne { get; set; }
        public virtual ICollection<TblPrescriptionTest> TblPrescriptionTestTestThree { get; set; }
        public virtual ICollection<TblPrescriptionTest> TblPrescriptionTestTestTwo { get; set; }
    }
}
