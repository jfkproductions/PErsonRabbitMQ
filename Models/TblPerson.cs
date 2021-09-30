using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblPerson
    {
        public TblPerson()
        {
            TblCountry = new HashSet<TblCountry>();
            TblIncomeDetail = new HashSet<TblIncomeDetail>();
            TblPersonDetail = new HashSet<TblPersonDetail>();
            TblPersonName = new HashSet<TblPersonName>();
            TblPersonReferalLink = new HashSet<TblPersonReferalLink>();
            TblPersonRegistration = new HashSet<TblPersonRegistration>();
        }

        public int PersonId { get; set; }
        public bool? DeathIndicator { get; set; }
        public int? BloodTypeCodeId { get; set; }
        public int? GenderCodeId { get; set; }
        public int? EthnicityId { get; set; }
        public bool? MissingIndicator { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? CrossMonthlyIncomeId { get; set; }

        public virtual TblLtBloodTypeCodeList BloodTypeCode { get; set; }
        public virtual TblLtGrossMonthlyIncomeCodeList CrossMonthlyIncome { get; set; }
        public virtual TblLtEthnicityCodeList Ethnicity { get; set; }
        public virtual TblLtGenderCodeList GenderCode { get; set; }
        public virtual TblLtMaritalStatusCodeList MaritalStatus { get; set; }
        public virtual ICollection<TblCountry> TblCountry { get; set; }
        public virtual ICollection<TblIncomeDetail> TblIncomeDetail { get; set; }
        public virtual ICollection<TblPersonDetail> TblPersonDetail { get; set; }
        public virtual ICollection<TblPersonName> TblPersonName { get; set; }
        public virtual ICollection<TblPersonReferalLink> TblPersonReferalLink { get; set; }
        public virtual ICollection<TblPersonRegistration> TblPersonRegistration { get; set; }
    }
}
