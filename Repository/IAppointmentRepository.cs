﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;

namespace cmsRestApi.Repository
{
    public interface IAppointmentRepository
    {
        Task<List<TblAppointment>> GetAppointment();
        Task<TblAppointment> GetAppointmentbyId(int id);
        Task<List<TblAppointment>> GetAppointmentbyDoctorId(int id);
        Task<int> AddAppointment(TblAppointment appointment);
        Task<int> UpdateAppointment(TblAppointment appointment);
    }
}
