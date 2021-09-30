using System;
using System.Collections.Generic;
using System.Text;

public class PrincipleMemberDetails
{
    public int PartyId { get; set; }
    public int PersonId { get; set; }
    public int? AgreementId { get; set; }
    public int AgreementKindCodeId { get; set; }
    public string NationalityCode { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long EmailId { get; set; }
    public string Emailaddress { get; set; }
    public string FullName { get; set; }
    public string GenderCode { get; set; }
    public string IdNumber { get; set; }
    public string IdTypeCode { get; set; }
    public string Initials { get; set; }
    public string LeadSourceCode { get; set; }
    public string PreferedName { get; set; }
    public string Surname { get; set; }
    public List<Telephone> TelephoneLists { get; set; }
    public string TitleCode { get; set; }
}

public class ContactPersonDetails
{
    public int PartyId { get; set; }
    public int PersonId { get; set; }
    public int AgreementId { get; set; }
    public string NationalityCode { get; set; }
    public DateTime DateOfBirth { get; set; }
    public long EmailId { get; set; }
    public string Emailaddress { get; set; }
    public string FullName { get; set; }
    public string GenderCode { get; set; }
    public string IdNumber { get; set; }
    public string IdTypeCode { get; set; }
    public string Initials { get; set; }
    public string LeadSourceCode { get; set; }
    public string PreferedName { get; set; }
    public string Surname { get; set; }
    public List<Telephone> TelephoneLists { get; set; }
    public string TitleCode { get; set; }
    public string PartyRoleinRelationShipTypeCode { get; set; }
    public int PrincipleMemberPersonId { get; set; }
}

public class Telephone
{
    public long TelephoneNumberId { get; set; }
    public string TelephoneTypeCodeListCode { get; set; }
    public string Number { get; set; }
    public bool PreferedNumber { get; set; }
}

public class PostPrincipleMemberResponse 
{
    public PrincipleMemberDetails principleMemberDetails { get; set; }
    public List<string> ErrorList { get; set; }
}

public class ContactPersonResponse
{
    public ContactPersonDetails contactPersonDetails { get; set; }
    public List<string> ErrorList { get; set; }
}

