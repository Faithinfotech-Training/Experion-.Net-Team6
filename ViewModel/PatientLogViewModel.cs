using cmsRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.ViewModel
{
    public class PatientLogViewModel
    {
        //Datas for Patient log view model
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Location { get; set; }
        public string ContactNo { get; set; }
        public string EmergencyContact { get; set; }
        public bool? IsActive { get; set; }
        public string Notes { get; set; }
        public string Observations { get; set; }
        public string DoctorName { get; set; }
        public string SpecializationName { get; set; }
        public DateTime? DateofAppointment { get; set; }
        public string MedicineOne { get; set; }
        public string MedicineOneDosage { get; set; }
        public string MedicineTwo { get; set; }
        public string MedicineTwoDosage { get; set; }
        public string MedicineThree { get; set; }
        public string MedicineThreeDosage { get; set; }
        public string MedicineFour { get; set; }
        public string MedicineFourDosage { get; set; }
        public string LabTestOne { get; set; }
        public string LabTestTwo { get; set; }
        public string LabTestThree { get; set; }

    }

  
}
