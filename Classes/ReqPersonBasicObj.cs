using System;
using System.Collections.Generic;
using System.Text;

namespace FnPerson.Classes
{

    public class PartyRoleInProduct
    {
        public int PartyRoleinProductId { get; set; }
        public int ProductSpecificationId { get; set; }
        public int PartyRoleInProductTypeCodeId { get; set; }
        public int PartyId { get; set; }
    }

    public class ReqPersonBasicObj
    {

        public int PersonId { get; set; }

        public Persondetail PersonDetail { get; set; }
        public Personname PersonName { get; set; }
        public Identitycard Identitycard { get; set; }

        public BirthCertificate BirthCertificate { get; set; }
        public bool DeathIndicator { get; set; }
        public int BloodTypeCodeId { get; set; }
        public int GenderCodeId { get; set; }
        public int EthnicityId { get; set; }
        public bool MissingIndicator { get; set; }
        public int MaritalStatusId { get; set; }

        public int PersonRegistrationTypeCodeId { get; set; }

        public int? CrossMonthlyIncomeID { get; set; }
        public List<PartyRoleInProduct> PartyRoleInProduct { get; set; }
        //public string ClientReferral { get; set; }
        public HouseholdRelationship[] householdRelationship { get; set; }
        public PersonReferalLink[] PersonReferalLink { get; set; }
        //public string Scheme { get; set; }

    }
}
