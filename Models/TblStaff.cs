using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblStaff
    {
        public TblStaff()
        {
            TblLabReport = new HashSet<TblLabReport>();
        }

        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public int? RoleId { get; set; }
        public int? StaffAge { get; set; }
        public string StaffGender { get; set; }
        public DateTime? StaffDateofBirth { get; set; }
        public string StaffContactNo { get; set; }
        public string StaffLocation { get; set; }
        public bool? IsActive { get; set; }
        public int? UserId { get; set; }

        public virtual TblRole Role { get; set; }
        public virtual TblUser User { get; set; }
        public virtual ICollection<TblLabReport> TblLabReport { get; set; }
    }
}
