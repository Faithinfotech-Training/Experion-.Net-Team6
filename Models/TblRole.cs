using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblStaff = new HashSet<TblStaff>();
            TblUser = new HashSet<TblUser>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblStaff> TblStaff { get; set; }
        public virtual ICollection<TblUser> TblUser { get; set; }
    }
}
