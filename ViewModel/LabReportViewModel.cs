using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.ViewModel
{
    public class LabReportViewModel
    {
        public int LogId { get; set; }
        public int LabReportId { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public int StaffId { get; set; }

        public string StaffName { get; set; }

        public string DoctorName { get; set; }

        public DateTime? DateOfAppointment { get; set; }

       

        public string TestOneName { get; set; }
        public string ObservedResultOne { get; set; }
        public string TestTwoName { get; set; }
        public string ObservedResultTwo { get; set; }
        public string TestThreeName { get; set; }
        public string ObservedResultThree { get; set; }
        public string NormalRange { get; set; }

       
    }
}
