using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblIncomeDetail
    {
        public int IncomeDetailId { get; set; }
        public decimal IndividualIncome { get; set; }
        public int FrequencyId { get; set; }
        public int PersonId { get; set; }

        public virtual TblLtFrequency Frequency { get; set; }
        public virtual TblPerson Person { get; set; }
    }
}
