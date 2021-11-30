using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblPrescriptionTest
    {
        public int PrescriptionTestId { get; set; }
        public int? LogId { get; set; }
        public string TestOne { get; set; }
        public string TestTwo { get; set; }
        public string TestThree { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
    }
}
