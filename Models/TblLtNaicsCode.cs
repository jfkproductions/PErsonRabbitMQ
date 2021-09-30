using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblLtNaicsCode
    {
        public TblLtNaicsCode()
        {
            TblOperationsDetial = new HashSet<TblOperationsDetial>();
        }

        public int NiacsCodeId { get; set; }
        public string NiacsCode { get; set; }
        public string NiacsCodeDesc { get; set; }

        public virtual ICollection<TblOperationsDetial> TblOperationsDetial { get; set; }
    }
}
