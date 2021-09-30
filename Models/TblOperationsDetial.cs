using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblOperationsDetial
    {
        public TblOperationsDetial()
        {
            TblOrganizationDetail = new HashSet<TblOrganizationDetail>();
        }

        public int OperationsDatialiD { get; set; }
        public int? SicCodeId { get; set; }
        public int? NiacsCodeId { get; set; }
        public int? NafCodeId { get; set; }
        public string NNtureOfBussiness { get; set; }
        public DateTime? FiscalYearEndMonthDay { get; set; }
        public bool? Franchiseindicator { get; set; }
        public decimal? CustomerCount { get; set; }

        public virtual TbLLtNafCode NafCode { get; set; }
        public virtual TblLtNaicsCode NiacsCode { get; set; }
        public virtual TblLtSicCode SicCode { get; set; }
        public virtual ICollection<TblOrganizationDetail> TblOrganizationDetail { get; set; }
    }
}
