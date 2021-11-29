using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.ViewModel
{
    public class LabViewForLabTechnician
    {
        public string PatientName { get; set; }

        public string DoctorName { get; set; }

        public DateTime? Date { get; set; }

        public string Test1 { get; set; }
        public string Test2 { get; set; }
        public string Test3 { get; set; }

        public string Status { get; set; }

    }
}
