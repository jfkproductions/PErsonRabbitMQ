using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblOrganization
    {
        public TblOrganization()
        {
            TblCompany = new HashSet<TblCompany>();
            TblGovermentBody = new HashSet<TblGovermentBody>();
            TblLtOrganizationDetail = new HashSet<TblLtOrganizationDetail>();
            TblOrganizationDetail = new HashSet<TblOrganizationDetail>();
            TblOrganizationName = new HashSet<TblOrganizationName>();
            TblOrganizationRelationship = new HashSet<TblOrganizationRelationship>();
            TblOrganizationUnit = new HashSet<TblOrganizationUnit>();
        }

        public int OrganizationId { get; set; }
        public double MemberCount { get; set; }
        public int OrganizationStatusCodeId { get; set; }
        public string StatusReason { get; set; }
        public int OrganizationTypeCodeId { get; set; }

        public virtual TblLtOrganizationStatusCodeList OrganizationStatusCode { get; set; }
        public virtual TblLtOrganizationTypeCodeList OrganizationTypeCode { get; set; }
        public virtual ICollection<TblCompany> TblCompany { get; set; }
        public virtual ICollection<TblGovermentBody> TblGovermentBody { get; set; }
        public virtual ICollection<TblLtOrganizationDetail> TblLtOrganizationDetail { get; set; }
        public virtual ICollection<TblOrganizationDetail> TblOrganizationDetail { get; set; }
        public virtual ICollection<TblOrganizationName> TblOrganizationName { get; set; }
        public virtual ICollection<TblOrganizationRelationship> TblOrganizationRelationship { get; set; }
        public virtual ICollection<TblOrganizationUnit> TblOrganizationUnit { get; set; }
    }
}
