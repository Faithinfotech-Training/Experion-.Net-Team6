using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblPatient
    {
        public TblPatient()
        {
            TblAppointment = new HashSet<TblAppointment>();
            TblLabReport = new HashSet<TblLabReport>();
            TblPatientLog = new HashSet<TblPatientLog>();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public string ContactNo { get; set; }
        public string EmergencyContact { get; set; }
        public bool? IsActive { get; set; }
        public string EmailId { get; set; }

        public virtual ICollection<TblAppointment> TblAppointment { get; set; }
        public virtual ICollection<TblLabReport> TblLabReport { get; set; }
        public virtual ICollection<TblPatientLog> TblPatientLog { get; set; }
    }
}
