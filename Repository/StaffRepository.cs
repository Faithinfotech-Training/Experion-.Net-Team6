using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace cmsRestApi.Repository
{
    public class StaffRepository : IStaffRepository
    {
        ClinicManagementSystemDBContext db;

        public StaffRepository(ClinicManagementSystemDBContext _db)
        {
            this.db = _db;
        }

        public async Task<List<TblStaff>> GetStaffs()
        {
            if (db != null)
            {
                return await db.TblStaff.ToListAsync();
            }
            return null;
        }


        public async Task<TblStaff> GetStaffbyId(int id)
        {
            var staff = await db.TblStaff.FirstOrDefaultAsync(staff=>staff.StaffId == id);
            if (staff == null)
            {
                return null;
            }
            return staff;
        }

        public async Task<int> AddStaff(TblStaff staff)
        {
            if (db != null)
            {
                await db.TblStaff.AddAsync(staff);
                await db.SaveChangesAsync();
            }
            return staff.StaffId;
        }

        public async Task<int> UpdateStaff(TblStaff staff)
        {
            if (db != null)
            {
                db.TblStaff.Update(staff);
                await db.SaveChangesAsync();
            }
            return staff.StaffId;
        }

        public async Task<List<TblStaff>> GetStaffId(string userName)
        {
            if (db != null)
            {
                return await (
                                from user in db.TblUser
                                from staff in db.TblStaff
                                where user.UserName == userName
                                where staff.UserId == user.UserId
                                select new TblStaff
                                {
                                    StaffId = staff.StaffId
                                }
                    ).ToListAsync();
            }
            return null;
        }
    }
}
