using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblLtLegalEntityCodeList
    {
        public TblLtLegalEntityCodeList()
        {
            TblCustomerRelationship = new HashSet<TblCustomerRelationship>();
            TblOrganizationLegalStatus = new HashSet<TblOrganizationLegalStatus>();
        }

        public int LegalEntityCodeId { get; set; }
        public string LegalEntityCode { get; set; }
        public string LegalEntityCodeDesc { get; set; }

        public virtual ICollection<TblCustomerRelationship> TblCustomerRelationship { get; set; }
        public virtual ICollection<TblOrganizationLegalStatus> TblOrganizationLegalStatus { get; set; }
    }
}
