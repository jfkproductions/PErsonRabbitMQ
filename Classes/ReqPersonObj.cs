
using Party_Dll.Models;
using System;
using System.Collections.Generic;

public class PersonLookups
{
    public List<TblLtBloodTypeCodeList> BloodType { get; set; }
    public List<TblLtGenderCodeList> GenderCode { get; set; }

    public List<TblLtEthnicityCodeList> Entnicity { get; set; }

    public List<TblLtMaritalStatusCodeList> MaritalStatusCode { get; set; }
    public List<TblLtNationality> Nationality { get; set; }

    public List<TblLtPrefixTitleCodeList> TitleCode { get; set; }

    public List<TblLtPersonNameUsageCodeList> PersonnameUsage { get; set; }

    public List<TblLtPersonRegistrationTypeCodeList> PersonRegistrationTypeCode { get; set; }
    //public List<TblLtValidityCodeList> ValidityCode { get; set; }

    public List<TblLtReferalCodeList> ReferalCode { get; set; }
    public List<TblLtGrossMonthlyIncomeCodeList> CrossMontlyIncome { get; set; }

    public List<RelationshipDescriptionCodeList> RelationshipDescription { get; set; }
    public List<TblLtCountryCodeList> CountryCodeList { get; set; }

    public List<TblLtHomeOwnershipCodeList> HomeOwnershipCodeList { get; set; }

    public List<TblLtPersonDetailTypeCodeList> PersonDetailCodeList { get; set; }

    public List<TblLtPartyRoleInRelationShipTypeCodeList> PartyRoleInRelationShipTypeCodeList { get; set; }


}
public class PersonArrayObject
{    //new code 2020-10-13 name change 
    public List<PersonRootobject> PersonalDetail { get; set; }
    public List<int> Relationships { get; set; }

}

public class HouseholdRelationship
{
    public int? PartyRoleRelationshipID { get; set; }
    public int HomeOwnerShipCodeID { get; set; }

    public double DependentAdultCount { get; set; }
    public double DependentChildCount { get; set; }
    public bool Family { get; set; }
    public string Name { get; set; }
    public int? CrossMonthlyIncomeID { get; set; }


}




public class PartyRoleInAgreementArrayObject
{
    public List<PartyRoleInAgreementRootObject> PartyRoleInAgreementDetail { get; set; }
}
public class PersonRootobject
{
    public Persondetail PersonDetail { get; set; }
    public Personname PersonName { get; set; }
    public Personregistration[] PersonRegistration { get; set; }
    public PersonReferalLink[] PersonReferalLink { get; set; }
    public CountryLink[] CountryLink { get; set; }
    public HouseholdRelationship[] householdRelationship { get; set; }

    public int? PersonId { get; set; }
    public bool? DeathIndicator { get; set; }
    public int? BloodTypeCodeId { get; set; }
    public int? GenderCodeId { get; set; }
    public int? EthnicityId { get; set; }
    public bool? MissingIndicator { get; set; }
    public int? MaritalStatusId { get; set; }

    public int? CrossMonthlyIncomeID { get; set; }

    public bool? PrincipleMember { get; set; }
    public int? RelationshipDescriptionCodeID { get; set; }

}

public class AgreementList
{
    public Agreement[] AgreementDetail { get; set; }
}
public class Agreement
{
    public int AgreementID { get; set; }

    public string Name { get; set; }

    public string Version { get; set; }

    public int StatusCodeListID { get; set; }

    public int StatusReasonCodeListID { get; set; }

    public int TextQualificationCodeListID { get; set; }

    public int AgreementKindCodeListID { get; set; }

}

public class PartyRoleInAgreementRootObject
{
    public int PartyRoleInAgreementId { get; set; }
    public int AgreementId { get; set; }
    public int PartyRoleinAgreementTypeCodeId { get; set; }
    public int PartyId { get; set; }
}

public class RelationshipDescriptionCodeList
{
    public int RelationshipDescriptionCodeID { get; set; }
    public string RelationshipDescriptionCode { get; set; }
    public string RelationshipDescriptionCodeDesc { get; set; }
}
public class PersonReferalLink
{

    public int PersonReferalLinkID { get; set; }

    public int PersonID { get; set; }
    public int ReferalID { get; set; }

}
public class BirthCertificate
{
    public int BirthCertificateID { get; set; }
    public int PersonRegistrationID { get; set; }
    public DateTime BirthDate { get; set; }
}

public class Persondetail
{
    public int PersonDetaiId { get; set; }
    public int PartyId { get; set; }
    public int PersonId { get; set; }
    public int PersonDetailCodeId { get; set; }

    public int? PartyRoleRelationshipID { get; set; }

}
public class CountryLink
{
    public long? CountryID { get; set; }
    public int? CountryCodeID { get; set; }
    public string Capital { get; set; }
    public int? PersonId { get; set; }
    public int? NationalityId { get; set; }
    public int? FundAssetID { get; set; }

}
public class Personname
{
    public int? PersonaNameId { get; set; }
    public int? PersonId { get; set; }
    public int? PrefixTitleCodeId { get; set; }
    public string GivenName { get; set; }
    public string MiddleName { get; set; }
    public string Surname { get; set; }
    public string Suffix { get; set; }
    public int? PersonNameUsageCodeId { get; set; }
    public string PreferredName { get; set; }
    public string Initials { get; set; }


}

public class Personregistration
{
    public Civilregistration[] CivilRegistration { get; set; }
    public Educationcertificate[] EducationCertificate { get; set; }

    public Personalactivitylicence[] PersonalActivityLicence { get; set; }
    public Residentregistration[] ResidentRegistration { get; set; }
    public Identitycard[] Identitycard { get; set; }

    public BirthCertificate BirthCertificate { get; set; }

    public int PersonRegistrationId { get; set; }
    public int PersonId { get; set; }
    public int? PersonRegistrationTypeCodeId { get; set; }
}

public class Civilregistration
{
    //  public object[] TblDeathCertificate { get; set; }
    public Identitycard[] identityCard { get; set; }
    public int CivilRefistrationId { get; set; }
    public int PersonRegistrationId { get; set; }
    public DateTime RegistrationDate { get; set; }
}

public class Identitycard
{
    public Validitycode ValidityCode { get; set; }
    public int IdentityCard { get; set; }
    public int PersonRegistrationId { get; set; }
    public int ValidityCodeId { get; set; }
    public string IdentityNumber { get; set; }
}

public class Validitycode
{
    public PassportOBj[] Passport { get; set; }
}

public class PassportOBj
{
    public int PassportId { get; set; }
    public int ValidityCodeId { get; set; }
}

public class Educationcertificate
{
    public int EducationCertificateId { get; set; }
    public int PersonRegistrationId { get; set; }
    public int SubjectAreaCodeId { get; set; }
    public int EducationCertificateCodeId { get; set; }
    public int EducationGradeCodeId { get; set; }
    public string Name { get; set; }
    public int EducationCertificateTitleCodeId { get; set; }
}

public class Personalactivitylicence
{
    public int PersonalActivityLicenceId { get; set; }
    public bool CompetitionLicenseIndicator { get; set; }
    public string Name { get; set; }
    public bool RenewalIntentionIndicator { get; set; }
    public int PersonRegistrationId { get; set; }
}

public class Residentregistration
{
    public int ResidentRegistrationId { get; set; }
    public int PersonRegistrationId { get; set; }
}
public class PersonNameEmail
{
    public string GivenName { get; set; }
    public string MiddleName { get; set; }
    public int PersonId { get; set; }
    public string Email { get; set; }
}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
public class PersonIDList
{
    public List<int> PersonIds { get; set; }
}


