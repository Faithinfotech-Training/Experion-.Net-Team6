using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.ViewModel
{
    public class ReportFormView
    {
        public int LogId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string? TestOne { get; set; }
        public string? TestTwo { get; set; }
        public string? TestThree { get; set; }

    }
}
