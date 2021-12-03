using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Models
{
    public interface IAnnouncementRepo
    { 
      //--- get event by id ---//
        Task<TblAnnouncements> GetAnnouncementById(int id);
    //--- get announcements  ---//
    //--- get announcements ---//
    Task<List<TblAnnouncements>> GetAnnouncements();
    //--- add announcements ---//
    Task<TblAnnouncements> AddAnnouncements(TblAnnouncements announcements);

    //--- update announcement ---//
    Task<TblAnnouncements> UpdateAnnouncement(TblAnnouncements announcements);
    Task<TblAnnouncements> UpdateAnnouncementByActive(int id);
}
}
