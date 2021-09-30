using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Party_Dll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ErrorHandling.CommonClasses;
using TIH.Common.RedisCacheHandler;
using ContactAndPlaceDAL.Models;
using RegistrationDAL.Models;
using RoleAndRelationship_Dal.Models;
using Agreement_DAL.Models;

namespace FnPerson.Classes
{
    public class PostFunctions
    {
        private readonly PartyContext _context;
        private readonly ContactAndPlaceContext _contactContext;
        private readonly RegistrationContext _registrationContext;
        private readonly RoleAndRelationshipContext _roleAndRelationshipContext;
        private readonly AgreementsContext _agreementcontext;
        private readonly ICacheServiceClient Redisdatabase;
        GetFunctions getFunctions;
        public PostFunctions(PartyContext context, ICacheServiceClient _database)
        {
            _contactContext = new ContactAndPlaceContext();
            _registrationContext = new RegistrationContext();
            _roleAndRelationshipContext = new RoleAndRelationshipContext();
            _agreementcontext = new AgreementsContext(); 
            _context = context;
            Redisdatabase = _database;
            getFunctions = new GetFunctions(_context, _database);
        }

        //public List<ReqPersonBasicObj> RequestPostBasicPerson(ReqPersonBasicObj basicPerson, string mode = null, string reqType = "POST")
        //{

        //    PersonRootobject personRootObject = FormatObjectDetails.ConvertBasicPerson_Person(basicPerson);

        //    PersonArrayObject person = new PersonArrayObject();
        //    person.PersonalDetail = new List<PersonRootobject>();
        //    person.PersonalDetail.Add(personRootObject);

        //    List<PersonArrayObject> persons = new List<PersonArrayObject>();
        //    persons.Add(person);

        //    var TblPersonList = RequestPostPerson(persons, mode);

        //    PersonArrayObject personArrayObject = getFunctions.GetPersonTablewithLookups(TblPersonList);

        //    List<ReqPersonBasicObj> basicPersons = FormatObjectDetails.ConvertPerson_BasicPerson(personArrayObject);
        //    basicPersons[0].PartyRoleInProduct = basicPerson.PartyRoleInProduct;

        //    var tblPartyRoleinProduct = TblPartyRoleInProduct(basicPersons);
        //    basicPersons[0].PartyRoleInProduct[0] = FormatObjectDetails.Convert_TblPartyRoleInProduct_PartyRoleInProduct(tblPartyRoleinProduct);

        //    return basicPersons;
        //}

        //public Party_Dll.Models.TblPartyRoleInProduct TblPartyRoleInProduct(List<ReqPersonBasicObj> basicPersons)
        //{
        //    var partyRoleinAgreementTypeCodeID = Environment.GetEnvironmentVariable("PartyRoleInProductTypeCodeId");
        //    try
        //    {
        //        Party_Dll.Models.TblPartyRoleInProduct tblPartyRoleInProduct = new Party_Dll.Models.TblPartyRoleInProduct
        //        {
        //            ProductSpecificationId = basicPersons[0].PartyRoleInProduct[0].ProductSpecificationId,
        //            PartyRoleInProductTypeCodeId = Convert.ToInt32(partyRoleinAgreementTypeCodeID), // TO be cread from config
        //            PartyId = basicPersons[0].PersonDetail.PartyId
        //        };

        //        _context.TblPartyRoleInProduct.Add(tblPartyRoleInProduct);
        //        _context.SaveChanges();

        //        return tblPartyRoleInProduct;
        //    }
        //    catch (Exception ex)
        //    {
        //        var ExceptionCatcher = new ExceptionCatcher();
        //        var HttpResponseFormatter = new HttpResponseFormatter();
        //        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);

        //        throw new Exception(ExceptionStringResponse);
        //    }
        //}

