using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;

namespace cmsRestApi.Repository
{
    public interface IStaffRepository
    {
        Task<List<TblStaff>> GetStaffs();
        Task<TblStaff> GetStaffbyId(int id);
        Task<int> AddStaff(TblStaff staff);
        Task<int> UpdateStaff(TblStaff staff);
    }
}
