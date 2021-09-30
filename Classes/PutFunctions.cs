using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Party_Dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Runtime.InteropServices.ComTypes;
using ErrorHandling.CommonClasses;
using TIH.Common.RedisCacheHandler;
using RegistrationDAL.Models;
using ContactAndPlaceDAL.Models;
using RoleAndRelationship_Dal.Models; 

namespace FnPerson.Classes
{
    public class PutFunctions
    {
        private readonly PartyContext _context;
        private readonly RegistrationContext _registrationContext;
        private readonly ContactAndPlaceContext _contactContext;
        private readonly RoleAndRelationshipContext _roleAndRelationshipContext; 
        private GetFunctions getFunctions;
        private readonly ICacheServiceClient Redisdatabase;
        public PutFunctions(PartyContext context, ICacheServiceClient _database)
        { 
            _registrationContext = new RegistrationContext();
            _contactContext = new ContactAndPlaceContext();
            _roleAndRelationshipContext = new RoleAndRelationshipContext(); 
            _context = context;
            Redisdatabase = _database;
            getFunctions = new GetFunctions(_context,_database);
        }
        #region Put

        public List<ReqPersonBasicObj> RequestPutBasicPerson(ReqPersonBasicObj basicPerson, string mode = null, string reqType = "POST")
        {

            PersonRootobject personRootObject = FormatObjectDetails.ConvertBasicPerson_Person(basicPerson);


            PersonArrayObject person = new PersonArrayObject();
            person.PersonalDetail = new List<PersonRootobject>();
            person.PersonalDetail.Add(personRootObject);

            List<PersonArrayObject> persons = new List<PersonArrayObject>();
            persons.Add(person);

            var TblPersonList = RequestPutPerson(persons, mode);
            PersonArrayObject personArrayObject = getFunctions.GetPersonTablewithLookups(TblPersonList);
            List<ReqPersonBasicObj> basicPersons = FormatObjectDetails.ConvertPerson_BasicPerson(personArrayObject);
            return basicPersons;
        }