        public List<TblVirtualParty> PostVirtualParty(VirtualParty virtualParty, string mode = null, string reqType = "POST")
        {
            // write and update  Tbl_PartyName

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

        public List<TblPerson> RequestPostPerson(List<PersonArrayObject> persons, string mode = null, string reqType = "POST")
        {
            string _errLog = "RequestPost";
            try
            {


                var personDetail = persons[0]?.PersonalDetail[0];
                var reqPersonName = persons[0]?.PersonalDetail[0].PersonName;
                var reqPersonRegistration = persons[0]?.PersonalDetail[0].PersonRegistration;
                var reqPersonReferalLink = persons[0]?.PersonalDetail[0].PersonReferalLink;
                var reqPersonDetails = persons[0]?.PersonalDetail[0].PersonDetail;

                //var ReqCountry = (Personobj[0]?.PersonDetail[0]?.CountryLink == null) ? null : Personobj[0]?.PersonDetail[0]?.CountryLink[0];
                var reqCountryList = persons[0]?.PersonalDetail[0].CountryLink;
                var reqHouseholdRelationshipList = persons[0]?.PersonalDetail[0].householdRelationship;
                var birth = (reqPersonRegistration?.Count() > 0) ? reqPersonRegistration[0]?.BirthCertificate : null;

                int? partyRoleRelationshipID = 0;
                var partyID = 0;
                var personID = 0;

                var PersonId = (personDetail?.PersonId == null) || (personDetail?.PersonId == 0) ? -1 : personDetail?.PersonId;
                if (PersonId == -1)
                {
                    try
                    {
                        TblPerson personObj = new TblPerson
                        {
                            BloodTypeCodeId = personDetail.BloodTypeCodeId,
                            DeathIndicator = personDetail.DeathIndicator,
                            EthnicityId = personDetail.EthnicityId,
                            GenderCodeId = personDetail.GenderCodeId,
                            MaritalStatusId = personDetail.MaritalStatusId,
                            MissingIndicator = personDetail.MissingIndicator,
                            CrossMonthlyIncomeId = personDetail.CrossMonthlyIncomeID,
                        };

                        _context.TblPerson.Add(personObj);
                        _context.SaveChanges();
                        personID = personObj.PersonId;
                    }
                    catch (Exception ex)
                    {
                        var ExceptionCatcher = new ExceptionCatcher();
                        var HttpResponseFormatter = new HttpResponseFormatter();
                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);

                        throw new Exception(ExceptionStringResponse);
                    }


                    if (reqPersonDetails != null)
                    {

                        partyRoleRelationshipID = (personDetail.PersonDetail?.PartyRoleRelationshipID > -1) ? personDetail.PersonDetail?.PartyRoleRelationshipID : -1;
                        if (partyRoleRelationshipID < 1)
                        {
                            TblPartyRoleRelationship partyRoleRelationshipObj = new TblPartyRoleRelationship
                            {
                                PartyRoleRelationShipTypeCodeId = 1
                            };
                            _context.TblPartyRoleRelationship.Add(partyRoleRelationshipObj);
                            _context.SaveChanges();
                            partyRoleRelationshipID = partyRoleRelationshipObj.PartyRoleRelationshipId;
                        }


                        TblParty partyObj = new TblParty
                        {
                            PartyTypeCodeId = 1
                        };
                        _context.TblParty.Add(partyObj);
                        _context.SaveChanges();
                        partyID = partyObj.PartyId;



                        try
                        {

                            TblPersonDetail tblLtPersonDetail = new TblPersonDetail
                            {
                                PartyId = partyID,
                                PersonId = personID,
                                PersonDetailCodeId = reqPersonDetails.PersonDetailCodeId,
                                PartyRoleRelationshipId = partyRoleRelationshipID
                            };
                            _context.TblPersonDetail.Add(tblLtPersonDetail);
                            _context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                            // return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                            throw new Exception(ExceptionStringResponse);
                        }

                        // Relationship
                        if (personDetail.RelationshipDescriptionCodeID > 0)
                        {
                            try
                            {
                                //TODO: TblPartyRole  needs to be added to link a tblPartyRoleinRelationShip to a party id
                                TblPartyRoleInRelationship tblPartyRoleinRelationShip = new TblPartyRoleInRelationship
                                {
                                    PartyRoleInRelationshipTypeCodeId = (int)personDetail.RelationshipDescriptionCodeID,
                                };
                                _context.TblPartyRoleInRelationship.Add(tblPartyRoleinRelationShip);
                                _context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                //  return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }
                        }

                        if (personDetail.PrincipleMember ?? false)
                        {
                            try
                            {
                                var agreementURL = Environment.GetEnvironmentVariable("AgreementMsURL");
                                var partyRoleinAgreementTypeCodeID = Environment.GetEnvironmentVariable("PartyRoleinAgreementTypeCodeId");
                                int agreementId = -1;

                                var agreementName = Guid.NewGuid().ToString();
                                if (personDetail.PersonName != null)
                                    agreementName = (personDetail.PersonName?.Surname) + "_" + personDetail.PersonName?.GivenName + "_" + personDetail.PersonName?.PersonaNameId.ToString();

                                var AgreementObj = new Agreement
                                {
                                    AgreementKindCodeListID = (Environment.GetEnvironmentVariable("AgreementKindCodeListId") == null) ? 1 : int.Parse(Environment.GetEnvironmentVariable("AgreementKindCodeListId")),
                                    Name = agreementName,
                                    StatusCodeListID = int.Parse(Environment.GetEnvironmentVariable("StatusCodeListId")),
                                    StatusReasonCodeListID = int.Parse(Environment.GetEnvironmentVariable("StatusReasonCodeListId")),
                                    TextQualificationCodeListID = int.Parse(Environment.GetEnvironmentVariable("TextQualificationCodeListId")),
                                    Version = Environment.GetEnvironmentVariable("Version"),
                                    AgreementID = agreementId
                                };
                                List<Agreement> aggreementlist = new List<Agreement>();
                                aggreementlist.Add(AgreementObj);
                                var arrayagreementList = new List<AgreementList>();
                                AgreementList agreementList = new AgreementList
                                {
                                    AgreementDetail = aggreementlist.ToArray()
                                };
                                arrayagreementList.Add(agreementList);


                                //Post to Agreement 
                                // we dont put httpclient in using as it has memory leaks 
                                var json = JsonConvert.SerializeObject(arrayagreementList);
                                var data = new StringContent(json, Encoding.UTF8, "application/json");
                                var client = new HttpClient();
                                var httpRespMsg = client.PostAsync(agreementURL, data);
                                var result = httpRespMsg.Result;
                                if (result.IsSuccessStatusCode)
                                {
                                    string ResponseBody = result.Content.ReadAsStringAsync().Result;
                                    dynamic AgreementResponse = JsonConvert.DeserializeObject(ResponseBody);
                                    if (AgreementResponse.AgreementDetail[0].AgreementId > 0)
                                    {
                                        TblPartyRoleInAgreement tblPartyRoleInAgreement = new TblPartyRoleInAgreement
                                        {
                                            PartyId = partyID,
                                            PartyRoleinAgreementTypeCodeId = int.Parse(partyRoleinAgreementTypeCodeID),
                                            AgreementId = AgreementResponse.AgreementDetail[0].AgreementId
                                        };
                                        _context.TblPartyRoleInAgreement.Add(tblPartyRoleInAgreement);
                                        _context.SaveChanges();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                                throw new Exception(ex.InnerException + ":env :"
                                    + Environment.GetEnvironmentVariable("AgreementMsURL")
                                    + "?AgreementKindCodeListId:" + Environment.GetEnvironmentVariable("AgreementKindCodeListId")
                                    + "?StatusCodeListId:" + Environment.GetEnvironmentVariable("StatusCodeListId")
                                    + "?StatusReasonCodeListId:" + Environment.GetEnvironmentVariable("StatusReasonCodeListId")
                                    + "?TextQualificationCodeListID:" + Environment.GetEnvironmentVariable("TextQualificationCodeListId")
                                    + "?Version:" + Environment.GetEnvironmentVariable("Version"));
                            }
                        }
                    }

                    if (reqPersonName != null)
                    {
                        try
                        {
                            TblPersonName tblPersonNameObj = new TblPersonName
                            {
                                GivenName = reqPersonName?.GivenName,
                                MiddleName = reqPersonName?.MiddleName,
                                PrefixTitleCodeId = reqPersonName.PrefixTitleCodeId,
                                Surname = reqPersonName?.Surname,
                                Suffix = reqPersonName?.Suffix,
                                PersonNameUsageCodeId = reqPersonName.PersonNameUsageCodeId,
                                Initials = reqPersonName.Initials,
                                PreferredName = reqPersonName.PreferredName,
                                PersonId = personID

                            };
                            _context.TblPersonName.Add(tblPersonNameObj);
                            _context.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                            // return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                            throw new Exception(ExceptionStringResponse);
                        }

                    }

                    if (reqPersonRegistration != null)
                    {
                        if (reqPersonRegistration.Length > 0)
                        {
                            try
                            {
                                RegistrationDAL.Models.TblPersonRegistration tblPersonRegistrationObj = new RegistrationDAL.Models.TblPersonRegistration()
                                {
                                    PersonId = personID,
                                    PersonRegistrationTypeCodeId = reqPersonRegistration[0].PersonRegistrationTypeCodeId
                                };
                                _registrationContext.TblPersonRegistration.Add(tblPersonRegistrationObj);
                                _registrationContext.SaveChanges();

                                var registrationID = tblPersonRegistrationObj.PersonRegistrationId;

                                var civilRegistration = reqPersonRegistration[0].CivilRegistration;
                                var educationCertificate = reqPersonRegistration[0].EducationCertificate;
                                var personalActivityLicence = reqPersonRegistration[0].PersonalActivityLicence;
                                var residentRegistration = reqPersonRegistration[0].ResidentRegistration;
                                var identityCard = reqPersonRegistration[0].Identitycard;
                                if (birth != null)
                                {
                                    RegistrationDAL.Models.TblBirthCertificate tblBirthCertificate = new RegistrationDAL.Models.TblBirthCertificate
                                    {
                                        BirthDate = birth.BirthDate,
                                        PersonRegistrationId = tblPersonRegistrationObj.PersonRegistrationId
                                    };
                                    _registrationContext.TblBirthCertificate.Add(tblBirthCertificate);
                                    _registrationContext.SaveChanges();
                                }

                                RegistrationDAL.Models.TblCivilRegistration tblCivilRegistrationobj = new RegistrationDAL.Models.TblCivilRegistration()
                                {
                                    PersonRegistrationId = registrationID,
                                    RegistrationDate = DateTime.Now

                                };
                                _registrationContext.TblCivilRegistration.Add(tblCivilRegistrationobj);
                                _registrationContext.SaveChanges();
                                if (identityCard != null)
                                {
                                    RegistrationDAL.Models.TblIdentityCard tblIdentityCardobj = new RegistrationDAL.Models.TblIdentityCard()
                                    {
                                        IdentityNumber = identityCard[0].IdentityNumber,
                                        PersonRegistrationId = registrationID,
                                        ValidityCodeId = identityCard[0].ValidityCodeId
                                    };
                                    _registrationContext.Add(tblIdentityCardobj);
                                    _registrationContext.SaveChanges();
                                }
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                //return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }
                        }
                    }
                    if (reqPersonReferalLink != null)
                    {
                        if (reqPersonReferalLink.Length > 0)
                        {
                            try
                            {
                                TblPersonReferalLink tblPersonReferalLink = new TblPersonReferalLink
                                {
                                    PersonId = personID,
                                    ReferalId = reqPersonReferalLink[0].ReferalID
                                };
                                _context.TblPersonReferalLink.Add(tblPersonReferalLink);
                                _context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                // return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }
                        }
                    }

                    if (reqCountryList != null && reqCountryList.Length > 0)
                    {
                        foreach (var country in reqCountryList)
                        {
                            try
                            {

                                Party_Dll.Models.TblCountry countryObj = new Party_Dll.Models.TblCountry
                                {
                                    CountryCodeId = country.CountryCodeID.Value,
                                    Capital = country.Capital,
                                    FundAssetId = country.FundAssetID,
                                    NationalityId = country.NationalityId,
                                    PersonId = personID
                                };

                                _context.TblCountry.Add(countryObj);
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

                    if (reqHouseholdRelationshipList != null && reqHouseholdRelationshipList.Length > 0)
                    {
                        foreach (var HouseholdRelationship in reqHouseholdRelationshipList)
                        {
                            try
                            {
                                TblHouseholdRelationship houseHoldObj = new TblHouseholdRelationship
                                {
                                    PartyRoleRelationshipId = partyRoleRelationshipID.Value,
                                    HomeOwnerShipCodeId = HouseholdRelationship.HomeOwnerShipCodeID,
                                    DependentAdultCount = HouseholdRelationship.DependentAdultCount,
                                    DependantChildCount = HouseholdRelationship.DependentChildCount,
                                    Family = HouseholdRelationship.Family,
                                    Name = HouseholdRelationship.Name,
                                    CrossMonthlyIncomeId = HouseholdRelationship.CrossMonthlyIncomeID
                                };

                                _context.TblHouseholdRelationship.Add(houseHoldObj);
                                _context.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                                //  return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                                throw new Exception(ExceptionStringResponse);
                            }

                        }

                    }

                    var Person = _context.TblPerson.Where(cl => cl.PersonId == personID).ToList();
                    _errLog += "found Person";
                    return Person;
                    //return getFunctions.ReturnCleanData(Person, mode);
                }
                else
                {
                    /*   return new HttpResponseMessage
                       {
                           Content = new StringContent(JsonConvert.SerializeObject("Cannot pass PersonId for new person"))
                       };*/
                    throw new Exception("Error: Cannot pass PersonId for new person");
                }
            }
            catch (Exception ex)
            {

                /*   return new HttpResponseMessage
                   {
                       Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                   };
                */
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> RequestPostPartyRoleInAgreement(string requestBody, string mode = null, string reqType = "POST")
        {
            string _errLog = "RequestPostPartyRoleInAgreement";
            try
            {
                // old way dynamic obj
                dynamic PartyRoleInAgreementInformation = JsonConvert.DeserializeObject(requestBody);
                // new way static obj
                // will have to loop through var as we can have more than one details
                var PartyRoleInAgreementobj = JsonConvert.DeserializeObject<List<PartyRoleInAgreementArrayObject>>(requestBody);
                var PartyRoleInAgreementDetail = PartyRoleInAgreementobj[0]?.PartyRoleInAgreementDetail[0];


                var PartyRoleInAgreementId = (PartyRoleInAgreementDetail?.PartyRoleInAgreementId == null) || (PartyRoleInAgreementDetail?.PartyRoleInAgreementId == 0) ? -1 : PartyRoleInAgreementDetail?.PartyRoleInAgreementId;
                if (PartyRoleInAgreementId == -1)
                {
                    try
                    {
                        TblPartyRoleInAgreement PartyRoleInAgreementObj = new TblPartyRoleInAgreement
                        {
                            AgreementId = PartyRoleInAgreementDetail.AgreementId,
                            PartyRoleinAgreementTypeCodeId = PartyRoleInAgreementDetail.PartyRoleinAgreementTypeCodeId,
                            PartyId = PartyRoleInAgreementDetail.PartyId
                        };

                        _context.TblPartyRoleInAgreement.Add(PartyRoleInAgreementObj);
                        _context.SaveChanges();
                        var PartyRoleInAgreementID = PartyRoleInAgreementObj.PartyRoleInAgreementId;

                        var PartyRoleInAgreement = await _context.TblPartyRoleInAgreement.Where(cl => cl.PartyRoleInAgreementId == PartyRoleInAgreementID).ToListAsync();
                        _errLog += "found PartyRoleInAgreement";


                        return new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject(PartyRoleInAgreement, Formatting.Indented))
                        };
                    }
                    catch (Exception ex)
                    {
                        string ExceptionStringResponse = ExceptionCatcher.HandleException(ex);
                        return HttpResponseFormatter.ResponseMessage(ExceptionStringResponse);
                    }


                }
                else
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Cannot pass PartyRoleInAgreementId for new PartyRoleInAgreement"))
                    };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                };
            }
        }


        public async Task<HttpResponseMessage> RequestPostPrincipleMember(PrincipleMemberDetails principleMember)
        {
        //    using var transaction = _context.Database.BeginTransaction();
            try {

                if (principleMember.AgreementKindCodeId > 0)
                {

                    int personID = 0;
                    int partyID = 0;
                    int agreementID = 0;
                    int personRegistrationId = 0;

                    bool personSavedorUpdated = false;
                    bool personHasNoAgreementOfThisType = false; 
                    var PirncipleMemberpartyroleInAgreementCodeId = _context.TblLtPartyRoleinAgreementTypeCodeList.First(x => x.PartyRoleinAgreementTypeCode.ToUpper() == "PRINCIPLE").PartyRoleinAgreementTypeCodeId;

                    if (principleMember.PartyId <= 0 && principleMember.PersonId <= 0)
                    {
                        //Id number check
                        var idNumbercheck = _registrationContext.TblIdentityCard.FirstOrDefault(x => x.IdentityNumber == principleMember.IdNumber);

                        if (idNumbercheck == null)
                        {
                            int genderCodeId = _context.TblLtGenderCodeList.FirstOrDefault(x => x.GenderCode.ToUpper() == principleMember.GenderCode.ToUpper()).GenderCodeId;
                            TblPerson personObj = new TblPerson
                            {
                                GenderCodeId = genderCodeId,
                            };

                            _context.TblPerson.Add(personObj);
                            _context.SaveChanges();
                            personID = personObj.PersonId;


                            int privatePartyTypeId = _context.TblLtPartyTypeCodeList.FirstOrDefault(x => x.PartyTypeCode.ToUpper() == "PVT").PartyTypeCodeId;
                            TblParty partyObj = new TblParty
                            {
                                PartyTypeCodeId = privatePartyTypeId
                            };
                            _context.TblParty.Add(partyObj);
                            _context.SaveChanges();
                            partyID = partyObj.PartyId;


                            TblPersonDetail tblLtPersonDetail = new TblPersonDetail
                            {
                                PartyId = partyID,
                                PersonId = personID,
                                PersonDetailCodeId = 1,
                                //PartyRoleRelationshipId = partyRoleRelationshipID
                            };
                            _context.TblPersonDetail.Add(tblLtPersonDetail);
                            _context.SaveChanges();

                            string[] fullNameSplit = principleMember.FullName.Split(" ");
                            string middleNames = "";
                            for (var i = 1; i < fullNameSplit.Length; i++)
                            {
                                middleNames += " " + fullNameSplit[i];

                            }

                            var prefixTitleCodeId = _context.TblLtPrefixTitleCodeList.FirstOrDefault(x => x.PrefixTitleCode.ToUpper() == principleMember.TitleCode.ToUpper()).PrefixTitleCodeId;
                            TblPersonName tblPersonNameObj = new TblPersonName
                            {
                                GivenName = fullNameSplit[0],
                                MiddleName = middleNames,
                                PrefixTitleCodeId = prefixTitleCodeId,
                                Surname = principleMember.Surname,
                                //Suffix = reqPersonName?.Suffix,
                                //PersonNameUsageCodeId = reqPersonName.PersonNameUsageCodeId,
                                Initials = principleMember.Initials,
                                PreferredName = principleMember.PreferedName,
                                PersonId = personID

                            };
                            _context.TblPersonName.Add(tblPersonNameObj);
                            _context.SaveChanges();
                            var CurrentpersonRegistrationTypeCodeId = _registrationContext.TblLtPersonRegistrationTypeCodeList.FirstOrDefault(x => x.PersonRegistrationTypeCode.ToUpper() == principleMember.IdTypeCode.ToUpper()).PersonRegistrationTypeCodeId;
                            RegistrationDAL.Models.TblPersonRegistration tblPersonRegistrationObj = new RegistrationDAL.Models.TblPersonRegistration()
                            {
                                PersonId = personID,
                                PersonRegistrationTypeCodeId = CurrentpersonRegistrationTypeCodeId
                            };
                            _registrationContext.TblPersonRegistration.Add(tblPersonRegistrationObj);
                            _registrationContext.SaveChanges();
                            personRegistrationId = tblPersonRegistrationObj.PersonRegistrationId;


                            //var validityCodeId = _context.TblLtValidityCodeList.FirstOrDefault(x => x.ValidityCode.ToUpper() == "VALID").ValidityCodeId;
                            //RegistrationDAL.Models.TblIdentityCard tblIdentityCardobj = new RegistrationDAL.Models.TblIdentityCard()
                            //{
                            //    IdentityNumber = principleMember.IdNumber,
                            //    PersonRegistrationId = personRegistrationId,
                            //    ValidityCodeId = validityCodeId
                            //};
                            //_registrationContext.TblIdentityCard.Add(tblIdentityCardobj);
                            //_registrationContext.SaveChanges();


                            RegistrationDAL.Models.TblBirthCertificate tblBirthCertificate = new RegistrationDAL.Models.TblBirthCertificate
                            {
                                BirthDate = principleMember.DateOfBirth,
                                PersonRegistrationId = personRegistrationId
                            };
                            _registrationContext.TblBirthCertificate.Add(tblBirthCertificate);
                            _registrationContext.SaveChanges();


                            var currentCountrycodeId = _context.TblLtCountryCodeList.FirstOrDefault(x => x.CountryCode.ToUpper() == principleMember.NationalityCode.ToUpper()).CountryCodeId;
                            var currentNationalityId = _context.TblLtNationality.FirstOrDefault(x => x.NationalityCode.ToUpper() == principleMember.NationalityCode.ToUpper()).NationalityId;
                            Party_Dll.Models.TblCountry countryObj = new Party_Dll.Models.TblCountry
                            {
                                CountryCodeId = currentCountrycodeId,
                                //Capital = country.Capital,
                                //FundAssetId = country.FundAssetID,
                                NationalityId = currentNationalityId,
                                PersonId = personID
                            };
                            _context.TblCountry.Add(countryObj);
                            _context.SaveChanges();
                            personSavedorUpdated = true;
                        }
                        else
                        {
                          //  await transaction.RollbackAsync();
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: Duplicate ID Number. User with provided ID Number already exists", Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }
                    }

                    else if (principleMember.PartyId > 0 && principleMember.PersonId > 0)
                    {

                        //Check if thos person has this agreement type

                        var currentPersonRoleInAgreements = _context.TblPartyRoleInAgreement.Where(x => x.PartyId == principleMember.PartyId && x.PartyRoleinAgreementTypeCodeId == PirncipleMemberpartyroleInAgreementCodeId).ToList(); 

                        if(currentPersonRoleInAgreements.Count > 0)
                        {
                            foreach(var agreement in currentPersonRoleInAgreements)
                            {
                                var currentAgreement = _agreementcontext.TblAgreement.FirstOrDefault(x => x.AgreementId == agreement.AgreementId); 

                                if(currentAgreement != null)
                                {
                                    if (currentAgreement.AgreementKindCodeListId == principleMember.AgreementKindCodeId) 
                                    {
                                        personHasNoAgreementOfThisType = true;
                                        break; 
                                    }
                                }
                            }
                        }

                        if (!personHasNoAgreementOfThisType)
                        {
                            var genderCode = _context.TblLtGenderCodeList.FirstOrDefault(x => x.GenderCode == principleMember.GenderCode);

                            if (genderCode != null)
                            {
                                personID = principleMember.PersonId;
                                partyID = principleMember.PartyId;

                                var personToUpdate = _context.TblPerson.FirstOrDefault(x => x.PersonId == principleMember.PersonId);
                                personToUpdate.GenderCodeId = genderCode.GenderCodeId;
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

                                personSavedorUpdated = true;
                            }
                            else
                            {
                            //    await transaction.RollbackAsync();
                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject("Error: Invaild Gender Code", Formatting.Indented)),
                                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                                };
                            }
                        }
                        else
                        {
                          //  await transaction.RollbackAsync();
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: Person already has agreement of same kind", Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }
                    }

                    if (personSavedorUpdated)
                    {

                        var agreementURL = Environment.GetEnvironmentVariable("AgreementMsURL");
                        var AgreementObj = new Agreement
                        {
                            AgreementKindCodeListID = principleMember.AgreementKindCodeId,
                            Name = "Insurance Agreement",
                            StatusCodeListID = int.Parse(Environment.GetEnvironmentVariable("StatusCodeListId")),
                            StatusReasonCodeListID = int.Parse(Environment.GetEnvironmentVariable("StatusReasonCodeListId")),
                            TextQualificationCodeListID = int.Parse(Environment.GetEnvironmentVariable("TextQualificationCodeListId")),
                            Version = Environment.GetEnvironmentVariable("Version"),
                            //AgreementID = agreementId
                        };

                        List<Agreement> aggreementlist = new List<Agreement>();
                        aggreementlist.Add(AgreementObj);
                        var arrayagreementList = new List<AgreementList>();
                        AgreementList agreementList = new AgreementList
                        {
                            AgreementDetail = aggreementlist.ToArray()
                        };
                        arrayagreementList.Add(agreementList);
                        var jsonAgreementObj = JsonConvert.SerializeObject(arrayagreementList);
                        var data = new StringContent(jsonAgreementObj, Encoding.UTF8, "application/json");
                        var client = new HttpClient();
                        var httpRespMsg = await client.PostAsync(agreementURL, data);
                        if (httpRespMsg.IsSuccessStatusCode)
                        {
                            string ResponseBody = await httpRespMsg.Content.ReadAsStringAsync();
                            dynamic AgreementResponse = JsonConvert.DeserializeObject(ResponseBody);
                            if (AgreementResponse.AgreementDetail[0].AgreementId > 0)
                            {
                                agreementID = AgreementResponse.AgreementDetail[0].AgreementId;

                                var clientPartyroleCodeId = _roleAndRelationshipContext.TblLtPartyRoleTypeCodeList.First(x => x.PartyRoleTypeCode.ToUpper() == "PRA").PartyRoleTypeCodeId;
                                var principleMemberRoleId = _roleAndRelationshipContext.TblRole.FirstOrDefault(x => x.Name.ToUpper() == "PRINCIPLE").RoleId;
                                TblPartyRole tblPartyRoleObj = new TblPartyRole
                                {
                                    RoleId = principleMemberRoleId,
                                    PartyRoleTypeCodeId = clientPartyroleCodeId,
                                    PartyId = partyID
                                };
                                _roleAndRelationshipContext.TblPartyRole.Add(tblPartyRoleObj);
                                _roleAndRelationshipContext.SaveChanges();
                                var principleMemberPartyRoleId = tblPartyRoleObj.PartyRoleId;

                                TblPartyRoleInAgreement tblPartyRoleInAgreement = new TblPartyRoleInAgreement
                                {
                                    PartyId = partyID,
                                    PartyRoleinAgreementTypeCodeId = PirncipleMemberpartyroleInAgreementCodeId,
                                    AgreementId = agreementID,
                                    PartyRoleId = principleMemberPartyRoleId
                                };
                                _context.TblPartyRoleInAgreement.Add(tblPartyRoleInAgreement);
                                _context.SaveChanges();
                            }
                        }
                        else
                        {

                            throw new Exception("Error: Failed to add principle memeber Agreement");
                        }

                        var contactAndPlaceMSURL = Environment.GetEnvironmentVariable("ContactAndPlaceMSURL");
                        var getContactClient = new HttpClient();
                        var httpGetContactRespMsg = getContactClient.GetAsync(contactAndPlaceMSURL + "/" + personID);
                        var getContactResult = httpGetContactRespMsg.Result;
                        if (getContactResult.IsSuccessStatusCode)
                        {
                            string contactResponseBody = await getContactResult.Content.ReadAsStringAsync();

                            RootRoleObject contactAndPlaceObj = new RootRoleObject();
                            contactAndPlaceObj = JsonConvert.DeserializeObject<RootRoleObject>(contactResponseBody);

                            if (contactAndPlaceObj.rolePersonPartyContactDetails?.Count > 0)
                            {
                                //update contact details

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



                                prepObj.rolePersonPartyContactDetails[0].PersonPartyContactRoleId = contactAndPlaceObj.rolePersonPartyContactDetails[0].PersonPartyContactRoleId;

                                List<RootRoleObject> requestPutObj = new List<RootRoleObject>();
                                requestPutObj.Add(prepObj);

                                var jsonContactPutObj = JsonConvert.SerializeObject(requestPutObj);
                                var contactPutData = new StringContent(jsonContactPutObj, Encoding.UTF8, "application/json");

                                var contactClient = new HttpClient();
                                var httpContactPutRespMsg = await contactClient.PutAsync(contactAndPlaceMSURL, contactPutData);
                                if (httpContactPutRespMsg.IsSuccessStatusCode)
                                {
                                    var getResponse = await getFunctions.RequestGetPrincipleMember(principleMember.PersonId.ToString(), agreementID.ToString());
                                    string getResponseBody = await getResponse.Content.ReadAsStringAsync();
                                    PrincipleMemberDetails responseObj = JsonConvert.DeserializeObject<PrincipleMemberDetails>(getResponseBody);

                                    PostPrincipleMemberResponse postResponse = new PostPrincipleMemberResponse();
                                    postResponse.principleMemberDetails = responseObj;

                                 //   await transaction.CommitAsync();
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
                                    };
                                }
                                else
                                {
                                    string errorBody = await httpContactPutRespMsg.Content.ReadAsStringAsync();

                                    var getResponse = await getFunctions.RequestGetPrincipleMember(principleMember.PersonId.ToString(), agreementID.ToString());
                                    string getResponseBody = await getResponse.Content.ReadAsStringAsync();

                                    PostPrincipleMemberResponse putResponse = new PostPrincipleMemberResponse();
                                    PrincipleMemberDetails responseObj = JsonConvert.DeserializeObject<PrincipleMemberDetails>(getResponseBody);
                                    putResponse.principleMemberDetails = responseObj;
                                    putResponse.ErrorList = new List<string>();
                                    putResponse.ErrorList.Add(errorBody);

                                //    await transaction.CommitAsync();
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject(putResponse, Formatting.Indented))
                                    };
                                }



                            }
                            else
                            {
                                Emailcontact principleMemberEmail = new Emailcontact();
                                if (principleMember.Emailaddress != "")
                                {
                                    principleMemberEmail.EmailAddress = principleMember.Emailaddress;
                                }
                                else
                                {
                                    principleMemberEmail = null;
                                }

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
                                        TelephoneNetworkTypeCodeId = null
                                    };

                                    principleMemberTelephoneList.Add(currentTelepohne);
                                }

                                RootRoleObject prepObj = new RootRoleObject();
                                prepObj.rolePersonPartyContactDetails = new List<RolePersonPartyContactDetails>();
                                prepObj.rolePersonPartyContactDetails.Add(new RolePersonPartyContactDetails
                                {
                                    emailContact = principleMemberEmail,
                                    telephoneNumberList = principleMemberTelephoneList.ToArray(),
                                    PartyId = partyID,
                                    PersonId = personID
                                });

                                List<RootRoleObject> requestObj = new List<RootRoleObject>();
                                requestObj.Add(prepObj);


                                var jsonContactObj = JsonConvert.SerializeObject(requestObj);
                                var contactData = new StringContent(jsonContactObj, Encoding.UTF8, "application/json");
                                var postContactClient = new HttpClient();
                                var httpPostContactRespMsg = await postContactClient.PostAsync(contactAndPlaceMSURL, contactData);
                                if (httpPostContactRespMsg.IsSuccessStatusCode)
                                {
                                    var getResponse = await getFunctions.RequestGetPrincipleMember(personID.ToString(), agreementID.ToString());
                                    string getResponseBody = await getResponse.Content.ReadAsStringAsync();
                                    PrincipleMemberDetails responseObj = JsonConvert.DeserializeObject<PrincipleMemberDetails>(getResponseBody);

                                    PostPrincipleMemberResponse postResponse = new PostPrincipleMemberResponse();
                                    postResponse.principleMemberDetails = responseObj;

                                 //   await transaction.CommitAsync();
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
                                    };
                                }
                                else
                                {
                                    string errorBody = await httpPostContactRespMsg.Content.ReadAsStringAsync();

                                    var getResponse = await getFunctions.RequestGetPrincipleMember(personID.ToString(), agreementID.ToString());
                                    string getResponseBody = await getResponse.Content.ReadAsStringAsync();

                                    PostPrincipleMemberResponse postResponse = new PostPrincipleMemberResponse();
                                    PrincipleMemberDetails responseObj = JsonConvert.DeserializeObject<PrincipleMemberDetails>(getResponseBody);
                                    postResponse.principleMemberDetails = responseObj;
                                    postResponse.ErrorList = new List<string>();
                                    postResponse.ErrorList.Add(errorBody);

                                 //   await transaction.CommitAsync();
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
                                    };
                                }
                            }


                        }
                        else
                        {
                           // await transaction.RollbackAsync();
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: Failed to Get Principle Member contact Details", Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }
                    }
                    else
                    {
                       // await transaction.RollbackAsync();
                        return new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject("Error: Failed to Create/Update person", Formatting.Indented)),
                            StatusCode = System.Net.HttpStatusCode.InternalServerError
                        };
                    }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: Please provide AgreementKindCodeId for Principle Member", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HttpResponseMessage> RequestPostContactPerson(ContactPersonDetails contactPerson)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var PMPartyRoleInAgreementCode = Environment.GetEnvironmentVariable("PMPartyRoleinAgreementTypeCode");
                var CPPartyRoleinAgreementTypeCode = Environment.GetEnvironmentVariable("CPPartyRoleinAgreementTypeCode"); 
                //principle member to link check
                var principleMemberPartyId = _context.TblPersonDetail.FirstOrDefault(x => x.PersonId == contactPerson.PrincipleMemberPersonId)?.PartyId;

                if (principleMemberPartyId != null)
                {
                    var principleMemberAgreement = _context.TblPartyRoleInAgreement.Include(p => p.PartyRoleinAgreementTypeCode).FirstOrDefault(x => x.PartyId == principleMemberPartyId && x.PartyRoleinAgreementTypeCode.PartyRoleinAgreementTypeCode.ToUpper() == PMPartyRoleInAgreementCode);

                    if (principleMemberAgreement != null)
                    {
                        if (principleMemberAgreement.AgreementId == contactPerson.AgreementId)
                        {
                            int personID = 0;
                            int contactPersonPartyId = 0;
                            int agreementID = 0;
                            int personRegistrationId = 0;
                            bool personSavedorUpdated = false;

                            if (contactPerson.PartyId <= 0 && contactPerson.PersonId <= 0)
                            {
                                //Id number check
                                var idNumbercheck = _registrationContext.TblIdentityCard.FirstOrDefault(x => x.IdentityNumber == contactPerson.IdNumber);

                                if (idNumbercheck == null)
                                {
                                    int genderCodeId = _context.TblLtGenderCodeList.FirstOrDefault(x => x.GenderCode.ToUpper() == contactPerson.GenderCode.ToUpper()).GenderCodeId;
                                    TblPerson personObj = new TblPerson
                                    {
                                        GenderCodeId = genderCodeId,
                                    };

                                    _context.TblPerson.Add(personObj);
                                    _context.SaveChanges();
                                    personID = personObj.PersonId;


                                    int privatePartyTypeId = _context.TblLtPartyTypeCodeList.FirstOrDefault(x => x.PartyTypeCode.ToUpper() == "PVT").PartyTypeCodeId;
                                    TblParty partyObj = new TblParty
                                    {
                                        PartyTypeCodeId = privatePartyTypeId
                                    };
                                    _context.TblParty.Add(partyObj);
                                    _context.SaveChanges();
                                    contactPersonPartyId = partyObj.PartyId;


                                    TblPersonDetail tblLtPersonDetail = new TblPersonDetail
                                    {
                                        PartyId = contactPersonPartyId,
                                        PersonId = personID,
                                        PersonDetailCodeId = 1,
                                        //PartyRoleRelationshipId = partyRoleRelationshipID
                                    };
                                    _context.TblPersonDetail.Add(tblLtPersonDetail);
                                    _context.SaveChanges();

                                    string[] fullNameSplit = contactPerson.FullName.Split(" ");
                                    string middleNames = "";
                                    for (var i = 1; i < fullNameSplit.Length; i++)
                                    {
                                        middleNames += " " + fullNameSplit[i];

                                    }

                                    var prefixTitleCodeId = _context.TblLtPrefixTitleCodeList.FirstOrDefault(x => x.PrefixTitleCode.ToUpper() == contactPerson.TitleCode.ToUpper()).PrefixTitleCodeId;
                                    TblPersonName tblPersonNameObj = new TblPersonName
                                    {
                                        GivenName = fullNameSplit[0],
                                        MiddleName = middleNames,
                                        PrefixTitleCodeId = prefixTitleCodeId,
                                        Surname = contactPerson.Surname,
                                        //Suffix = reqPersonName?.Suffix,
                                        //PersonNameUsageCodeId = reqPersonName.PersonNameUsageCodeId,
                                        Initials = contactPerson.Initials,
                                        PreferredName = contactPerson.PreferedName,
                                        PersonId = personID

                                    };
                                    _context.TblPersonName.Add(tblPersonNameObj);
                                    _context.SaveChanges();

                                    var CurrentpersonRegistrationTypeCodeId = _registrationContext.TblLtPersonRegistrationTypeCodeList.FirstOrDefault(x => x.PersonRegistrationTypeCode.ToUpper() == contactPerson.IdTypeCode.ToUpper()).PersonRegistrationTypeCodeId;
                                    RegistrationDAL.Models.TblPersonRegistration tblPersonRegistrationObj = new RegistrationDAL.Models.TblPersonRegistration()
                                    {
                                        PersonId = personID,
                                        PersonRegistrationTypeCodeId = CurrentpersonRegistrationTypeCodeId
                                    };
                                    _registrationContext.TblPersonRegistration.Add(tblPersonRegistrationObj);
                                    _registrationContext.SaveChanges();
                                    personRegistrationId = tblPersonRegistrationObj.PersonRegistrationId;


                                    //var validityCodeId = _context.TblLtValidityCodeList.FirstOrDefault(x => x.ValidityCode.ToUpper() == "VALID").ValidityCodeId;
                                    //RegistrationDAL.Models.TblIdentityCard tblIdentityCardobj = new RegistrationDAL.Models.TblIdentityCard()
                                    //{
                                    //    IdentityNumber = contactPerson.IdNumber,
                                    //    PersonRegistrationId = personRegistrationId,
                                    //    ValidityCodeId = validityCodeId
                                    //};
                                    //_registrationContext.TblIdentityCard.Add(tblIdentityCardobj);
                                    //_registrationContext.SaveChanges();


                                    RegistrationDAL.Models.TblBirthCertificate tblBirthCertificate = new RegistrationDAL.Models.TblBirthCertificate
                                    {
                                        BirthDate = contactPerson.DateOfBirth,
                                        PersonRegistrationId = personRegistrationId
                                    };
                                    _registrationContext.TblBirthCertificate.Add(tblBirthCertificate);
                                    _registrationContext.SaveChanges();


                                    var currentCountrycodeId = _context.TblLtCountryCodeList.FirstOrDefault(x => x.CountryCode.ToUpper() == contactPerson.NationalityCode.ToUpper()).CountryCodeId;
                                    var currentNationalityId = _context.TblLtNationality.FirstOrDefault(x => x.NationalityCode.ToUpper() == contactPerson.NationalityCode.ToUpper()).NationalityId;
                                    Party_Dll.Models.TblCountry countryObj = new Party_Dll.Models.TblCountry
                                    {
                                        CountryCodeId = currentCountrycodeId,
                                        //Capital = country.Capital,
                                        //FundAssetId = country.FundAssetID,
                                        NationalityId = currentNationalityId,
                                        PersonId = personID
                                    };
                                    _context.TblCountry.Add(countryObj);
                                    _context.SaveChanges();
                                    personSavedorUpdated = true;
                                }
                                else
                                {
                                    await transaction.RollbackAsync();
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject("Error: Duplicate ID Number. User with provided ID Number already exists", Formatting.Indented)),
                                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                                    };
                                }

                            }
                            else if (contactPerson.PartyId > 0 && contactPerson.PersonId > 0)
                            {
                                if (contactPerson.PersonId != contactPerson.PrincipleMemberPersonId)
                                {
                                    var existingProxy = _context.TblPartyRoleInAgreement.Include(p => p.PartyRoleinAgreementTypeCode).FirstOrDefault(x => x.PartyId == contactPerson.PartyId && x.AgreementId == contactPerson.AgreementId && x.PartyRoleinAgreementTypeCode.PartyRoleinAgreementTypeCode.ToUpper() == CPPartyRoleinAgreementTypeCode);

                                    if (existingProxy == null)
                                    {
                                        var genderCode = _context.TblLtGenderCodeList.FirstOrDefault(x => x.GenderCode == contactPerson.GenderCode);

                                        if (genderCode != null)
                                        {
                                            personID = contactPerson.PersonId;
                                            contactPersonPartyId = contactPerson.PartyId;

                                            var personToUpdate = _context.TblPerson.FirstOrDefault(x => x.PersonId == contactPerson.PersonId);
                                            personToUpdate.GenderCodeId = genderCode.GenderCodeId;
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

                                            personSavedorUpdated = true;
                                        }
                                        else
                                        {
                                            await transaction.RollbackAsync();
                                            return new HttpResponseMessage
                                            {
                                                Content = new StringContent(JsonConvert.SerializeObject("Error: GenderCodeId not found for code " + contactPerson.GenderCode, Formatting.Indented)),
                                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                                            };
                                        }
                                    }
                                    else
                                    {
                                        await transaction.RollbackAsync();
                                        return new HttpResponseMessage
                                        {
                                            Content = new StringContent(JsonConvert.SerializeObject("Error: provided person is already a contact person for this agreement", Formatting.Indented)),
                                            StatusCode = System.Net.HttpStatusCode.InternalServerError
                                        };
                                    }
                                }
                                else
                                {
                                    await transaction.RollbackAsync();
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject("Error: Contact Person and Principal member cannot be the same. Please capture new Contact person information.", Formatting.Indented)),
                                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                                    };
                                }
                            }

