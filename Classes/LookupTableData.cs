
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Party_Dll.Models;
namespace FnPerson.Classes
{
    public class LookupTableData
    {

        public static List<TblLtBloodTypeCodeList> BuildBloodtypeLookup(PartyContext _context)
        {
            List<TblLtBloodTypeCodeList> BloodtypeLookup = new List<TblLtBloodTypeCodeList>();
            foreach (var bloodtype in _context.TblLtBloodTypeCodeList.ToArray())
            {
                BloodtypeLookup.Add(new TblLtBloodTypeCodeList
                {
                    BloodTypeCode = bloodtype.BloodTypeCode,
                    BloodTypeCodeDesc = bloodtype.BloodTypeCodeDesc,
                    BloodTypeCodeId = bloodtype.BloodTypeCodeId
                }
               );
            }
            return BloodtypeLookup;
        }


        public static List<TblLtGenderCodeList> BuildGenderLookup(PartyContext _context)
        {
            List<TblLtGenderCodeList> GenderCodeLookup = new List<TblLtGenderCodeList>();
            foreach (var Gender in _context.TblLtGenderCodeList.ToArray())
            {
                GenderCodeLookup.Add(new TblLtGenderCodeList
                {
                    GenderCode = Gender.GenderCode,
                    GenderCodeDesc = Gender.GenderCodeDesc,
                    GenderCodeId = Gender.GenderCodeId
                }
               );
            }
            return GenderCodeLookup;
        }

