using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;

namespace cmsRestApi.Repository
{
    public interface IDoctorRepository
    {
        //get doctor
        Task<List<TblDoctor>> GetAllDoctor();

        //get a doctor
        Task<TblDoctor> GetADoctor(int id);

        //get specialization
        Task<List<TblSpecialization>> GetAllSpecialization();

        //Add Doctor
        Task<int> AddDoctor(TblDoctor doctor);

        //Update Doctor
        Task<List<TblDoctor>> PutDoctor(TblDoctor doctor);


    }
}
