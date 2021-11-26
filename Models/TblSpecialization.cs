using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblSpecialization
    {
        public TblSpecialization()
        {
            TblDoctor = new HashSet<TblDoctor>();
        }

        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }

        public virtual ICollection<TblDoctor> TblDoctor { get; set; }
    }
}
