using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblMasterLabTest
    {
        public TblMasterLabTest()
        {
            TblLabReport = new HashSet<TblLabReport>();
            TblPrescriptionTest = new HashSet<TblPrescriptionTest>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public string NormalRange { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblLabReport> TblLabReport { get; set; }
        public virtual ICollection<TblPrescriptionTest> TblPrescriptionTest { get; set; }
    }
}