        public List<TblVirtualParty> PutVirtualParty(VirtualParty virtualParty, string personIDreq)
        {

            TblPartyName tblPartyName = new TblPartyName();

            if (virtualParty.Party == null || virtualParty.Party.PartyId == 0)
            {
                TblParty partyObj = new TblParty { PartyTypeCodeId = 1 };
                _context.TblParty.Add(partyObj);
                _context.SaveChanges();

                if (virtualParty.Party == null) virtualParty.Party = new Party();

                virtualParty.Party.PartyId = partyObj.PartyId;
            }

            // write and update Tbl_VirtualPartyName
            if (virtualParty.VirtualPartyName.VirtualPartyNameId == 0)
            {
                TblVirtualPartyName tblVirtualPartyName = new TblVirtualPartyName
                {
                    VirtualPartyDesc = virtualParty.Description
                                                                                    ,
                    VirtualPartyNameCodeId = virtualParty.VirtualPartyName.VirtualPartyNameCodeId
                                                                                    ,
                    PartyNameId = virtualParty.VirtualPartyName.PartyNameId
                };

                _context.TblVirtualPartyName.Add(tblVirtualPartyName);
                _context.SaveChanges();

                if (virtualParty.VirtualPartyName == null) virtualParty.VirtualPartyName = new VirtualPartyName();

                virtualParty.VirtualPartyName.VirtualPartyNameId = tblVirtualPartyName.VirtualPartyNameId;

            }

            TblVirtualParty tblVirtualParty = new TblVirtualParty();
            tblVirtualParty.VirtualPartyId = virtualParty.VirtualPartyId.Value;
            tblVirtualParty.InternalExternalTypeId = virtualParty.InternalExgernalType.InternalExgernalTypeId;
            tblVirtualParty.PartyId = virtualParty.Party.PartyId;
            tblVirtualParty.VirtualPartyNameId = virtualParty.VirtualPartyName.VirtualPartyNameId;
            tblVirtualParty.Description = virtualParty.Description;
            _context.TblVirtualParty.Add(tblVirtualParty);
            _context.SaveChanges();

            virtualParty.VirtualPartyId = tblVirtualParty.VirtualPartyId;

            //var VirtualParty = _context.TblVirtualParty.Where(cl => cl.VirtualPartyId == virtualParty.VirtualPartyId).ToList();
            List<TblVirtualParty> tblVirtualPartyList = new List<TblVirtualParty>();
            tblVirtualPartyList.Add(tblVirtualParty);

            return tblVirtualPartyList;

        }
        public List<TblPerson> RequestPutPerson(List<PersonArrayObject> reqPersonobj, string personIDreq)
        {

            try
            {

                var RedisAvail = Redisdatabase.CheckConnection();
                //var ReqPersonobj = JsonConvert.DeserializeObject<List<PersonArrayObject>>(requestBody);
                var reqPersonDetail = reqPersonobj[0]?.PersonalDetail[0];
                var reqPersonDetails = reqPersonobj[0]?.PersonalDetail[0].PersonDetail;

                var reqPersonName = reqPersonobj[0]?.PersonalDetail[0].PersonName;
                var reqPersonRegistration = reqPersonobj[0]?.PersonalDetail[0].PersonRegistration;
                var reqPersonReferalLink = reqPersonobj[0]?.PersonalDetail[0].PersonReferalLink;

                var reqCountryList = reqPersonobj[0]?.PersonalDetail[0].CountryLink;
                var reqHouseholdRelationshipList = reqPersonobj[0]?.PersonalDetail[0].householdRelationship;


                var personID = (personIDreq == null) ? reqPersonDetail.PersonId : Convert.ToInt32(personIDreq);
                var reqPartyRoleRelationshipID = reqPersonDetails.PartyRoleRelationshipID;

                var personRecord = _context.TblPerson.Where(cl => cl.PersonId == personID).ToList();
                var personName = _context.TblPersonName.Where(cl => cl.PersonId == personID).ToList();
                var personregistration = _context.TblPersonRegistration.Where(cl => cl.PersonId == personID).ToList();
                var personDetail = _context.TblPersonDetail.Where(cl => cl.PersonId == personID).ToList();
                var personId = (personDetail[0]?.PersonId == null) || (personDetail[0]?.PersonId == 0) ? -1 : personDetail[0]?.PersonId;
                var personReferalLink = _context.TblPersonReferalLink.Where(cl => cl.PersonId == personID).ToList();



                var birth = _context.TblBirthCertificate.Where(cl => cl.PersonRegistrationId == (personregistration.Count == 0 ? -1 : personregistration.First().PersonRegistrationId)).ToList();

                var countryList = _context.TblCountry.Where(cl => cl.PersonId == personID).ToList();
                var householdRelationshipList = _context.TblHouseholdRelationship.Where(cl => cl.PartyRoleRelationshipId == reqPartyRoleRelationshipID).ToList();


                if (personId != -1)
                {
                    try
                    {
                        // need to make multiple updates 
                        // update personal // each update needs to go into sep functions 
                        personRecord[0].BloodTypeCodeId = reqPersonDetail.BloodTypeCodeId;
                        personRecord[0].DeathIndicator = reqPersonDetail.DeathIndicator;
                        personRecord[0].EthnicityId = reqPersonDetail.EthnicityId;
                        personRecord[0].MaritalStatusId = reqPersonDetail.MaritalStatusId;
                        personRecord[0].MissingIndicator = reqPersonDetail.MissingIndicator;
                        personRecord[0].CrossMonthlyIncomeId = reqPersonDetail?.CrossMonthlyIncomeID;
                        _context.TblPerson.Update(personRecord[0]);
                        _context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                        //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                        throw new Exception(ExceptionStringResponse);
                    }


                    if (reqPersonDetails != null)
                    {
                        try
                        {
                            personDetail[0].PartyId = (reqPersonDetails.PartyId > 0) ? reqPersonDetails.PartyId : personDetail[0].PartyId;
                            personDetail[0].PersonDetaiId = (reqPersonDetails.PersonDetaiId > 0) ? reqPersonDetails.PersonDetaiId : personDetail[0].PersonDetaiId;
                            personDetail[0].PersonId = (reqPersonDetails.PersonId > 0) ? reqPersonDetails.PersonId : personDetail[0].PersonId;

                            _context.TblPersonDetail.Update(personDetail[0]);
                            _context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                            //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                            throw new Exception(ExceptionStringResponse);
                        }
                    }

                    if (reqPersonName != null)
                    {
                        if (personName.Count > 0)
                        {
                            try
                            {
                                personName[0].GivenName = reqPersonName.GivenName;
                                personName[0].MiddleName = reqPersonName.MiddleName;
                                personName[0].Suffix = reqPersonName.Suffix;
                                personName[0].Surname = reqPersonName.Surname;
                                personName[0].PrefixTitleCodeId = reqPersonName.PrefixTitleCodeId;
                                personName[0].PersonNameUsageCodeId = reqPersonName.PersonNameUsageCodeId;
                                personName[0].Initials = reqPersonName.Initials;
                                personName[0].PreferredName = reqPersonName.PreferredName;

                                _context.TblPersonName.Update(personName[0]);
                                _context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }
                        }
                        else
                        {
                            try
                            {
                                TblPersonName tblPersonName = new TblPersonName
                                {
                                    GivenName = reqPersonName.GivenName,
                                    MiddleName = reqPersonName.MiddleName,
                                    Suffix = reqPersonName.Suffix,
                                    Surname = reqPersonName.Surname,
                                    PrefixTitleCodeId = reqPersonName.PrefixTitleCodeId,
                                    PersonNameUsageCodeId = reqPersonName.PersonNameUsageCodeId,
                                    Initials = reqPersonName.Initials,
                                    PreferredName = reqPersonName.PreferredName,
                                    PersonId = personID.Value
                                };
                                _context.TblPersonName.Add(tblPersonName);
                                _context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }
                        }
                        // update personaname

                    }

                    if (reqPersonRegistration != null)
                    {
                        if (personregistration.Count > 0)
                        {
                            try
                            {
                                personregistration[0].PersonRegistrationId = (reqPersonRegistration[0].PersonRegistrationId > 0) ? reqPersonRegistration[0].PersonRegistrationId : personregistration[0].PersonRegistrationId;
                                personregistration[0].PersonRegistrationTypeCodeId = (reqPersonRegistration[0].PersonRegistrationTypeCodeId > 0) ? reqPersonRegistration[0].PersonRegistrationTypeCodeId : personregistration[0].PersonRegistrationTypeCodeId;
                                _context.TblPersonRegistration.Update(personregistration[0]);
                                _context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }
                        }
                        else
                        {
                            try
                            {
                                RegistrationDAL.Models.TblPersonRegistration tblPersonRegistration = new RegistrationDAL.Models.TblPersonRegistration
                                {
                                    PersonRegistrationId = reqPersonRegistration[0].PersonRegistrationId,
                                    PersonRegistrationTypeCodeId = reqPersonRegistration[0].PersonRegistrationTypeCodeId

                                };
                                _registrationContext.TblPersonRegistration.Add(tblPersonRegistration);
                                _registrationContext.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }
                        }

                        //Civil Registration
                        if (reqPersonRegistration[0].CivilRegistration != null)
                        {
                            if (reqPersonRegistration[0].CivilRegistration.Count() > 0)
                            {
                                var CivilRegistration = _context.TblCivilRegistration.Where(cl => cl.PersonRegistrationId == personregistration[0].PersonRegistrationId).ToList();

                                if (CivilRegistration.Count > 0)
                                {
                                    try
                                    {
                                        CivilRegistration[0].RegistrationDate = reqPersonRegistration[0].CivilRegistration[0].RegistrationDate;
                                        CivilRegistration[0].CivilRefistrationId = reqPersonRegistration[0].CivilRegistration[0].CivilRefistrationId;
                                        _context.TblCivilRegistration.Update(CivilRegistration[0]);
                                        _context.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                        //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                        throw new Exception(ExceptionStringResponse);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        RegistrationDAL.Models.TblCivilRegistration tblCivilRegistration = new RegistrationDAL.Models.TblCivilRegistration
                                        {
                                            RegistrationDate = reqPersonRegistration[0].CivilRegistration[0].RegistrationDate,
                                            CivilRefistrationId = reqPersonRegistration[0].CivilRegistration[0].CivilRefistrationId
                                        };
                                        _registrationContext.TblCivilRegistration.Add(tblCivilRegistration);
                                        _registrationContext.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                        //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                        throw new Exception(ExceptionStringResponse);
                                    }
                                }
                            }
                        }

                        //Education Certificate
                        if (reqPersonRegistration[0].EducationCertificate != null)
                        {
                            if (reqPersonRegistration[0].EducationCertificate.Count() > 0)
                            {
                                var EducationCertificate = _context.TblEducationCertificate.Where(cl => cl.PersonRegistrationId == personregistration[0].PersonRegistrationId).ToList();

                                if (EducationCertificate.Count > 0)
                                {
                                    try
                                    {
                                        EducationCertificate[0].SubjectAreaCodeId = reqPersonRegistration[0].EducationCertificate[0].SubjectAreaCodeId;
                                        EducationCertificate[0].EducationCertificateCodeId = reqPersonRegistration[0].EducationCertificate[0].EducationCertificateCodeId;
                                        EducationCertificate[0].Name = reqPersonRegistration[0].EducationCertificate[0].Name;
                                        EducationCertificate[0].EducationCertificateTitleCodeId = reqPersonRegistration[0].EducationCertificate[0].EducationCertificateTitleCodeId;

                                        _context.TblEducationCertificate.Update(EducationCertificate[0]);
                                        _context.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                        //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                        throw new Exception(ExceptionStringResponse);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        TblEducationCertificate tblEducationCertificate = new TblEducationCertificate
                                        {

                                            SubjectAreaCodeId = reqPersonRegistration[0].EducationCertificate[0].SubjectAreaCodeId,
                                            EducationCertificateCodeId = reqPersonRegistration[0].EducationCertificate[0].EducationCertificateCodeId,
                                            Name = reqPersonRegistration[0].EducationCertificate[0].Name,
                                            EducationCertificateTitleCodeId = reqPersonRegistration[0].EducationCertificate[0].EducationCertificateTitleCodeId

                                        };
                                        _context.TblEducationCertificate.Add(tblEducationCertificate);
                                        _context.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                        //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                        throw new Exception(ExceptionStringResponse);
                                    }
                                }
                            }
                        }

                        //Personal Activity Licence
                        if (reqPersonRegistration[0].PersonalActivityLicence != null)
                        {
                            if (reqPersonRegistration[0].PersonalActivityLicence.Count() > 0)
                            {
                                var PersonalActivityLicence = _context.TblPersonalActivityLicence.Where(cl => cl.PersonRegistrationId == personregistration[0].PersonRegistrationId).ToList();

                                if (PersonalActivityLicence.Count > 0)
                                {
                                    PersonalActivityLicence[0].CompetitionLicenseIndicator = PersonalActivityLicence[0].CompetitionLicenseIndicator;
                                    PersonalActivityLicence[0].Name = reqPersonRegistration[0].PersonalActivityLicence[0].Name;
                                    PersonalActivityLicence[0].RenewalIntentionIndicator = PersonalActivityLicence[0].RenewalIntentionIndicator;
                                    //PersonalActivityLicence[0].PersonRegistrationId = PersonalActivityLicence[0].PersonRegistrationId;

                                    _context.TblPersonalActivityLicence.Update(PersonalActivityLicence[0]);
                                    _context.SaveChanges();
                                }
                                else
                                {
                                    TblPersonalActivityLicence tblPersonalActivityLicence = new TblPersonalActivityLicence
                                    {
                                        CompetitionLicenseIndicator = PersonalActivityLicence[0].CompetitionLicenseIndicator,
                                        Name = reqPersonRegistration[0].PersonalActivityLicence[0].Name,
                                        RenewalIntentionIndicator = PersonalActivityLicence[0].RenewalIntentionIndicator,
                                        //PersonRegistrationId = PersonalActivityLicence[0].PersonRegistrationId

                                    };
                                    _context.TblPersonalActivityLicence.Add(tblPersonalActivityLicence);
                                    _context.SaveChanges();
                                }
                            }
                        }

                        //Resident Registration (Link table no need to update)

                        //identity Card
                        if (reqPersonRegistration[0].Identitycard != null)
                        {
                            if (reqPersonRegistration[0].Identitycard.Count() > 0)
                            {
                                var Identitycard = _context.TblIdentityCard.Where(cl => cl.PersonRegistrationId == personregistration[0].PersonRegistrationId).ToList();

                                if (Identitycard.Count > 0)
                                {
                                    try
                                    {
                                        //Identitycard[0].PersonRegistrationId = ReqPersonRegistration[0].Identitycard[0].PersonRegistrationId;
                                        Identitycard[0].ValidityCodeId = reqPersonRegistration[0].Identitycard[0].ValidityCodeId;
                                        Identitycard[0].IdentityNumber = reqPersonRegistration[0].Identitycard[0].IdentityNumber;

                                        _context.TblIdentityCard.Update(Identitycard[0]);
                                        _context.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                        //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                        throw new Exception(ExceptionStringResponse);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        RegistrationDAL.Models.TblIdentityCard tblIdentityCard = new RegistrationDAL.Models.TblIdentityCard
                                        {
                                            //PersonRegistrationId = ReqPersonRegistration[0].Identitycard[0].PersonRegistrationId,
                                            ValidityCodeId = reqPersonRegistration[0].Identitycard[0].ValidityCodeId,
                                            IdentityNumber = reqPersonRegistration[0].Identitycard[0].IdentityNumber,
                                        };
                                        _registrationContext.TblIdentityCard.Add(tblIdentityCard);
                                        _registrationContext.SaveChanges();
                                    }
                                    catch (Exception ex)
                                    {
                                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                        //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                        throw new Exception(ExceptionStringResponse);
                                    }
                                }
                            }
                        }

                    }

                    if (reqPersonReferalLink != null && reqPersonReferalLink.Length > 0)
                    {
                        if (personReferalLink.Count > 0)
                        {
                            try
                            {
                                personReferalLink[0].PersonId = reqPersonReferalLink[0].PersonID;
                                personReferalLink[0].ReferalId = reqPersonReferalLink[0].ReferalID;

                                _context.TblPersonReferalLink.Update(personReferalLink[0]);
                                _context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }
                        }
                        else
                        {
                            try
                            {
                                TblPersonReferalLink tblPersonReferalLink = new TblPersonReferalLink
                                {
                                    PersonId = reqPersonReferalLink[0].PersonID,
                                    ReferalId = reqPersonReferalLink[0].ReferalID
                                };
                                _context.TblPersonReferalLink.Add(tblPersonReferalLink);
                                _context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }
                        }

                    }

                    if (reqCountryList != null && reqCountryList.Length > 0)
                    {

                        for (var i = 0; i < reqCountryList.Length; i++)
                        {
                            if (countryList.Count > 0)
                            {
                                try
                                {
                                    countryList[i].CountryCodeId = reqCountryList[i].CountryCodeID.Value;
                                    countryList[i].Capital = reqCountryList[i].Capital;
                                    countryList[i].FundAssetId = reqCountryList[i].FundAssetID;
                                    countryList[i].NationalityId = reqCountryList[i].NationalityId;
                                    countryList[i].PersonId = personID.Value;

                                    _context.TblCountry.Update(countryList[i]);
                                    _context.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                    //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                    throw new Exception(ExceptionStringResponse);
                                }
                            }
                            else
                            {
                                try
                                {
                                    Party_Dll.Models.TblCountry tblCountry = new Party_Dll.Models.TblCountry
                                    {
                                        CountryCodeId = reqCountryList[i].CountryCodeID.Value,
                                        Capital = reqCountryList[i].Capital,
                                        FundAssetId = reqCountryList[i].FundAssetID,
                                        NationalityId = reqCountryList[i].NationalityId,
                                        PersonId = personID.Value
                                    };
                                    _context.TblCountry.Add(tblCountry);
                                    _context.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                    //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                    throw new Exception(ExceptionStringResponse);
                                }
                            }
                        }
                    }

                    if (reqHouseholdRelationshipList != null && reqHouseholdRelationshipList.Length > 0)
                    {

                        for (var i = 0; i < reqHouseholdRelationshipList.Length; i++)
                        {

                            if (householdRelationshipList.Count() > 0)
                            {
                                try
                                {
                                    householdRelationshipList[i].PartyRoleRelationshipId = (int)reqHouseholdRelationshipList[i].PartyRoleRelationshipID;
                                    householdRelationshipList[i].HomeOwnerShipCodeId = reqHouseholdRelationshipList[i].HomeOwnerShipCodeID;
                                    householdRelationshipList[i].DependentAdultCount = reqHouseholdRelationshipList[i].DependentAdultCount;
                                    householdRelationshipList[i].DependantChildCount = reqHouseholdRelationshipList[i].DependentChildCount;
                                    householdRelationshipList[i].Family = reqHouseholdRelationshipList[i].Family;
                                    householdRelationshipList[i].Name = reqHouseholdRelationshipList[i].Name;
                                    householdRelationshipList[i].CrossMonthlyIncomeId = reqHouseholdRelationshipList[i].CrossMonthlyIncomeID;

                                    _context.TblHouseholdRelationship.Update(householdRelationshipList[i]);
                                    _context.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                    //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                    throw new Exception(ExceptionStringResponse);
                                }
                            }
                            else
                            {
                                try
                                {
                                    TblHouseholdRelationship tblHouseholdRelationship = new TblHouseholdRelationship
                                    {
                                        PartyRoleRelationshipId = (int)reqHouseholdRelationshipList[i].PartyRoleRelationshipID,
                                        HomeOwnerShipCodeId = reqHouseholdRelationshipList[i].HomeOwnerShipCodeID,
                                        DependentAdultCount = reqHouseholdRelationshipList[i].DependentAdultCount,
                                        DependantChildCount = reqHouseholdRelationshipList[i].DependentChildCount,
                                        Family = reqHouseholdRelationshipList[i].Family,
                                        Name = reqHouseholdRelationshipList[i].Name,
                                        CrossMonthlyIncomeId = reqHouseholdRelationshipList[i].CrossMonthlyIncomeID,


                                    };

                                    _context.TblHouseholdRelationship.Add(tblHouseholdRelationship);
                                    _context.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                    //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                    throw new Exception(ExceptionStringResponse);
                                }
                            }
                        }
                    }
                    var CachedPersonId = "PersonContext_" + personID.ToString();
                    if (RedisAvail.Status != TaskStatus.Faulted)
                    {
                        Redisdatabase.RemoveAsync(CachedPersonId);
                    }
                    return personRecord;
                    // return getFunctions.ReturnCleanData(personRecord);
                }
                else
                    throw new Exception("have to pass a personId for a Update");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ":" + ex.StackTrace);
                /*  return new HttpResponseMessage
                  {
                      Content = new StringContent(JsonConvert.SerializeObject(ex.Message + ":" + ex.StackTrace))
                  };
                */
            }
        }

