using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblAppointment
    {
        public TblAppointment()
        {
            TblPatientLog = new HashSet<TblPatientLog>();
        }

        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? DateofAppointment { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblDoctor Doctor { get; set; }
        public virtual TblPatient Patient { get; set; }
        public virtual ICollection<TblPatientLog> TblPatientLog { get; set; }
    }
}
