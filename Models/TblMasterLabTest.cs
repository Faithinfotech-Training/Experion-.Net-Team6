using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblMasterLabTest
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public string NormalRange { get; set; }
        public bool? IsActive { get; set; }
    }
}
