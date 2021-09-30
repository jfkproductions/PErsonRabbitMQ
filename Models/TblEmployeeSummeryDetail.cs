using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblEmployeeSummeryDetail
    {
        public TblEmployeeSummeryDetail()
        {
            TblOrganizationDetail = new HashSet<TblOrganizationDetail>();
        }

        public int EmployeeSummeryDetailId { get; set; }
        public decimal? TotalWagesPaidAmount { get; set; }
        public decimal? AverageEmployeeCount { get; set; }
        public decimal? AverageEmployeeAge { get; set; }
        public decimal? MaleStaffPercentage { get; set; }
        public decimal? FemaleStaffPercentage { get; set; }
        public decimal? EmployeeTurnoverPercentage { get; set; }

        public virtual ICollection<TblOrganizationDetail> TblOrganizationDetail { get; set; }
    }
}
