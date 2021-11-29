using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.ViewModel
{
    public class LabReportViewModel
    {
        public int LabReportId { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public int StaffId { get; set; }

        public string StaffName { get; set; }

        public string DoctorName { get; set; }

        public DateTime? DateOfAppointment { get; set; }

        public int TestId { get; set; }

        public string TestName { get; set; }

        public string NormalRange { get; set; }

        public string ObservedResult { get; set; }
    }
}
