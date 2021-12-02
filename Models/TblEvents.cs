using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblEvents
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventDecription { get; set; }
    }
}
