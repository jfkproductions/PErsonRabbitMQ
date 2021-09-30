

using ContactAndPlaceDAL.Models;
using Party_Dll.Models;
using System.Collections.Generic;

public class LookupTables
{
    public List<TelephoneTypeCodeList> TelephoneTypeCodeList { get; set; }
    public List<TelephoneNetworkTypeCodeList> TelephoneNetworkTypeCodeList { get; set; }

}

public class TelephoneNetworkTypeCodeList
{
    public int TelephoneNetworkTypeCodeID { get; set; }
    public string TelephoneNetworkTypeCode { get; set; }
    public string TelephoneNetworkTypeCodeDesc { get; set; }
}
public class TelephoneTypeCodeList
{
    public int TelephoneTypeCodeListID { get; set; }
    public string TelephoneTypeCode { get; set; }
    public string TelephoneTypeCodeDesc { get; set; }

}

public class RootRoleObject
{
    public List<RolePersonPartyContactDetails> rolePersonPartyContactDetails { get; set; }

}
public class PersonContactDetails
{
    public TblPerson Person { get; set; }
    public List<RolePersonPartyContactDetails> RolePersonPartyContactDetails { get; set; }
}
public class RolePersonPartyContactDetails
{
    public Emailcontact emailContact { get; set; }
    public TelephoneNumber[] telephoneNumberList { get; set; }
    public Postaladdress PostalAddress { get; set; }
    public Streetaddress StreetAddress { get; set; }
    public int PersonPartyContactRoleId { get; set; }
    public int PersonId { get; set; }
    public int? PartyId { get; set; }
    public long? PkemailContactId { get; set; }
    public int? PostalAddressId { get; set; }
    public long? PktelephoneNumberId { get; set; }
    public int? StreetAddressId { get; set; }
}

public class Emailcontact
{
    public string EmailAddress { get; set; }
    public long PkemailContactId { get; set; }
}

public class TelephoneNumber
{
    public string AreaCode { get; set; }
    public string CountryCode { get; set; }
    public string TrunkPrefix { get; set; }
    public string Extension { get; set; }
    public string FullNumber { get; set; }
    public long PktelephoneNumberId { get; set; }
    public int? TelephoneTypeCodeListId { get; set; }
    public int? TelephoneNetworkTypeCodeId { get; set; }

    public bool isPrimary;
}

public class Postaladdress
{
    public int PostalAddressId { get; set; }
    public string AddressLines { get; set; }
    public string BoxNumber { get; set; }
    public string BuildingName { get; set; }
    public string FloorNumber { get; set; }
    public string PostDirectionCode { get; set; }
    public string PreDirectionCode { get; set; }

    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string UnitNumber { get; set; }
    public string CarrierRoute { get; set; }

    public string StreetTypeCode { get; set; }
    public byte[] PostalBarCode { get; set; }
}

public class Streetaddress
{
    public int StreetAddressId { get; set; }
    public string Name { get; set; }
    public string Number { get; set; }
    public string PostDirectionCode { get; set; }
    public string PreDirectionCode { get; set; }
    public string TypeCode { get; set; }
}
