using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblDoctor
    {
        public TblDoctor()
        {
            TblAppointment = new HashSet<TblAppointment>();
            TblPatientLog = new HashSet<TblPatientLog>();
        }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int? DoctorSpecializationId { get; set; }
        public string DoctorQualification { get; set; }
        public int? DoctorAge { get; set; }
        public string DoctorGender { get; set; }
        public DateTime? DoctorDateofBirth { get; set; }
        public string DoctorContactNo { get; set; }
        public string DoctorLocation { get; set; }
        public bool? IsActive { get; set; }
        public int? UserId { get; set; }

        public virtual TblSpecialization DoctorSpecialization { get; set; }
        public virtual TblUser User { get; set; }
        public virtual ICollection<TblAppointment> TblAppointment { get; set; }
        public virtual ICollection<TblPatientLog> TblPatientLog { get; set; }
    }
}
