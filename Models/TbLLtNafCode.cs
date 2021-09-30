using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TbLLtNafCode
    {
        public TbLLtNafCode()
        {
            TblOperationsDetial = new HashSet<TblOperationsDetial>();
        }

        public int NafCodeId { get; set; }
        public string NafCode { get; set; }
        public string NafCodeDesc { get; set; }

        public virtual ICollection<TblOperationsDetial> TblOperationsDetial { get; set; }
    }
}
