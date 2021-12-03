using cmsRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public interface IEventRepo
    {
        //--- get event by id ---//
        Task<TblEvents> GetEventById(int id);
        //--- get events  ---//
        Task<TblEvents> getEvent(int id);
        //--- get patients ---//
        Task<List<TblEvents>> GetEvents();
        //--- add Patient ---//
        Task<TblEvents> AddEvent(TblEvents events);

        //--- update Patient ---//
        Task<TblEvents> UpdateEvent(TblEvents events);
        Task<TblEvents> UpdateEventByActive(int id);
    }
}
