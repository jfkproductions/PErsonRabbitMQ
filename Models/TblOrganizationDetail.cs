using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblOrganizationDetail
    {
        public int? OperationsDatialiD { get; set; }
        public int OrganizationId { get; set; }
        public int OrganizationDetailId { get; set; }
        public int? OrganizationLegalStatusId { get; set; }
        public int? FinancialResultId { get; set; }
        public int? EmployeeSummeryDetailId { get; set; }

        public virtual TblEmployeeSummeryDetail EmployeeSummeryDetail { get; set; }
        public virtual TblFinancialResult FinancialResult { get; set; }
        public virtual TblOperationsDetial OperationsDatial { get; set; }
        public virtual TblOrganization Organization { get; set; }
        public virtual TblOrganizationLegalStatus OrganizationLegalStatus { get; set; }
    }
}