        #endregion
        public async Task<HttpResponseMessage> RequestputPartyRoleInAgreement(string requestBody, string PartyRoleInAgreementIDreq)
        {

            try
            {
                dynamic ReqPartyRoleInAgreementDetailObj = JsonConvert.DeserializeObject<List<PartyRoleInAgreementArrayObject>>(requestBody);
                var ReqPartyRoleInAgreementDetail = ReqPartyRoleInAgreementDetailObj[0]?.PartyRoleInAgreementDetail[0];

                int PartyRoleInAgreementId = (PartyRoleInAgreementIDreq == null) ? ReqPartyRoleInAgreementDetail.PartyRoleInAgreementId : Convert.ToInt32(PartyRoleInAgreementIDreq);


                if (PartyRoleInAgreementId != -1)
                {
                    try
                    {
                        var PartyRoleInAgreement = await _context.TblPartyRoleInAgreement.Where(cl => cl.PartyRoleInAgreementId == PartyRoleInAgreementId).ToListAsync();

                        if (PartyRoleInAgreement != null)
                        {
                            try
                            {
                                PartyRoleInAgreement[0].AgreementId = ReqPartyRoleInAgreementDetail.AgreementId;
                                PartyRoleInAgreement[0].PartyRoleinAgreementTypeCodeId = ReqPartyRoleInAgreementDetail.PartyRoleinAgreementTypeCodeId;
                                //PartyRoleInAgreement[0].PartyId = ReqPartyRoleInAgreementDetail.PartyId;

                                _context.TblPartyRoleInAgreement.Update(PartyRoleInAgreement[0]);
                                _context.SaveChanges();

                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject(PartyRoleInAgreement, Formatting.Indented))
                                };
                            }
                            catch(Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                            }
                        }
                        else
                        {
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Invalid PartyRoleInAgreementId"))
                            };
                        }
                    }
                    catch(Exception ex)
                    {
                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                        return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                    }

                }
                else
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("have to pass a PartyRoleInAgreementId for a Update"))
                    };


            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message + ":" + ex.StackTrace))
                };
            }
        }

        public async Task<HttpResponseMessage> RequestPutPrincipleMember(PrincipleMemberDetails principleMember)
        {
            try
            {
                if (principleMember.PartyId > 0 && principleMember.PersonId > 0)
                {
                    int genderCodeId = _context.TblLtGenderCodeList.FirstOrDefault(x => x.GenderCode == principleMember.GenderCode).GenderCodeId;

                    var personToUpdate = _context.TblPerson.FirstOrDefault(x => x.PersonId == principleMember.PersonId);
                    personToUpdate.GenderCodeId = genderCodeId;
                    _context.TblPerson.Update(personToUpdate);
                    _context.SaveChanges();

                    //principle member will always be private party. No need to update party table and person detail

                    string[] fullNameSplit = principleMember.FullName.Split(" ");
                    string middleNames = "";
                    for (var i = 1; i < fullNameSplit.Length; i++)
                    {
                        middleNames += " " + fullNameSplit[i];

                    }
                    var prefixTitleCodeId = _context.TblLtPrefixTitleCodeList.FirstOrDefault(x => x.PrefixTitleCode == principleMember.TitleCode).PrefixTitleCodeId;
                    var personNameToUpdate = _context.TblPersonName.FirstOrDefault(x => x.PersonId == principleMember.PersonId);
                    personNameToUpdate.GivenName = fullNameSplit[0];
                    personNameToUpdate.MiddleName = middleNames;
                    personNameToUpdate.PrefixTitleCodeId = prefixTitleCodeId;
                    personNameToUpdate.Surname = principleMember.Surname;
                    personNameToUpdate.Initials = principleMember.Initials;
                    personNameToUpdate.PreferredName = principleMember.PreferedName;
                    personNameToUpdate.PersonId = principleMember.PersonId;
                    _context.TblPersonName.Update(personNameToUpdate);
                    _context.SaveChanges();

                    //not updating agreement vaules hard coded in local.settings
                    var CurrentpersonRegistrationTypeCodeId = _registrationContext.TblLtPersonRegistrationTypeCodeList.FirstOrDefault(x => x.PersonRegistrationTypeCode == principleMember.IdTypeCode).PersonRegistrationTypeCodeId;
                    var personRegistrationtoUpdate = _registrationContext.TblPersonRegistration.FirstOrDefault(x => x.PersonId == principleMember.PersonId);
                    personRegistrationtoUpdate.PersonRegistrationTypeCodeId = CurrentpersonRegistrationTypeCodeId;
                    _registrationContext.TblPersonRegistration.Update(personRegistrationtoUpdate);
                    _registrationContext.SaveChanges();

                    //point identity to Registration DAL
                    var identityCardToUpdate = _registrationContext.TblIdentityCard.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationtoUpdate.PersonRegistrationId);
                    identityCardToUpdate.IdentityNumber = principleMember.IdNumber;
                    _registrationContext.TblIdentityCard.Update(identityCardToUpdate);
                    _registrationContext.SaveChanges();

                    var dateOfBirthtoUpdate = _registrationContext.TblBirthCertificate.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationtoUpdate.PersonRegistrationId);
                    dateOfBirthtoUpdate.BirthDate = principleMember.DateOfBirth;
                    _registrationContext.TblBirthCertificate.Update(dateOfBirthtoUpdate);
                    _registrationContext.SaveChanges();

                    var currentCountrycodeId = _context.TblLtCountryCodeList.FirstOrDefault(x => x.CountryCode == principleMember.NationalityCode).CountryCodeId;
                    var currentNationalityId = _context.TblLtNationality.FirstOrDefault(x => x.NationalityCode == principleMember.NationalityCode).NationalityId;

                    var countryToUpdate = _context.TblCountry.FirstOrDefault(x => x.PersonId == principleMember.PersonId);
                    countryToUpdate.CountryCodeId = currentCountrycodeId;
                    countryToUpdate.NationalityId = currentNationalityId;
                    _context.TblCountry.Update(countryToUpdate);
                    _context.SaveChanges();

                    Emailcontact principleMemberEmail = new Emailcontact
                    {
                        EmailAddress = principleMember.Emailaddress,
                        PkemailContactId = principleMember.EmailId
                    };

                    List<TelephoneNumber> principleMemberTelephoneList = new List<TelephoneNumber>();
                    foreach (var telephone in principleMember.TelephoneLists)
                    {
                        var currentTelephoneTypeCodeListId = _contactContext.TblLtTelephoneTypeCodeList
                            .FirstOrDefault(x => x.TelephoneTypeCode.ToUpper() == telephone.TelephoneTypeCodeListCode.ToUpper()).TelephoneTypeCodeListId;
                        TelephoneNumber currentTelepohne = new TelephoneNumber
                        {
                            TelephoneTypeCodeListId = currentTelephoneTypeCodeListId,
                            FullNumber = telephone.Number,
                            isPrimary = telephone.PreferedNumber,

                            AreaCode = "",
                            CountryCode = "",
                            TrunkPrefix = "",
                            Extension = "",
                            TelephoneNetworkTypeCodeId = null,
                            PktelephoneNumberId = telephone.TelephoneNumberId
                        };

                        principleMemberTelephoneList.Add(currentTelepohne);
                    }

                    RootRoleObject prepObj = new RootRoleObject();
                    prepObj.rolePersonPartyContactDetails = new List<RolePersonPartyContactDetails>();
                    prepObj.rolePersonPartyContactDetails.Add(new RolePersonPartyContactDetails
                    {
                        emailContact = principleMemberEmail,
                        telephoneNumberList = principleMemberTelephoneList.ToArray(),
                        PartyId = principleMember.PartyId,
                        PersonId = principleMember.PersonId
                    });

                    var contactAndPlaceMSURL = Environment.GetEnvironmentVariable("ContactAndPlaceMSURL");
                    var personPartyContactRoleDetails = _contactContext.TblRolePersonPartyContactDetails.FirstOrDefault(x => x.PersonId == principleMember.PersonId);
                    if (personPartyContactRoleDetails != null)
                    {

                        prepObj.rolePersonPartyContactDetails[0].PersonPartyContactRoleId = personPartyContactRoleDetails.PersonPartyContactRoleId; 
                        List<RootRoleObject> requestPutObj = new List<RootRoleObject>();
                        requestPutObj.Add(prepObj);

                        var jsonContactPutObj = JsonConvert.SerializeObject(requestPutObj);
                        var contactPutData = new StringContent(jsonContactPutObj, Encoding.UTF8, "application/json");
                       
                        var contactClient = new HttpClient();
                        var httpContactPutRespMsg = await contactClient.PutAsync(contactAndPlaceMSURL, contactPutData);
                        if (httpContactPutRespMsg.IsSuccessStatusCode)
                        {
                            var getResponse = await getFunctions.RequestGetPrincipleMember(principleMember.PersonId.ToString(), principleMember.AgreementId.ToString());
                            string getResponseBody = await getResponse.Content.ReadAsStringAsync();
                            PrincipleMemberDetails responseObj = JsonConvert.DeserializeObject<PrincipleMemberDetails>(getResponseBody);
                            PostPrincipleMemberResponse putResponse = new PostPrincipleMemberResponse();
                            putResponse.principleMemberDetails = responseObj;

                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(putResponse, Formatting.Indented))
                            };

                        }
                        else
                        {
                            string errorBody = await httpContactPutRespMsg.Content.ReadAsStringAsync();

                            var getResponse = await getFunctions.RequestGetPrincipleMember(principleMember.PersonId.ToString(), principleMember.AgreementId.ToString());
                            string getResponseBody = await getResponse.Content.ReadAsStringAsync();

                            PostPrincipleMemberResponse putResponse = new PostPrincipleMemberResponse();
                            PrincipleMemberDetails responseObj = JsonConvert.DeserializeObject<PrincipleMemberDetails>(getResponseBody);
                            putResponse.principleMemberDetails = responseObj;
                            putResponse.ErrorList = new List<string>();
                            putResponse.ErrorList.Add(errorBody);


                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(putResponse, Formatting.Indented))
                            };
                        }
                    }
                    else
                    {
                        //no entry we need to post
                        List<RootRoleObject> requestPosttObj = new List<RootRoleObject>();
                        requestPosttObj.Add(prepObj);

                        var jsonContactObj = JsonConvert.SerializeObject(requestPosttObj);
                        var contactData = new StringContent(jsonContactObj, Encoding.UTF8, "application/json");
                        var contactClient = new HttpClient();
                        var httpContactRespMsg = await contactClient.PostAsync(contactAndPlaceMSURL, contactData);
                        if (httpContactRespMsg.IsSuccessStatusCode)
                        {
                            var getResponse = await getFunctions.RequestGetPrincipleMember(principleMember.PersonId.ToString(), principleMember.AgreementId.ToString());
                            string getResponseBody = await getResponse.Content.ReadAsStringAsync();
                            PrincipleMemberDetails responseObj = JsonConvert.DeserializeObject<PrincipleMemberDetails>(getResponseBody);


                            PostPrincipleMemberResponse postResponse = new PostPrincipleMemberResponse();
                            postResponse.principleMemberDetails = responseObj;

                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
                            };
                        }
                        else
                        {
                            string errorBody = await httpContactRespMsg.Content.ReadAsStringAsync();

                            var getResponse = await getFunctions.RequestGetPrincipleMember(principleMember.PersonId.ToString(), principleMember.AgreementId.ToString());
                            string getResponseBody = await getResponse.Content.ReadAsStringAsync();

                            PostPrincipleMemberResponse postResponse = new PostPrincipleMemberResponse();
                            PrincipleMemberDetails responseObj = JsonConvert.DeserializeObject<PrincipleMemberDetails>(getResponseBody);
                            postResponse.principleMemberDetails = responseObj;
                            postResponse.ErrorList = new List<string>();
                            postResponse.ErrorList.Add(errorBody);


                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
                            };
                        }

                    }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: Please provide PartyId and PersonId for principle member update", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                    
                }
            }
            catch(Exception ex)
            {
                throw; 
            }
        }
        public async Task<HttpResponseMessage> RequestPutContactPerson(ContactPersonDetails contactPerson)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                if (contactPerson.PartyId > 0 && contactPerson.PersonId > 0)
                {
                    int genderCodeId = _context.TblLtGenderCodeList.FirstOrDefault(x => x.GenderCode == contactPerson.GenderCode).GenderCodeId;

                    var personToUpdate = _context.TblPerson.FirstOrDefault(x => x.PersonId == contactPerson.PersonId);
                    personToUpdate.GenderCodeId = genderCodeId;
                    _context.TblPerson.Update(personToUpdate);
                    _context.SaveChanges();

                    //principle member will always be private party. No need to update party table and person detail

                    string[] fullNameSplit = contactPerson.FullName.Split(" ");
                    string middleNames = "";
                    for (var i = 1; i < fullNameSplit.Length; i++)
                    {
                        middleNames += " " + fullNameSplit[i];

                    }
                    var prefixTitleCodeId = _context.TblLtPrefixTitleCodeList.FirstOrDefault(x => x.PrefixTitleCode == contactPerson.TitleCode).PrefixTitleCodeId;
                    var personNameToUpdate = _context.TblPersonName.FirstOrDefault(x => x.PersonId == contactPerson.PersonId);
                    personNameToUpdate.GivenName = fullNameSplit[0];
                    personNameToUpdate.MiddleName = middleNames;
                    personNameToUpdate.PrefixTitleCodeId = prefixTitleCodeId;
                    personNameToUpdate.Surname = contactPerson.Surname;
                    personNameToUpdate.Initials = contactPerson.Initials;
                    personNameToUpdate.PreferredName = contactPerson.PreferedName;
                    personNameToUpdate.PersonId = contactPerson.PersonId;
                    _context.TblPersonName.Update(personNameToUpdate);
                    _context.SaveChanges();

                    //not updating agreement vaules hard coded in local.settings
                    var CurrentpersonRegistrationTypeCodeId = _registrationContext.TblLtPersonRegistrationTypeCodeList.FirstOrDefault(x => x.PersonRegistrationTypeCode == contactPerson.IdTypeCode).PersonRegistrationTypeCodeId;
                    var personRegistrationtoUpdate = _registrationContext.TblPersonRegistration.FirstOrDefault(x => x.PersonId == contactPerson.PersonId);
                    personRegistrationtoUpdate.PersonRegistrationTypeCodeId = CurrentpersonRegistrationTypeCodeId;
                    _registrationContext.TblPersonRegistration.Update(personRegistrationtoUpdate);
                    _registrationContext.SaveChanges();

                    //point identity to Registration DAL
                    var identityCardToUpdate = _registrationContext.TblIdentityCard.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationtoUpdate.PersonRegistrationId);
                    identityCardToUpdate.IdentityNumber = contactPerson.IdNumber;
                    _registrationContext.TblIdentityCard.Update(identityCardToUpdate);
                    _registrationContext.SaveChanges();

                    var dateOfBirthtoUpdate = _registrationContext.TblBirthCertificate.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationtoUpdate.PersonRegistrationId);
                    dateOfBirthtoUpdate.BirthDate = contactPerson.DateOfBirth;
                    _registrationContext.TblBirthCertificate.Update(dateOfBirthtoUpdate);
                    _registrationContext.SaveChanges();

                    var currentCountrycodeId = _context.TblLtCountryCodeList.FirstOrDefault(x => x.CountryCode == contactPerson.NationalityCode).CountryCodeId;
                    var currentNationalityId = _context.TblLtNationality.FirstOrDefault(x => x.NationalityCode == contactPerson.NationalityCode).NationalityId;

                    var countryToUpdate = _context.TblCountry.FirstOrDefault(x => x.PersonId == contactPerson.PersonId);
                    countryToUpdate.CountryCodeId = currentCountrycodeId;
                    countryToUpdate.NationalityId = currentNationalityId;
                    _context.TblCountry.Update(countryToUpdate);
                    _context.SaveChanges();

                    //var PartyRoleToUpdate = _roleAndRelationshipContext.TblPartyRole.FirstOrDefault(x => x.PartyId == contactPerson.PartyId); 
                    //if(PartyRoleToUpdate != null)
                    //{
                    //    if(PartyRoleToUpdate.RoleId != contactPerson.RoleId)
                    //    {
                    //        PartyRoleToUpdate.RoleId = contactPerson.RoleId;
                    //        _roleAndRelationshipContext.Update(PartyRoleToUpdate);
                    //        _roleAndRelationshipContext.SaveChanges();
                           
                    //    }
                    //}

                    await transaction.CommitAsync();
                    Emailcontact principleMemberEmail = new Emailcontact
                    {
                        EmailAddress = contactPerson.Emailaddress,
                        PkemailContactId = contactPerson.EmailId
                    };

                    List<TelephoneNumber> principleMemberTelephoneList = new List<TelephoneNumber>();
                    foreach (var telephone in contactPerson.TelephoneLists)
                    {
                        var currentTelephoneTypeCodeListId = _contactContext.TblLtTelephoneTypeCodeList
                            .FirstOrDefault(x => x.TelephoneTypeCode.ToUpper() == telephone.TelephoneTypeCodeListCode.ToUpper()).TelephoneTypeCodeListId;
                        TelephoneNumber currentTelepohne = new TelephoneNumber
                        {
                            TelephoneTypeCodeListId = currentTelephoneTypeCodeListId,
                            FullNumber = telephone.Number,
                            isPrimary = telephone.PreferedNumber,

                            AreaCode = "",
                            CountryCode = "",
                            TrunkPrefix = "",
                            Extension = "",
                            TelephoneNetworkTypeCodeId = null,
                            PktelephoneNumberId = telephone.TelephoneNumberId
                        };

                        principleMemberTelephoneList.Add(currentTelepohne);
                    }

                    RootRoleObject prepObj = new RootRoleObject();
                    prepObj.rolePersonPartyContactDetails = new List<RolePersonPartyContactDetails>();
                    prepObj.rolePersonPartyContactDetails.Add(new RolePersonPartyContactDetails
                    {
                        emailContact = principleMemberEmail,
                        telephoneNumberList = principleMemberTelephoneList.ToArray(),
                        PartyId = contactPerson.PartyId,
                        PersonId = contactPerson.PersonId
                    });

                    var contactAndPlaceMSURL = Environment.GetEnvironmentVariable("ContactAndPlaceMSURL");
                    var personPartyContactRoleDetails = _contactContext.TblRolePersonPartyContactDetails.FirstOrDefault(x => x.PersonId == contactPerson.PersonId);
                    if (personPartyContactRoleDetails != null)
                    {

                        prepObj.rolePersonPartyContactDetails[0].PersonPartyContactRoleId = personPartyContactRoleDetails.PersonPartyContactRoleId;
                        List<RootRoleObject> requestPutObj = new List<RootRoleObject>();
                        requestPutObj.Add(prepObj);

                        var jsonContactPutObj = JsonConvert.SerializeObject(requestPutObj);
                        var contactPutData = new StringContent(jsonContactPutObj, Encoding.UTF8, "application/json");

                        var contactClient = new HttpClient();
                        var httpContactPutRespMsg = await contactClient.PutAsync(contactAndPlaceMSURL, contactPutData);
                        if (httpContactPutRespMsg.IsSuccessStatusCode)
                        {
                            var getResponse = await getFunctions.RequestGetContactPerson(contactPerson.PersonId.ToString(), contactPerson.AgreementId.ToString());
                            string getResponseBody = await getResponse.Content.ReadAsStringAsync();
                            ContactPersonDetails responseObj = JsonConvert.DeserializeObject<ContactPersonDetails>(getResponseBody);
                            ContactPersonResponse putResponse = new ContactPersonResponse();
                            putResponse.contactPersonDetails = responseObj;

                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(putResponse, Formatting.Indented))
                            };

                        }
                        else
                        {
                            string errorBody = await httpContactPutRespMsg.Content.ReadAsStringAsync();

                            var getResponse = await getFunctions.RequestGetContactPerson(contactPerson.PersonId.ToString(), contactPerson.AgreementId.ToString());
                            string getResponseBody = await getResponse.Content.ReadAsStringAsync();

                            ContactPersonResponse putResponse = new ContactPersonResponse();
                            ContactPersonDetails responseObj = JsonConvert.DeserializeObject<ContactPersonDetails>(getResponseBody);
                            putResponse.contactPersonDetails = responseObj;
                            putResponse.ErrorList = new List<string>();
                            putResponse.ErrorList.Add(errorBody);


                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(putResponse, Formatting.Indented))
                            };
                        }
                    }
                    else
                    {
                        //no entry we need to post
                        List<RootRoleObject> requestPosttObj = new List<RootRoleObject>();
                        requestPosttObj.Add(prepObj);

                        var jsonContactObj = JsonConvert.SerializeObject(requestPosttObj);
                        var contactData = new StringContent(jsonContactObj, Encoding.UTF8, "application/json");
                        var contactClient = new HttpClient();
                        var httpContactRespMsg = await contactClient.PostAsync(contactAndPlaceMSURL, contactData);
                        if (httpContactRespMsg.IsSuccessStatusCode)
                        {
                            var getResponse = await getFunctions.RequestGetContactPerson(contactPerson.PersonId.ToString(), contactPerson.AgreementId.ToString());
                            string getResponseBody = await getResponse.Content.ReadAsStringAsync();
                            ContactPersonDetails responseObj = JsonConvert.DeserializeObject<ContactPersonDetails>(getResponseBody);


                            ContactPersonResponse postResponse = new ContactPersonResponse();
                            postResponse.contactPersonDetails = responseObj;

                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
                            };
                        }
                        else
                        {
                            string errorBody = await httpContactRespMsg.Content.ReadAsStringAsync();

                            var getResponse = await getFunctions.RequestGetContactPerson(contactPerson.PersonId.ToString(), contactPerson.AgreementId.ToString());
                            string getResponseBody = await getResponse.Content.ReadAsStringAsync();

                            ContactPersonResponse postResponse = new ContactPersonResponse();
                            ContactPersonDetails responseObj = JsonConvert.DeserializeObject<ContactPersonDetails>(getResponseBody);
                            postResponse.contactPersonDetails = responseObj;
                            postResponse.ErrorList = new List<string>();
                            postResponse.ErrorList.Add(errorBody);


                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
                            };
                        }

                    }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: Please provide PartyId and PersonId for principle member update", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

       
    }
}
