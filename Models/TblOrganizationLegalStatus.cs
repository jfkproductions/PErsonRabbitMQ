using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblOrganizationLegalStatus
    {
        public TblOrganizationLegalStatus()
        {
            TblOrganizationDetail = new HashSet<TblOrganizationDetail>();
        }

        public int OrganizationLegalStatusId { get; set; }
        public int? LegalEntityTypeCodeId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string AbreviationName { get; set; }
        public bool? TaxExemptindicator { get; set; }

        public virtual TblLtLegalEntityCodeList LegalEntityTypeCode { get; set; }
        public virtual ICollection<TblOrganizationDetail> TblOrganizationDetail { get; set; }
    }
}
