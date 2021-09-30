using Party_Dll.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using RoleAndRelationship_Dal.Models;

namespace FnPerson.Classes
{



    public class FormatObjectDetails
    {
        private readonly RoleAndRelationshipContext _roleAndRelationshipContext;
        private readonly PartyContext _context;

        public FormatObjectDetails(PartyContext context,RoleAndRelationshipContext roleAndRelationshipContext)
        {
            _roleAndRelationshipContext = roleAndRelationshipContext;
            _context = context;
        }
        #region "Conversion Functions"
        public static List<PersonRootobject> ConvertToPersonInformation(List<TblPerson> Persons, PartyContext _context =null, RoleAndRelationshipContext _roleAndRelationshipContext = null)
        {
            //new code 2020-10-13
            var Partyid = (Persons.First().TblPersonDetail.Count > 0 ) ? Persons.First().TblPersonDetail.First().PartyId : 0;
            var PersoninAgreement = _context.TblPartyRoleInAgreement.Where(cl => cl.PartyId == Partyid);
            var PartyRoleIds = _roleAndRelationshipContext.TblPartyRole.Where(x => x.PartyId == Partyid)?.Select(x=>x.PartyRoleId)?.ToList();
            var PersonRelationshipID = _context.TblPartyRoleInRelationship.Where(p => PartyRoleIds.Contains(p.PartyRoleId));
 
            return Persons.Select(person =>
            {
                return new PersonRootobject
                {

                    BloodTypeCodeId = person.BloodTypeCodeId,
                    DeathIndicator = person.DeathIndicator,
                    EthnicityId = person.EthnicityId,
                    GenderCodeId = person.GenderCodeId,
                    MaritalStatusId = person.MaritalStatusId,
                    MissingIndicator = person.MissingIndicator,
                    PersonId = person.PersonId,
                    // format  correct 
                   // PersonRegistration = GetPersonResgitration(person.TblPersonRegistration),
                    PersonName = GetPersonName(person.TblPersonName),
                    PersonDetail = GetPersonDetail(person.TblPersonDetail),
                    CrossMonthlyIncomeID = person?.CrossMonthlyIncomeId,
                    PersonReferalLink = GetPersonReferalLink(person.TblPersonReferalLink),
                    CountryLink = GetPersonCountryLink(person.TblCountry),
                    householdRelationship = GetHousholdRelationship(person.TblPersonDetail, _context),
                    PrincipleMember = PersoninAgreement.Any(),
                    RelationshipDescriptionCodeID = PersonRelationshipID.FirstOrDefault()?.PartyRoleInRelationshipTypeCodeId ?? -1
                };
            }).ToList();
        }
        public static List<ReqPersonBasicObj> ConvertPerson_BasicPerson(PersonArrayObject personArrayObject)
        {
            List<ReqPersonBasicObj> basicPersons = new List<ReqPersonBasicObj>();

            foreach (PersonRootobject personRootObject in personArrayObject.PersonalDetail)
            {
                ReqPersonBasicObj basicPerson = new ReqPersonBasicObj
                {
                    PersonId = personRootObject.PersonId.Value,
                    PersonName = personRootObject.PersonName,
                    householdRelationship = personRootObject.householdRelationship,
                    GenderCodeId = personRootObject.GenderCodeId.Value, //GenderCodeId //3.
                    BirthCertificate = personRootObject.PersonRegistration[0].BirthCertificate,
                    Identitycard = personRootObject.PersonRegistration[0].Identitycard[0],
                    PersonDetail = personRootObject.PersonDetail,  // 1.
                    DeathIndicator = personRootObject.DeathIndicator.Value, // 6. DeathIndicator
                    BloodTypeCodeId = personRootObject.BloodTypeCodeId.Value, // 6. BloodTypeCodeId
                    EthnicityId = personRootObject.EthnicityId.Value, // 6. EthnicityId
                    MissingIndicator = personRootObject.MissingIndicator.Value, // 6. MissingIndicator
                    MaritalStatusId = personRootObject.MaritalStatusId.Value, // 6. MaritalStatusId
                    CrossMonthlyIncomeID = personRootObject.CrossMonthlyIncomeID, // 6. CrossMonthlyIncomeID
                    PersonReferalLink = personRootObject.PersonReferalLink
                };

                basicPersons.Add(basicPerson);
            }

            return basicPersons;
        }

