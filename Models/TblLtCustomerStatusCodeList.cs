using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblLtCustomerStatusCodeList
    {
        public TblLtCustomerStatusCodeList()
        {
            TblCustomerRelationship = new HashSet<TblCustomerRelationship>();
        }

        public int CustomerStatusCodeId { get; set; }
        public string CustomerStatusCode { get; set; }
        public string CustomerStatusCodeDesc { get; set; }

        public virtual ICollection<TblCustomerRelationship> TblCustomerRelationship { get; set; }
    }
}
