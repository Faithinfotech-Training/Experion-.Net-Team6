using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblPrescriptionTest
    {
        public int PrescriptionTestId { get; set; }
        public int? LogId { get; set; }
        public int? TestOneId { get; set; }
        public int? TestTwoId { get; set; }
        public int? TestThreeId { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
        public virtual TblMasterLabTest TestOne { get; set; }
        public virtual TblMasterLabTest TestThree { get; set; }
        public virtual TblMasterLabTest TestTwo { get; set; }
    }
}
