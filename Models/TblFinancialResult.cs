using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblFinancialResult
    {
        public TblFinancialResult()
        {
            TblOrganizationDetail = new HashSet<TblOrganizationDetail>();
        }

        public int FinancialResultId { get; set; }
        public decimal? InventoryTurnover { get; set; }
        public decimal? GrossProfitAmount { get; set; }
        public decimal? ProfitAfterTaxAmount { get; set; }
        public decimal? EbitadaAmount { get; set; }
        public decimal? EbitAmount { get; set; }
        public decimal? EbtAmount { get; set; }
        public decimal? NetEarningsAmount { get; set; }
        public decimal? GrossEarningsAmount { get; set; }
        public decimal? OperationsCostAmount { get; set; }
        public decimal? DividentPerShareAmount { get; set; }
        public decimal? EarningsPerShareAmount { get; set; }
        public decimal? TaxesPaidAmount { get; set; }
        public decimal? InterestPaidAmount { get; set; }
        public decimal? NetResultAmount { get; set; }
        public decimal? ChangedValueAmount { get; set; }
        public decimal? RevenueAmount { get; set; }

        public virtual ICollection<TblOrganizationDetail> TblOrganizationDetail { get; set; }
    }
}
