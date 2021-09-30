using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblLtFrequency
    {
        public TblLtFrequency()
        {
            TblIncomeDetail = new HashSet<TblIncomeDetail>();
        }

        public int FrequencyId { get; set; }
        public string FrequencyCode { get; set; }
        public string FrequencyCodeDesc { get; set; }

        public virtual ICollection<TblIncomeDetail> TblIncomeDetail { get; set; }
    }
}
