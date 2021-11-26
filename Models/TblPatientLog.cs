using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblPatientLog
    {
        public TblPatientLog()
        {
            TblLabReport = new HashSet<TblLabReport>();
            TblPayment = new HashSet<TblPayment>();
            TblPrescriptionMedicine = new HashSet<TblPrescriptionMedicine>();
            TblPrescriptionTest = new HashSet<TblPrescriptionTest>();
        }

        public int LogId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? AppointmentId { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblAppointment Appointment { get; set; }
        public virtual TblDoctor Doctor { get; set; }
        public virtual TblPatient Patient { get; set; }
        public virtual ICollection<TblLabReport> TblLabReport { get; set; }
        public virtual ICollection<TblPayment> TblPayment { get; set; }
        public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicine { get; set; }
        public virtual ICollection<TblPrescriptionTest> TblPrescriptionTest { get; set; }
    }
}
