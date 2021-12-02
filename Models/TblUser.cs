using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblDoctor = new HashSet<TblDoctor>();
            TblStaff = new HashSet<TblStaff>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblRole Role { get; set; }
        public virtual ICollection<TblDoctor> TblDoctor { get; set; }
        public virtual ICollection<TblStaff> TblStaff { get; set; }
    }
}
