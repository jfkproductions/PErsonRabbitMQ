using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblLtSicCode
    {
        public TblLtSicCode()
        {
            TblOperationsDetial = new HashSet<TblOperationsDetial>();
        }

        public int SicCodeId { get; set; }
        public string SicCode { get; set; }
        public string SicCodeDesc { get; set; }

        public virtual ICollection<TblOperationsDetial> TblOperationsDetial { get; set; }
    }
}