                            if (personSavedorUpdated)
                            {
                                var contactPersonRelationshipCode = contactPerson.PartyRoleinRelationShipTypeCode;
                                bool contactPerosnRelationStored = false;
                                if (contactPersonRelationshipCode.ToUpper() == "SPOUSE")
                                {
                                    var addPrincipleMembersspouse = await postPrincipleMemberSpouse(contactPersonPartyId, contactPerson.AgreementId);

                                    if (addPrincipleMembersspouse.IsSuccessStatusCode)
                                    {
                                        contactPerosnRelationStored = true;
                                    }
                                }

                                //family members
                                else if (contactPersonRelationshipCode.ToUpper() == "CHILD" || contactPersonRelationshipCode.ToUpper() == "SIBLING" || contactPersonRelationshipCode.ToUpper() == "GC"
                                    || contactPersonRelationshipCode.ToUpper() == "GP" || contactPersonRelationshipCode.ToUpper() == "COUSIN" || contactPersonRelationshipCode.ToUpper() == "PARENT")
                                {
                                    var addPrincipleMembersFamilyMember = await PostPrincipleMembersFamilyMember(contactPersonPartyId, contactPerson.AgreementId, contactPersonRelationshipCode);

                                    if (addPrincipleMembersFamilyMember.IsSuccessStatusCode)
                                    {
                                        contactPerosnRelationStored = true;
                                    }
                                }
                                else
                                {
                                    var addPrincipleMembersOther = await PostPrincipleMemberOthercontact(contactPersonPartyId, contactPerson.AgreementId, contactPersonRelationshipCode);

                                    if (addPrincipleMembersOther.IsSuccessStatusCode)
                                    {
                                        contactPerosnRelationStored = true;
                                    }
                                }


                                if (contactPerosnRelationStored)
                                {
                                    var contactAndPlaceMSURL = Environment.GetEnvironmentVariable("ContactAndPlaceMSURL");
                                    var getContactClient = new HttpClient();
                                    var httpGetContactRespMsg = getContactClient.GetAsync(contactAndPlaceMSURL + "/" + personID);
                                    var getContactResult = httpGetContactRespMsg.Result;
                                    if (getContactResult.IsSuccessStatusCode)
                                    {
                                        string contactResponseBody = await getContactResult.Content.ReadAsStringAsync();

                                        RootRoleObject contactAndPlaceObj = new RootRoleObject();
                                        contactAndPlaceObj = JsonConvert.DeserializeObject<RootRoleObject>(contactResponseBody);

                                        if (contactAndPlaceObj.rolePersonPartyContactDetails?.Count > 0)
                                        {
                                            //update contact details

                                            Emailcontact principleMemberEmail = new Emailcontact
                                            {
                                                EmailAddress = contactPerson.Emailaddress,
                                                PkemailContactId = contactPerson.EmailId
                                            };

                                            List<TelephoneNumber> contactPersonTelephoneList = new List<TelephoneNumber>();
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

                                                contactPersonTelephoneList.Add(currentTelepohne);
                                            }

                                            RootRoleObject prepObj = new RootRoleObject();
                                            prepObj.rolePersonPartyContactDetails = new List<RolePersonPartyContactDetails>();
                                            prepObj.rolePersonPartyContactDetails.Add(new RolePersonPartyContactDetails
                                            {
                                                emailContact = principleMemberEmail,
                                                telephoneNumberList = contactPersonTelephoneList.ToArray(),
                                                PartyId = contactPerson.PartyId,
                                                PersonId = contactPerson.PersonId
                                            });



                                            prepObj.rolePersonPartyContactDetails[0].PersonPartyContactRoleId = contactAndPlaceObj.rolePersonPartyContactDetails[0].PersonPartyContactRoleId;

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

                                                ContactPersonResponse postResponse = new ContactPersonResponse();
                                                postResponse.contactPersonDetails = responseObj;

                                                await transaction.CommitAsync();
                                                return new HttpResponseMessage
                                                {
                                                    Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
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

                                                await transaction.CommitAsync();
                                                return new HttpResponseMessage
                                                {
                                                    Content = new StringContent(JsonConvert.SerializeObject(putResponse, Formatting.Indented))
                                                };
                                            }

                                        }
                                        else
                                        {
                                            Emailcontact principleMemberEmail = new Emailcontact();
                                            if (contactPerson.Emailaddress != "")
                                            {
                                                principleMemberEmail.EmailAddress = contactPerson.Emailaddress;
                                            }
                                            else
                                            {
                                                principleMemberEmail = null;
                                            }

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
                                                    TelephoneNetworkTypeCodeId = null
                                                };

                                                principleMemberTelephoneList.Add(currentTelepohne);
                                            }

                                            RootRoleObject prepObj = new RootRoleObject();
                                            prepObj.rolePersonPartyContactDetails = new List<RolePersonPartyContactDetails>();
                                            prepObj.rolePersonPartyContactDetails.Add(new RolePersonPartyContactDetails
                                            {
                                                emailContact = principleMemberEmail,
                                                telephoneNumberList = principleMemberTelephoneList.ToArray(),
                                                PartyId = contactPersonPartyId,
                                                PersonId = personID
                                            });

                                            List<RootRoleObject> requestObj = new List<RootRoleObject>();
                                            requestObj.Add(prepObj);


                                            var jsonContactObj = JsonConvert.SerializeObject(requestObj);
                                            var contactData = new StringContent(jsonContactObj, Encoding.UTF8, "application/json");
                                            var postContactClient = new HttpClient();
                                            var httpPostContactRespMsg = await postContactClient.PostAsync(contactAndPlaceMSURL, contactData);
                                            if (httpPostContactRespMsg.IsSuccessStatusCode)
                                            {
                                                var getResponse = await getFunctions.RequestGetContactPerson(personID.ToString(), contactPerson.AgreementId.ToString());
                                                string getResponseBody = await getResponse.Content.ReadAsStringAsync();
                                                ContactPersonDetails responseObj = JsonConvert.DeserializeObject<ContactPersonDetails>(getResponseBody);

                                                ContactPersonResponse postResponse = new ContactPersonResponse();
                                                postResponse.contactPersonDetails = responseObj;

                                                await transaction.CommitAsync();
                                                return new HttpResponseMessage
                                                {
                                                    Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
                                                };
                                            }
                                            else
                                            {
                                                string errorBody = await httpPostContactRespMsg.Content.ReadAsStringAsync();

                                                var getResponse = await getFunctions.RequestGetContactPerson(personID.ToString(), contactPerson.AgreementId.ToString());
                                                string getResponseBody = await getResponse.Content.ReadAsStringAsync();

                                                ContactPersonResponse postResponse = new ContactPersonResponse();
                                                ContactPersonDetails responseObj = JsonConvert.DeserializeObject<ContactPersonDetails>(getResponseBody);
                                                postResponse.contactPersonDetails = responseObj;
                                                postResponse.ErrorList = new List<string>();
                                                postResponse.ErrorList.Add(errorBody);

                                                await transaction.CommitAsync();
                                                return new HttpResponseMessage
                                                {
                                                    Content = new StringContent(JsonConvert.SerializeObject(postResponse, Formatting.Indented))
                                                };
                                            }
                                        }

                                    }
                                    else
                                    {
                                        await transaction.RollbackAsync();
                                        return new HttpResponseMessage
                                        {
                                            Content = new StringContent(JsonConvert.SerializeObject("Error: Failed to Get Contact Person contact Details", Formatting.Indented)),
                                            StatusCode = System.Net.HttpStatusCode.InternalServerError
                                        };
                                    }
                                }

                                else
                                {
                                    await transaction.RollbackAsync();
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject("Error: Failed to insert contact person Relationship", Formatting.Indented)),
                                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                                    };
                                }
                            }
                            else
                            {
                                await transaction.RollbackAsync();
                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject("Error: Failed to Create/Update person", Formatting.Indented)),
                                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                                };
                            }
                        }
                        else
                        {
                            await transaction.RollbackAsync();
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: Provided AgreementId does not belong to the provided Principle Member", Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        return new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject("Error: Person to link to contact is not a Principle Member", Formatting.Indented)),
                            StatusCode = System.Net.HttpStatusCode.InternalServerError
                        };
                    }
                }
                else
                {
                    await transaction.RollbackAsync();
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: Principle Member to link to contact does not exist", Formatting.Indented)),
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

        public async  Task<HttpResponseMessage> postPrincipleMemberSpouse(int familymemberPartyId, int principleMemberAgreementId)
        {
            try
            {
                var spousePartyRoleInRelationshipCode = _context.TblLtPartyRoleInRelationShipTypeCodeList.FirstOrDefault(x => x.RelationshipDescriptionCode.ToUpper() == "SPOUSE");

                if (spousePartyRoleInRelationshipCode != null)
                {
                    var partyroleRelationshipCode = _context.TblLtPartyRoleRelationShipTypeCodeList.FirstOrDefault(x => x.PartyRoleRelationShipTypeCode.ToUpper() == "CIVIL");


                    if (partyroleRelationshipCode != null)
                    {
                        var roleInAgrementPartyroleTypeCode = _roleAndRelationshipContext.TblLtPartyRoleTypeCodeList.FirstOrDefault(x => x.PartyRoleTypeCode.ToUpper() == "PRA");
                        if (roleInAgrementPartyroleTypeCode != null)
                        {
                            var contactPersonRole = _roleAndRelationshipContext.TblRole.FirstOrDefault(x => x.Name.ToUpper() == "PROXY");

                            if (contactPersonRole != null)
                            {
                                var partyroleInAgreementCode = _context.TblLtPartyRoleinAgreementTypeCodeList.First(x => x.PartyRoleinAgreementTypeCode.ToUpper() == "PMPROXY");

                                if (partyroleInAgreementCode != null)
                                {
                                    TblPartyRole tblPartyRoleObj = new TblPartyRole
                                    {
                                        RoleId = contactPersonRole.RoleId,
                                        PartyRoleTypeCodeId = roleInAgrementPartyroleTypeCode.PartyRoleTypeCodeId,
                                        PartyId = familymemberPartyId
                                    };
                                    await _roleAndRelationshipContext.TblPartyRole.AddAsync(tblPartyRoleObj);
                                    await _roleAndRelationshipContext.SaveChangesAsync();
                                    var contactPersonPartyRoleId = tblPartyRoleObj.PartyRoleId;


                                    TblPartyRoleInAgreement tblPartyRoleInAgreementObj = new TblPartyRoleInAgreement
                                    {
                                        AgreementId = principleMemberAgreementId, //linking to principle member
                                        PartyRoleinAgreementTypeCodeId = partyroleInAgreementCode.PartyRoleinAgreementTypeCodeId,
                                        PartyId = familymemberPartyId,
                                        PartyRoleId = contactPersonPartyRoleId
                                    };
                                    await _context.TblPartyRoleInAgreement.AddAsync(tblPartyRoleInAgreementObj);
                                    await _context.SaveChangesAsync();


                                    TblPartyRoleInRelationship tblPartyRoleInRelationshipObj = new TblPartyRoleInRelationship
                                    {
                                        PartyRoleInRelationshipTypeCodeId = spousePartyRoleInRelationshipCode.PartyRoleinRelationShipTypeCodeId,
                                        PartyRoleId = contactPersonPartyRoleId
                                    };
                                    await _context.TblPartyRoleInRelationship.AddAsync(tblPartyRoleInRelationshipObj);
                                    await _context.SaveChangesAsync();
                                    var contactPersonPartyRoleInRelationshipId = tblPartyRoleInRelationshipObj.PartyRoleinRelationshipId;

                                    Party_Dll.Models.TblPartyRoleRelationship tblPartyRoleRelationShipObj = new Party_Dll.Models.TblPartyRoleRelationship
                                    {
                                        PartyRoleRelationShipTypeCodeId = partyroleRelationshipCode.PartyRoleRelationShipTypeCodeId,
                                        Description = "Principle Member Spouse",
                                        AgreementId = principleMemberAgreementId
                                    };
                                    await _context.TblPartyRoleRelationship.AddAsync(tblPartyRoleRelationShipObj);
                                    await _context.SaveChangesAsync();
                                    var contactPersonPartyRoleRelationshipId = tblPartyRoleRelationShipObj.PartyRoleRelationshipId;


                                    var civilRegistrationCode = _context.TblLtCivilRelationNatureCodeList.FirstOrDefault(x => x.CivilRelationNatureCode.ToUpper() == "UNSPESIFIED");

                                    if (civilRegistrationCode != null)
                                    {
                                        TblSpouse tblSpouseObj = new TblSpouse
                                        {
                                            PartyRoleinRerlationShipId = contactPersonPartyRoleInRelationshipId,
                                            CivilRelationNatureCodeId = civilRegistrationCode.CivilRelationNatureCodeId
                                        };
                                        await _context.TblSpouse.AddAsync(tblSpouseObj);
                                        await _context.SaveChangesAsync();
                                        var contactPersonSpouseId = tblSpouseObj.SpouseId;

                                        var civilStatusCode = _context.TblLtCivilStatusCodeList.FirstOrDefault(x => x.CivilStatusCode.ToUpper() == "MARRIED");

                                        if (civilStatusCode != null)
                                        {
                                            TblCivilRelationShip tblCivilRelationShipObj = new TblCivilRelationShip
                                            {
                                                PartyRoleRelationshipId = contactPersonPartyRoleRelationshipId,
                                                CivilStatusCodeId = civilStatusCode.CivilStatusCodeId,
                                                Name = "COP",
                                                SpouseId = contactPersonSpouseId
                                            };
                                            await _context.TblCivilRelationShip.AddAsync(tblCivilRelationShipObj);
                                            await _context.SaveChangesAsync();

                                            return new HttpResponseMessage
                                            {
                                                Content = new StringContent(JsonConvert.SerializeObject(true, Formatting.Indented)),
                                            };

                                        }
                                        else
                                        {

                                            return new HttpResponseMessage
                                            {
                                                Content = new StringContent(JsonConvert.SerializeObject("Error: CivilStatusCodeId not found for code MARRIED", Formatting.Indented)),
                                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                                            };
                                        }
                                    }
                                    else
                                    {
                                        return new HttpResponseMessage
                                        {
                                            Content = new StringContent(JsonConvert.SerializeObject("Error: CivilRelationNatureCodeId not found for code WIFE", Formatting.Indented)),
                                            StatusCode = System.Net.HttpStatusCode.InternalServerError
                                        };
                                    }
                                }
                                else
                                {
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject("Error: PartyroleInAgreementCodeId not found for name PMPROXY", Formatting.Indented)),
                                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                                    };
                                }
                            }
                            else
                            {
                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject("Error: RoleId not found for name PROXY", Formatting.Indented)),
                                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                                };
                            }
                        }
                        else
                        {
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: PartyRoleTypeCodeId not found for code PRA", Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }
                    }

                    else
                    {
                        return new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject("Error: PartyRoleRelationshipCodeId not found for code CIVIL", Formatting.Indented)),
                            StatusCode = System.Net.HttpStatusCode.InternalServerError
                        };
                    }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error:PartyRoleInRelationShipTypeCodeId not found  for code SPOUSE", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
            }
            catch(Exception ex)
            {
                throw; 
            }
        }
        public async Task<HttpResponseMessage> PostPrincipleMembersFamilyMember(int familymemberPartyId, int principleMemberAgreementId, string familyMemberType)
        {
            var familyMemberPartyRoleInRelationshipCode = _context.TblLtPartyRoleInRelationShipTypeCodeList.FirstOrDefault(x => x.RelationshipDescriptionCode.ToUpper() == familyMemberType.ToUpper());

            if (familyMemberPartyRoleInRelationshipCode != null)
            {
                var partyroleRelationshipCode = _context.TblLtPartyRoleRelationShipTypeCodeList.FirstOrDefault(x => x.PartyRoleRelationShipTypeCode.ToUpper() == "FAMILY");


                if (partyroleRelationshipCode != null)
                {
                    var roleInAgrementPartyroleTypeCode = _roleAndRelationshipContext.TblLtPartyRoleTypeCodeList.FirstOrDefault(x => x.PartyRoleTypeCode.ToUpper() == "PRA");
                    if (roleInAgrementPartyroleTypeCode != null)
                    {
                        var contactPersonRole = _roleAndRelationshipContext.TblRole.FirstOrDefault(x => x.Name.ToUpper() == "PROXY");

                        if (contactPersonRole != null)
                        {
                            var partyroleInAgreementCode = _context.TblLtPartyRoleinAgreementTypeCodeList.First(x => x.PartyRoleinAgreementTypeCode.ToUpper() == "PMPROXY");

                            if (partyroleInAgreementCode != null)
                            {
                                TblPartyRole tblPartyRoleObj = new TblPartyRole
                                {
                                    RoleId = contactPersonRole.RoleId,
                                    PartyRoleTypeCodeId = roleInAgrementPartyroleTypeCode.PartyRoleTypeCodeId,
                                    PartyId = familymemberPartyId
                                };
                                await _roleAndRelationshipContext.TblPartyRole.AddAsync(tblPartyRoleObj);
                                await _roleAndRelationshipContext.SaveChangesAsync();
                                var contactPersonPartyRoleId = tblPartyRoleObj.PartyRoleId;


                                TblPartyRoleInAgreement tblPartyRoleInAgreementObj = new TblPartyRoleInAgreement
                                {
                                    AgreementId = principleMemberAgreementId, //linking to principle member
                                    PartyRoleinAgreementTypeCodeId = partyroleInAgreementCode.PartyRoleinAgreementTypeCodeId,
                                    PartyId = familymemberPartyId,
                                    PartyRoleId = contactPersonPartyRoleId
                                };
                                await _context.TblPartyRoleInAgreement.AddAsync(tblPartyRoleInAgreementObj);
                                await _context.SaveChangesAsync();

                                TblPartyRoleInRelationship tblPartyRoleInRelationshipObj = new TblPartyRoleInRelationship
                                {
                                    PartyRoleInRelationshipTypeCodeId = familyMemberPartyRoleInRelationshipCode.PartyRoleinRelationShipTypeCodeId,
                                    PartyRoleId = contactPersonPartyRoleId
                                };
                                await _context.TblPartyRoleInRelationship.AddAsync(tblPartyRoleInRelationshipObj);
                                await _context.SaveChangesAsync();
                                var contactPersonPartyRoleInRelationshipId = tblPartyRoleInRelationshipObj.PartyRoleinRelationshipId;

                                Party_Dll.Models.TblPartyRoleRelationship tblPartyRoleRelationShipObj = new Party_Dll.Models.TblPartyRoleRelationship
                                {
                                    PartyRoleRelationShipTypeCodeId = partyroleRelationshipCode.PartyRoleRelationShipTypeCodeId,
                                    Description = "Principle Member " + familyMemberType,
                                    AgreementId = principleMemberAgreementId
                                };
                                await _context.TblPartyRoleRelationship.AddAsync(tblPartyRoleRelationShipObj);
                                await _context.SaveChangesAsync();
                                var contactPersonPartyRoleRelationshipId = tblPartyRoleRelationShipObj.PartyRoleRelationshipId;

                                var familyMemberTypeCode = _context.TblLtFamilyMemberTypeCodeList.FirstOrDefault(x => x.FamilyMemberTypeCode.ToUpper() == familyMemberType.ToUpper());

                                if (familyMemberTypeCode != null)
                                {
                                    TblFamilyMember tblFamilyMemberObj = new TblFamilyMember
                                    {
                                        PartyRoleinRerlationShipId = contactPersonPartyRoleInRelationshipId,
                                        FamilyMemberTypeCodeId = familyMemberTypeCode.FamilyMemberTypeCodeId
                                    };
                                    await _context.TblFamilyMember.AddAsync(tblFamilyMemberObj);
                                    await _context.SaveChangesAsync();
                                    var contactPersonFamilyMemberId = tblFamilyMemberObj.FamilyMemberId;

                                    TblFamilyRelationShip tblFamilyRelationShipObj = new TblFamilyRelationShip
                                    {
                                        PartyRoleRelationshipId = contactPersonPartyRoleRelationshipId,
                                        FamilymemberId = contactPersonFamilyMemberId
                                    };
                                    await _context.TblFamilyRelationShip.AddAsync(tblFamilyRelationShipObj);
                                    await _context.SaveChangesAsync();

                                    if (familyMemberType.ToUpper() == "CHILD")
                                    {
                                        TblChild tblChildObj = new TblChild
                                        {
                                            FamilyMemberId = contactPersonFamilyMemberId
                                        };
                                        await _context.TblChild.AddAsync(tblChildObj);
                                        await _context.SaveChangesAsync();

                                    }

                                    else if (familyMemberType.ToUpper() == "SIBLING")
                                    {
                                        TblSibling tblSiblingObj = new TblSibling
                                        {
                                            FamilyMemberId = contactPersonFamilyMemberId
                                        };
                                        await _context.TblSibling.AddAsync(tblSiblingObj);
                                        await _context.SaveChangesAsync();
                                    }

                                    else if (familyMemberType.ToUpper() == "GC")
                                    {
                                        TblGrandChild tblGrandChildObj = new TblGrandChild
                                        {
                                            FamilyMemberId = contactPersonFamilyMemberId
                                        };
                                        await _context.TblGrandChild.AddAsync(tblGrandChildObj);
                                        await _context.SaveChangesAsync();
                                    }
                                    else if (familyMemberType.ToUpper() == "GP")
                                    {
                                        TblGrandParent tblGrandParentObj = new TblGrandParent
                                        {
                                            FamilyMemberId = contactPersonFamilyMemberId
                                        };
                                        await _context.TblGrandParent.AddAsync(tblGrandParentObj);
                                        await _context.SaveChangesAsync();
                                    }
                                    else if (familyMemberType.ToUpper() == "COUSIN")
                                    {
                                        TblCousin tblCousinObj = new TblCousin
                                        {
                                            FamilyMemberId = contactPersonFamilyMemberId
                                        };
                                        await _context.TblCousin.AddAsync(tblCousinObj);
                                        await _context.SaveChangesAsync();
                                    }
                                    else if (familyMemberType.ToUpper() == "PARENT")
                                    {
                                        TblParent tblParentObj = new TblParent
                                        {
                                            FamilyMemberId = contactPersonFamilyMemberId
                                        };
                                        await _context.TblParent.AddAsync(tblParentObj);
                                        await _context.SaveChangesAsync();
                                    }

                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject(true, Formatting.Indented)),
                                    };
                                }
                                else
                                {
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject("Error: familyMembertypeCodeID not found for code CHILD", Formatting.Indented)),
                                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                                    };
                                }
                            }
                            else
                            {
                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject("Error: PartyroleInAgreementCodeId not found for code PMPROXY", Formatting.Indented)),
                                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                                };
                            }

                        }
                        else
                        {
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: RoleId not found for code PROXY", Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }
                    }
                    else
                    {
                        return new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject("Error: PartyRoleTypeCodeId not found for code PRA", Formatting.Indented)),
                            StatusCode = System.Net.HttpStatusCode.InternalServerError
                        };
                    }
                }

                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: PartyRoleRelationshipCodeId not found for code FAMILY", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
            }
            else
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject("Error:PartyRoleInRelationShipTypeCodeId not found  for code" + familyMemberType, Formatting.Indented)),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }

        public async Task<HttpResponseMessage> PostPrincipleMemberOthercontact(int contactPersonPartyId, int principleMemberAgreementId, string contactMemberType)
        {
            try
            {
                var contactPartyRoleInRelationshipCode = _context.TblLtPartyRoleInRelationShipTypeCodeList.FirstOrDefault(x => x.RelationshipDescriptionCode.ToUpper() == contactMemberType.ToUpper());

                if (contactPartyRoleInRelationshipCode != null)
                {
                    var partyroleRelationshipCode = _context.TblLtPartyRoleRelationShipTypeCodeList.FirstOrDefault(x => x.PartyRoleRelationShipTypeCode.ToUpper() == "CUSTOMER");


                    if (partyroleRelationshipCode != null)
                    {
                        var roleInAgrementPartyroleTypeCode = _roleAndRelationshipContext.TblLtPartyRoleTypeCodeList.FirstOrDefault(x => x.PartyRoleTypeCode.ToUpper() == "PRA");
                        if (roleInAgrementPartyroleTypeCode != null)
                        {
                            var contactPersonRole = _roleAndRelationshipContext.TblRole.FirstOrDefault(x => x.Name.ToUpper() == "PROXY");

                            if (contactPersonRole != null)
                            {
                                var partyroleInAgreementCode = _context.TblLtPartyRoleinAgreementTypeCodeList.First(x => x.PartyRoleinAgreementTypeCode.ToUpper() == "PMPROXY");

                                if (partyroleInAgreementCode != null)
                                {
                                    TblPartyRole tblPartyRoleObj = new TblPartyRole
                                    {
                                        RoleId = contactPersonRole.RoleId,
                                        PartyRoleTypeCodeId = roleInAgrementPartyroleTypeCode.PartyRoleTypeCodeId,
                                        PartyId = contactPersonPartyId
                                    };
                                    await _roleAndRelationshipContext.TblPartyRole.AddAsync(tblPartyRoleObj);
                                    await _roleAndRelationshipContext.SaveChangesAsync();
                                    var contactPersonPartyRoleId = tblPartyRoleObj.PartyRoleId;


                                    TblPartyRoleInAgreement tblPartyRoleInAgreementObj = new TblPartyRoleInAgreement
                                    {
                                        AgreementId = principleMemberAgreementId, //linking to principle member
                                        PartyRoleinAgreementTypeCodeId = partyroleInAgreementCode.PartyRoleinAgreementTypeCodeId,
                                        PartyId = contactPersonPartyId,
                                        PartyRoleId = contactPersonPartyRoleId
                                    };
                                    _context.TblPartyRoleInAgreement.Add(tblPartyRoleInAgreementObj);
                                    _context.SaveChanges();

                                    TblPartyRoleInRelationship tblPartyRoleInRelationshipObj = new TblPartyRoleInRelationship
                                    {
                                        PartyRoleInRelationshipTypeCodeId = contactPartyRoleInRelationshipCode.PartyRoleinRelationShipTypeCodeId,
                                        PartyRoleId = contactPersonPartyRoleId
                                    };
                                    await _context.TblPartyRoleInRelationship.AddAsync(tblPartyRoleInRelationshipObj);
                                    await _context.SaveChangesAsync();
                                    var contactPersonPartyRoleInRelationshipId = tblPartyRoleInRelationshipObj.PartyRoleinRelationshipId;

                                    Party_Dll.Models.TblPartyRoleRelationship tblPartyRoleRelationShipObj = new Party_Dll.Models.TblPartyRoleRelationship
                                    {
                                        PartyRoleRelationShipTypeCodeId = partyroleRelationshipCode.PartyRoleRelationShipTypeCodeId,
                                        Description = "Principle Member" + contactMemberType,
                                        AgreementId = principleMemberAgreementId
                                    };
                                    await _context.TblPartyRoleRelationship.AddAsync(tblPartyRoleRelationShipObj);
                                    await _context.SaveChangesAsync();
                                    var contactPersonPartyRoleRelationshipId = tblPartyRoleRelationShipObj.PartyRoleRelationshipId;


                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject(true, Formatting.Indented)),
                                    };
                                }
                                else
                                {
                                    return new HttpResponseMessage
                                    {
                                        Content = new StringContent(JsonConvert.SerializeObject("Error: PartyroleInAgreementCodeId not found for code PMPROXY", Formatting.Indented)),
                                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                                    };
                                }
                            }
                            else
                            {
                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject("Error: RoleId not found for code PROXY", Formatting.Indented)),
                                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                                };
                            }
                        }
                        else
                        {
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: PartyRoleRelationshipCodeId not found for code FAMILY", Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }
                    }
                    else
                    {
                        return new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject("Error: PartyRoleRelationshipCodeId not found for code CUSTOMER", Formatting.Indented)),
                            StatusCode = System.Net.HttpStatusCode.InternalServerError
                        };
                    }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error:PartyRoleInRelationShipTypeCodeId not found  for code" + contactMemberType, Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}