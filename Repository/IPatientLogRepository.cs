using cmsRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public interface IPatientLogRepository
    {
        //Operations on Patient Log

        //get all users
        Task<List<TblPatientLog>> GetPatientLog(int id);
    }
}