        internal PersonLookups GetPersonLookups(PartyContext _context)
        {
            try
            {
                return new PersonLookups
                {
                    BloodType = BuildBloodtypeLookup(_context),
                    Entnicity = BuildEntnicityLookup(_context),
                    GenderCode = BuildGenderLookup(_context),
                    MaritalStatusCode = BuildMaritalStatusCodeLookup(_context),
                    Nationality = BuildNationalityLookup(_context),
                    PersonnameUsage = BuildPersonNameUsageCodeLookup(_context),
                    PersonRegistrationTypeCode = BuildtPersonRegistrationTypeCodeLookup(_context),
                    TitleCode = BuildTitleCodeListLookup(_context),
                    //ValidityCode = BuildValidityCodeLookup(_context),
                    CrossMontlyIncome = BuildCrossMonthyLookup(_context),
                    ReferalCode = BuildReferalLookup(_context),
                    CountryCodeList = CountryCodeList(_context),
                    HomeOwnershipCodeList = HomeOwnershipCodeList(_context),
                    PersonDetailCodeList = getPersonDetailCodeList(_context),
                    PartyRoleInRelationShipTypeCodeList= GetPartyRoleInRelationShipTypeCodeList(_context)
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static List<TblLtPartyRoleInRelationShipTypeCodeList> GetPartyRoleInRelationShipTypeCodeList(PartyContext _context)
        {
            List<TblLtPartyRoleInRelationShipTypeCodeList> Lookup = new List<TblLtPartyRoleInRelationShipTypeCodeList>();
            foreach (var obj in _context.TblLtPartyRoleInRelationShipTypeCodeList.ToArray())
            {
                Lookup.Add(new TblLtPartyRoleInRelationShipTypeCodeList
                {
                    PartyRoleinRelationShipTypeCodeId = obj.PartyRoleinRelationShipTypeCodeId,
                    RelationshipDescriptionCode = obj.RelationshipDescriptionCode,
                    RelationshipDescriptionCodeDesc = obj.RelationshipDescriptionCodeDesc
                }
              );
            }
            return Lookup;
        }
        public static List<TblLtPersonDetailTypeCodeList> getPersonDetailCodeList(PartyContext _context)
        {
            List<TblLtPersonDetailTypeCodeList> Lookup = new List<TblLtPersonDetailTypeCodeList>();
            foreach (var obj in _context.TblLtPersonDetailTypeCodeList.ToArray())
            {
                Lookup.Add(new TblLtPersonDetailTypeCodeList
                {
                    PersonDetailCode = obj.PersonDetailCode,
                    PersonDetailCodeDesc = obj.PersonDetailCodeDesc,
                    PersonDetailCodeId = obj.PersonDetailCodeId
                }
              );
            }
            return Lookup;
        }

        public static List<TblLtReferalCodeList> BuildReferalLookup(PartyContext _context)
        {
            List<TblLtReferalCodeList> Lookup = new List<TblLtReferalCodeList>();
            foreach (var obj in _context.TblLtReferalCodeList.ToArray())
            {
                Lookup.Add(new TblLtReferalCodeList
                {
                    ReferalCode = obj.ReferalCode,
                    ReferalDesc = obj.ReferalDesc,
                    ReferalId = obj.ReferalId
                }
              );
            }
            return Lookup;
        }

        public static List<TblLtGrossMonthlyIncomeCodeList> BuildCrossMonthyLookup(PartyContext _context)
        {
            List<TblLtGrossMonthlyIncomeCodeList> Lookup = new List<TblLtGrossMonthlyIncomeCodeList>();
            foreach (var obj in _context.TblLtGrossMonthlyIncomeCodeList.ToArray())
            {
                Lookup.Add(new TblLtGrossMonthlyIncomeCodeList
                {
                    CrossMonthlyIncomeCode = obj.CrossMonthlyIncomeCode,
                    CrossMonthlyIncomeCodeDesc = obj.CrossMonthlyIncomeCodeDesc,
                    CrossMonthlyIncomeId = obj.CrossMonthlyIncomeId
                }
              );
            }
            return Lookup;
        }

        internal static List<TblLtHomeOwnershipCodeList> HomeOwnershipCodeList(PartyContext _context)
        {
            List<TblLtHomeOwnershipCodeList> Lookup = new List<TblLtHomeOwnershipCodeList>();
            foreach (var obj in _context.TblLtHomeOwnershipCodeList.ToArray())
            {
                Lookup.Add(new TblLtHomeOwnershipCodeList
                {
                    HomeOwnerShipCode = obj.HomeOwnerShipCode,
                    HomeOwnerShipCodeDesc = obj.HomeOwnerShipCodeDesc,
                    HomeOwnerShipCodeId = obj.HomeOwnerShipCodeId
                });
            }
            return Lookup;
        }

        internal static List<TblLtCountryCodeList> CountryCodeList(PartyContext _context)
        {
            List<TblLtCountryCodeList> CountryLookup = new List<TblLtCountryCodeList>();
            foreach (var obj in _context.TblLtCountryCodeList.ToArray())
            {
                CountryLookup.Add(new TblLtCountryCodeList
                {
                    CountryCode = obj.CountryCode,
                    CountryCodeId = obj.CountryCodeId,
                    CountryDesc = obj.CountryDesc
                });
            }
            return CountryLookup;
        }

        public static List<TblLtEthnicityCodeList> BuildEntnicityLookup(PartyContext _context)
        {
            List<TblLtEthnicityCodeList> EntnicityLookup = new List<TblLtEthnicityCodeList>();
            foreach (var obj in _context.TblLtEthnicityCodeList.ToArray())
            {
                EntnicityLookup.Add(new TblLtEthnicityCodeList
                {
                    EthnicityCode = obj.EthnicityCode,
                    EthnicityCodeDesc = obj.EthnicityCodeDesc,
                    EthnicityId = obj.EthnicityId
                }
               );
            }
            return EntnicityLookup;
        }

        public static List<TblLtMaritalStatusCodeList> BuildMaritalStatusCodeLookup(PartyContext _context)
        {
            List<TblLtMaritalStatusCodeList> Lookup = new List<TblLtMaritalStatusCodeList>();
            foreach (var obj in _context.TblLtMaritalStatusCodeList.ToArray())
            {
                Lookup.Add(new TblLtMaritalStatusCodeList
                {
                    MaritalStatusCode = obj.MaritalStatusCode,
                    MaritalStatusCodeDesc = obj.MaritalStatusCodeDesc,
                    MaritalStatusId = obj.MaritalStatusId
                }
               );
            }
            return Lookup;
        }

        public static List<TblLtNationality> BuildNationalityLookup(PartyContext _context)
        {
            List<TblLtNationality> Lookup = new List<TblLtNationality>();
            foreach (var obj in _context.TblLtNationality.ToArray())
            {
                Lookup.Add(new TblLtNationality
                {
                    NationalityCode = obj.NationalityCode,
                    NationalityDesc = obj.NationalityDesc,
                    NationalityId = obj.NationalityId
                }
               );
            }
            return Lookup;
        }

        public static List<TblLtPrefixTitleCodeList> BuildTitleCodeListLookup(PartyContext _context)
        {
            List<TblLtPrefixTitleCodeList> Lookup = new List<TblLtPrefixTitleCodeList>();
            foreach (var obj in _context.TblLtPrefixTitleCodeList.ToArray())
            {
                Lookup.Add(new TblLtPrefixTitleCodeList
                {
                    PrefixTitleCode = obj.PrefixTitleCode,
                    PrefixTitleCodeDesc = obj.PrefixTitleCodeDesc,
                    PrefixTitleCodeId = obj.PrefixTitleCodeId
                }
               );
            }
            return Lookup;
        }

        public static List<TblLtPersonNameUsageCodeList> BuildPersonNameUsageCodeLookup(PartyContext _context)
        {
            List<TblLtPersonNameUsageCodeList> Lookup = new List<TblLtPersonNameUsageCodeList>();
            foreach (var obj in _context.TblLtPersonNameUsageCodeList.ToArray())
            {
                Lookup.Add(new TblLtPersonNameUsageCodeList
                {
                    PersonNameUsageCode = obj.PersonNameUsageCode,
                    PersonNameUsageCodeDesc = obj.PersonNameUsageCodeDesc,
                    PersonNameUsageCodeId = obj.PersonNameUsageCodeId
                }
               );
            }
            return Lookup;
        }
        public static List<TblLtPersonRegistrationTypeCodeList> BuildtPersonRegistrationTypeCodeLookup(PartyContext _context)
        {
            List<TblLtPersonRegistrationTypeCodeList> Lookup = new List<TblLtPersonRegistrationTypeCodeList>();
            foreach (var obj in _context.TblLtPersonRegistrationTypeCodeList.ToArray())
            {
                Lookup.Add(new TblLtPersonRegistrationTypeCodeList
                {
                    PersonRegistrationTypeCode = obj.PersonRegistrationTypeCode,
                    PersonRegistrationTypeCodeDesc = obj.PersonRegistrationTypeCodeDesc,
                    PersonRegistrationTypeCodeId = obj.PersonRegistrationTypeCodeId
                }
               );
            }
            return Lookup;
        }

        //public static List<TblLtValidityCodeList> BuildValidityCodeLookup(PartyContext _context)
        //{
        //    List<TblLtValidityCodeList> Lookup = new List<TblLtValidityCodeList>();
        //    foreach (var obj in _context.TblLtValidityCodeList.ToArray())
        //    {
        //        Lookup.Add(new TblLtValidityCodeList
        //        {
        //            ValidityCodeId = obj.ValidityCodeId,
        //            ValidityCode = obj.ValidityCode,
        //            ValidityCodedesc = obj.ValidityCodedesc
        //        }
        //       );
        //    }
        //    return Lookup;
        //}

    }
}
