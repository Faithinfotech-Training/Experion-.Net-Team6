using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblAnnouncements
    {
        public int AnnouncementId { get; set; }
        public DateTime? AnnouncementDate { get; set; }
        public string Subject { get; set; }
        public string Announcement { get; set; }
    }
}
