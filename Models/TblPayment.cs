using System;
using System.Collections.Generic;

namespace cmsRestApi.Models
{
    public partial class TblPayment
    {
        public int PaymentId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? LogId { get; set; }
        public string Amount { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblPatientLog Log { get; set; }
    }
}
