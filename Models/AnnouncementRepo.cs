using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Models
{
    public class AnnouncementRepo : IAnnouncementRepo
    {
        ClinicManagementSystemDBContext _db;

        public AnnouncementRepo(ClinicManagementSystemDBContext db)
        {
            _db = db;
        }

        public async Task<List<TblAnnouncements>> GetAnnouncements()
        {
            if (_db != null)
            {
                return await _db.TblAnnouncements.ToListAsync();
            }
            return null;


        }
        public async Task<TblAnnouncements> GetAnnouncementById(int id)
        {
            var user = await _db.TblAnnouncements.SingleOrDefaultAsync(u => u.AnnouncementId == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }


        public async Task<TblAnnouncements> AddAnnouncements(TblAnnouncements announcement)
        {
            //--- member function to add patient ---//
            if (_db != null)
            {
                await _db.TblAnnouncements.AddAsync(announcement);
                await _db.SaveChangesAsync();
                return announcement;
            }
            return null;

        }
        public async Task<TblAnnouncements> UpdateAnnouncement(TblAnnouncements announcement)
        {
            //member function to update patient
            if (_db != null)
            {
                _db.TblAnnouncements.Update(announcement);
                await _db.SaveChangesAsync();
                return announcement;
            }
            return null;
        }
        public async Task<TblAnnouncements> UpdateAnnouncementByActive(int id)
        {
            //member function to delete event
            if (_db != null)
            {
                TblAnnouncements announcements = await _db.TblAnnouncements.FirstOrDefaultAsync(em => em.AnnouncementId == id);
                announcements.IsActive = false;
                _db.TblAnnouncements.Update(announcements);
                await _db.SaveChangesAsync();
                return announcements;
            }
            return null;
        }

    }
}
