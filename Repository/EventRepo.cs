using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public class EventRepo : IEventRepo
    {
        ClinicManagementSystemDBContext _db;

        public EventRepo(ClinicManagementSystemDBContext db)
        {
            _db = db;
        }

        public async Task<List<TblEvents>> GetEvents()
        {
            if (_db != null)
            {
                return await _db.TblEvents.ToListAsync();
            }
            return null;


        }
        public async Task<TblEvents> GetEventById(int id)
        {
            var user = await _db.TblEvents.SingleOrDefaultAsync(u => u.EventId == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<TblEvents> getEvent(int id)
        {
            var user = await _db.TblEvents.SingleOrDefaultAsync(u => u.EventId == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }



        public async Task<TblEvents> AddEvent(TblEvents events)
        {
            //--- member function to add patient ---//
            if (_db != null)
            {
                await _db.TblEvents.AddAsync(events);
                await _db.SaveChangesAsync();
                return events;
            }
            return null;

        }
        public async Task<TblEvents> UpdateEvent(TblEvents events)
        {
            //member function to update patient
            if (_db != null)
            {
                _db.TblEvents.Update(events);
                await _db.SaveChangesAsync();
                return events;
            }
            return null;
        }
        public async Task<TblEvents> UpdateEventByActive(int id)
        {
            //member function to delete event
            if (_db != null)
            {
                TblEvents events = await _db.TblEvents.FirstOrDefaultAsync(em => em.EventId == id);
                events.IsActive = false;
                _db.TblEvents.Update(events);
                await _db.SaveChangesAsync();
                return events;
            }
            return null;
        }

    }
}