        //public static PartyRoleInProduct Convert_TblPartyRoleInProduct_PartyRoleInProduct(Party_Dll.Models.TblPartyRoleInProduct tblPartyRoleInProduct)
        //{
        //    PartyRoleInProduct partyRoleInProduct = new PartyRoleInProduct
        //    {
        //        PartyId = (int)tblPartyRoleInProduct.PartyId,
        //        ProductSpecificationId = tblPartyRoleInProduct.ProductSpecificationId,
        //        PartyRoleinProductId = tblPartyRoleInProduct.PartyRoleinProductId,
        //        PartyRoleInProductTypeCodeId = tblPartyRoleInProduct.PartyRoleInProductTypeCodeId
        //    };

        //    return partyRoleInProduct;
        //}

        public static PersonRootobject ConvertBasicPerson_Person(ReqPersonBasicObj basicPerson)
        {
            PersonRootobject personRootObject = new PersonRootobject
            {
                PersonName = basicPerson.PersonName,  // 1.
                PersonDetail = basicPerson.PersonDetail,  // 1.
                householdRelationship = basicPerson.householdRelationship, //2.
                GenderCodeId = basicPerson.GenderCodeId //GenderCodeId //3.
            };


            Personregistration personregistration = new Personregistration
            {
                BirthCertificate = basicPerson.BirthCertificate,// Date-Of-Birth //4.
                PersonRegistrationTypeCodeId = basicPerson.PersonRegistrationTypeCodeId
            };

            var identitycards = new List<Identitycard>
            {
                basicPerson.Identitycard // 5. Identity Card
            };
            personregistration.Identitycard = identitycards.ToArray();

            List<Personregistration> personregistrations = new List<Personregistration>
            {
                personregistration
            };

            personRootObject.PersonRegistration = personregistrations.ToArray();
            personRootObject.PersonId = basicPerson.PersonId; // 6. PersonId
            personRootObject.DeathIndicator = basicPerson.DeathIndicator; // 6. DeathIndicator
            personRootObject.BloodTypeCodeId = basicPerson.BloodTypeCodeId; // 6. BloodTypeCodeId
            personRootObject.EthnicityId = basicPerson.EthnicityId; // 6. EthnicityId
            personRootObject.MissingIndicator = basicPerson.MissingIndicator; // 6. MissingIndicator
            personRootObject.MaritalStatusId = basicPerson.MaritalStatusId; // 6. MaritalStatusId
            personRootObject.CrossMonthlyIncomeID = basicPerson.CrossMonthlyIncomeID; // 6. CrossMonthlyIncomeID
            personRootObject.PersonReferalLink = basicPerson.PersonReferalLink;

            return personRootObject;
        }

       
        private static HouseholdRelationship[] GetHousholdRelationship(ICollection<TblPersonDetail> tblPersonDetail, PartyContext _context)
        {

            var List = new List<HouseholdRelationship>();
            if (tblPersonDetail.Count() > 0)
            {
                var Houshould = _context.TblHouseholdRelationship.Where(cl => cl.PartyRoleRelationshipId == tblPersonDetail.First().PartyRoleRelationshipId);
                try
                {
                    foreach (var owner in Houshould)
                    {
                        var ownerobj = new HouseholdRelationship
                        {
                            CrossMonthlyIncomeID = owner?.CrossMonthlyIncomeId,
                            DependentAdultCount = owner.DependentAdultCount,
                            DependentChildCount = owner.DependantChildCount,
                            Family = owner.Family,
                            HomeOwnerShipCodeID = owner.HomeOwnerShipCodeId,
                            Name = owner.Name,
                            PartyRoleRelationshipID = owner.PartyRoleRelationshipId


                        };
                        List.Add(ownerobj);
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return List.ToArray();
        }

        private static CountryLink[] GetPersonCountryLink(ICollection<TblCountry> tblCountry)
        {
            var List = new List<CountryLink>();
            try
            {
                foreach (var owner in tblCountry)
                {
                    var ownerobj = new CountryLink
                    {
                        Capital = owner.Capital,
                        CountryCodeID = owner.CountryCodeId,
                        CountryID = owner.CountryId,
                        FundAssetID = owner.FundAssetId,
                        NationalityId = owner.NationalityId,
                        PersonId = owner.PersonId

                    };
                    List.Add(ownerobj);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return List.ToArray();
        }
        public static List<VirtualParty> ConvertTblVirtualPartyToVirtualparty(List<TblVirtualParty> TblVirtualParty, PartyContext _context = null)
        {
            ////new code 2020-10-13
            //var Partyid = (Persons.First().TblPersonDetail.Count > 0) ? Persons.First().TblPersonDetail.First().PartyId : 0;
            //var PersoninAgreement = _context.TblPartyRoleInAgreement.Where(cl => cl.PartyId == Partyid);
            //var PersonRelationshipID = _context.TblPartyRoleinRelationShip.Where(p => p.PartyId == Partyid);

            return TblVirtualParty.Select(virtualParty =>
            {

                return new VirtualParty
                {

                    VirtualPartyId = virtualParty.VirtualPartyId,
                    Description = virtualParty.Description
                };
            }).ToList();
        }
        private static PersonReferalLink[] GetPersonReferalLink(ICollection<TblPersonReferalLink> tblPersonReferalLink)
        {
            var List = new List<PersonReferalLink>();
            try
            {
                foreach (var owner in tblPersonReferalLink)
                {
                    var ownerobj = new PersonReferalLink
                    {
                        PersonID = owner.PersonId,
                        ReferalID = owner.ReferalId,
                        PersonReferalLinkID = owner.PersonReferalLinkId

                    };
                    List.Add(ownerobj);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return List.ToArray();
        }

        internal static List<int> GetRelationships(List<TblPerson> persons, PartyContext _context)
        {
            //new code 2020-10-13
            var PartyRoleRelationshipId = (persons.First().TblPersonDetail.Count > 0) ? persons.First().TblPersonDetail.First().PartyRoleRelationshipId :0;
            var RelationshipList = _context.TblPersonDetail.Where(ct => ct.PartyRoleRelationshipId == PartyRoleRelationshipId 
                                                                 && ct.PersonId != persons.First().PersonId);
            var PersonList = new List<int>();
            foreach (var item in RelationshipList)
            {
                PersonList.Add(item.PersonId);
            }
            return PersonList;
        }

        private static Persondetail GetPersonDetail(ICollection<TblPersonDetail> tblLtPersonDetail)
        {
            Persondetail ownerobj = null;
            try
            {
                if (tblLtPersonDetail.Count > 0)
                {
                    ownerobj = new Persondetail
                    {

                        PartyId = tblLtPersonDetail.First().PartyId,
                        PersonDetaiId = tblLtPersonDetail.First().PersonDetaiId,
                        PersonDetailCodeId = tblLtPersonDetail.First().PersonDetailCodeId,
                        PersonId = tblLtPersonDetail.First().PersonId,
                        PartyRoleRelationshipID = tblLtPersonDetail.First().PartyRoleRelationshipId

                    };
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return ownerobj;
        }

        private static BirthCertificate GetPersonBirth(ICollection<TblBirthCertificate> tblLtPersonDetail)
        {
            BirthCertificate ownerobj = null;
            try
            {
                if (tblLtPersonDetail.Count > 0)
                {
                    ownerobj = new BirthCertificate
                    {
                        BirthCertificateID = tblLtPersonDetail.First().BirthCertificateId,
                        BirthDate = tblLtPersonDetail.First().BirthDate,
                        PersonRegistrationID = tblLtPersonDetail.First().BirthCertificateId

                    };
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return ownerobj;
        }

        private static Personname GetPersonName(ICollection<TblPersonName> tblPersonName)
        {
            Personname ownerobj = null;
            try
            {
                if (tblPersonName.Count > 0)
                {
                    ownerobj = new Personname
                    {
                        GivenName = tblPersonName.First().GivenName,
                        MiddleName = tblPersonName.First().MiddleName,
                        PersonaNameId = tblPersonName.First().PersonaNameId,
                        PersonId = tblPersonName.First().PersonId,
                        PersonNameUsageCodeId = tblPersonName.First().PersonNameUsageCodeId,
                        PrefixTitleCodeId = tblPersonName.First().PrefixTitleCodeId,
                        Suffix = tblPersonName.First().Suffix,
                        Surname = tblPersonName.First().Surname,
                        Initials = tblPersonName.First().Initials,
                        PreferredName = tblPersonName.First().PreferredName


                    };
                }


            }
            catch (Exception ex)
            {

                throw;
            }
            return ownerobj;
        }

        //private static Personregistration[] GetPersonResgitration(ICollection<TblPersonRegistration> tblPersonRegistration)
        //{
        //    var List = new List<Personregistration>();
        //    try
        //    {
        //        foreach (var owner in tblPersonRegistration)
        //        {

        //            var ownerobj = new Personregistration
        //            {
        //                PersonId = owner.PersonId,
        //                EducationCertificate = GetEducationCertificate(owner.TblEducationCertificate),
        //                //  MilitaryRegistration = GetMilitaryREgistration(owner.TblMilitaryRegistration),
        //                PersonalActivityLicence = GetActivityLicence(owner.TblPersonalActivityLicence),
        //                PersonRegistrationId = owner.PersonRegistrationId,
        //                PersonRegistrationTypeCodeId = owner.PersonRegistrationTypeCodeId,
        //                ResidentRegistration = GetResidentRegistration(owner.TblResidentRegistration),
        //                CivilRegistration = GetCivilRegistration(owner.TblCivilRegistration),
        //                Identitycard = GetIdentityCard(owner.TblIdentityCard),
        //                //

        //            };
        //            List.Add(ownerobj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    return List.ToArray();
        //}

        private static Civilregistration[] GetCivilRegistration(ICollection<TblCivilRegistration> tblCivilRegistration)
        {
            var List = new List<Civilregistration>();
            try
            {
                foreach (var owner in tblCivilRegistration)
                {
                    var ownerobj = new Civilregistration
                    {
                        CivilRefistrationId = owner.CivilRefistrationId,
                        PersonRegistrationId = owner.PersonRegistrationId,
                        RegistrationDate = owner.RegistrationDate,
                        //  identityCard         = GetIdentityCard(owner.TblIdentityCard)

                    };
                    List.Add(ownerobj);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return List.ToArray();
        }

        //private static Identitycard[] GetIdentityCard(ICollection<TblIdentityCard> tblIdentityCard)
        //{
        //    var List = new List<Identitycard>();
        //    try
        //    {
        //        foreach (var owner in tblIdentityCard)
        //        {
        //            var ownerobj = new Identitycard
        //            {
        //                IdentityCard = owner.IdentityCard,
        //                IdentityNumber = owner.IdentityNumber,
        //                PersonRegistrationId = owner.PersonRegistrationId,
        //                ValidityCode = (owner?.ValidityCode == null) ? null : GetValidityCode(owner.ValidityCode),
        //                ValidityCodeId = owner.ValidityCodeId
        //            };
        //            List.Add(ownerobj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    return List.ToArray();
        //}

        //private static Validitycode GetValidityCode(TblLtValidityCodeList validityCode)
        //{
        //    Validitycode ownerobj = null;
        //    try
        //    {
        //        ownerobj = new Validitycode
        //        {
        //            Passport = GetPassport(validityCode.TblPassport),
        //        };
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //    return ownerobj;
        //}

        //private static PassportOBj[] GetPassport(ICollection<TblPassport> tblPassport)
        //{
        //    var List = new List<PassportOBj>();
        //    try
        //    {
        //        foreach (var owner in tblPassport)
        //        {
        //            var ownerobj = new PassportOBj
        //            {
        //                PassportId = owner.PassportId,
        //                ValidityCodeId = owner.ValidityCodeId

        //            };
        //            List.Add(ownerobj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return List.ToArray();
        //}

        private static Residentregistration[] GetResidentRegistration(ICollection<TblResidentRegistration> tblResidentRegistration)
        {
            var List = new List<Residentregistration>();
            try
            {
                foreach (var owner in tblResidentRegistration)
                {
                    var ownerobj = new Residentregistration
                    {
                        PersonRegistrationId = owner.PersonRegistrationId,
                        ResidentRegistrationId = owner.ResidentRegistrationId

                    };
                    List.Add(ownerobj);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return List.ToArray();
        }

        private static Personalactivitylicence[] GetActivityLicence(ICollection<TblPersonalActivityLicence> tblPersonalActivityLicence)
        {
            var List = new List<Personalactivitylicence>();
            try
            {
                foreach (var owner in tblPersonalActivityLicence)
                {
                    var ownerobj = new Personalactivitylicence
                    {
                        CompetitionLicenseIndicator = owner.CompetitionLicenseIndicator,
                        Name = owner.Name,
                        PersonalActivityLicenceId = owner.PersonalActivityLicenceId,
                        PersonRegistrationId = owner.PersonRegistrationId,
                        RenewalIntentionIndicator = owner.RenewalIntentionIndicator


                    };
                    List.Add(ownerobj);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return List.ToArray();
        }

        private static Educationcertificate[] GetEducationCertificate(ICollection<TblEducationCertificate> tblEducationCertificate)
        {
            var List = new List<Educationcertificate>();
            try
            {
                foreach (var owner in tblEducationCertificate)
                {
                    var ownerobj = new Educationcertificate
                    {
                        EducationCertificateCodeId = owner.EducationCertificateCodeId,
                        EducationCertificateId = owner.EducationCertificateId,
                        EducationCertificateTitleCodeId = owner.EducationCertificateTitleCodeId,
                        EducationGradeCodeId = owner.EducationGradeCodeId,
                        Name = owner.Name,
                        PersonRegistrationId = owner.PersonRegistrationId,
                        SubjectAreaCodeId = owner.SubjectAreaCodeId

                    };
                    List.Add(ownerobj);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return List.ToArray();
        }


        #endregion
    }
}
