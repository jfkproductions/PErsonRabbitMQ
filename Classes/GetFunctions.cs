using Agreement_DAL.Models;
using ContactAndPlaceDAL.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Party_Dll.Models;
using RegistrationDAL.Models;
using RoleAndRelationship_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TIH.Common.RedisCacheHandler;

namespace FnPerson.Classes
{

    // class Refactoring for future 
    // response Message must become a class on own
    // Return Clean data must be become class on its own
    // Header return types must become Enum
    // Must add headr resonse type in separate class 

    [JsonObject(IsReference = true)]
    public class GetFunctions
    {
        private readonly AgreementsContext _agreementcontext;
        private readonly ContactAndPlaceContext _contactContext;
        private readonly RegistrationContext _registrationContext;
        private readonly PartyContext _partycontext;
        private readonly RoleAndRelationshipContext _roleAndRelationshipContext;
        private readonly ICacheServiceClient Redisdatabase;
        private string CachedValue;

        public GetFunctions(PartyContext partycontext, AgreementsContext agreementcontext, ICacheServiceClient _database)
        {
            _partycontext = partycontext;
            _agreementcontext = agreementcontext;
            Redisdatabase = _database;
            CachedValue = "PersonContext_";
            _contactContext = new ContactAndPlaceContext();
            _registrationContext = new RegistrationContext();
            _roleAndRelationshipContext = new RoleAndRelationshipContext();

        }
        public GetFunctions(PartyContext partycontext, ICacheServiceClient _database)
        {
            _partycontext = partycontext;
            Redisdatabase = _database;
            CachedValue = "PersonContext_";
            _contactContext = new ContactAndPlaceContext();
            _registrationContext = new RegistrationContext();
            _roleAndRelationshipContext = new RoleAndRelationshipContext();
            _agreementcontext = new AgreementsContext();
        }
        #region Get
        public List<TblPerson> RequestGetPerson(string requestBody, string mode = null, string PersonIDreq = null, string count = null, string where = null)
        {
            string _errLog = "RequestGet";
            var RedisAvail = Redisdatabase.CheckConnection();
            try
            {
                dynamic PersonInformation = JsonConvert.DeserializeObject(requestBody);
                // get 

                int? PersonID = string.IsNullOrEmpty(PersonInformation.PersonId) ? 0 : PersonInformation?.PersonId;
                PersonID = (PersonIDreq == null) ? PersonID : Convert.ToInt32(PersonIDreq);

                if (PersonID != 0)
                {
                    var Person = _partycontext.TblPerson.Where(cl => cl.PersonId == PersonID).ToList();
                    _errLog += "found Person";
                    //must become a function 
                    //return ReturnCleanData(Person, mode);     
                    return Person;
                }
                else
                {
                    //new code 2020-10-13
                    bool Querable = false;
                    //bool Toprows = false;
                    int recCount = 1000; // default

                    Querable = string.IsNullOrEmpty(where) ? false : true;
                    recCount = string.IsNullOrEmpty(count) ? recCount : Convert.ToInt32(count);

                    if (Querable)
                    {
                        var Person = _partycontext.TblPerson
                        .WhereDynamic(c => mode.Replace("Where", where))
                        .Take(recCount)
                        .ToList();
                        //must become a function 
                        // return ReturnCleanData(Person, mode);
                        return Person;
                    }
                    else
                    {
                        var Person = _partycontext.TblPerson.Take(recCount).ToList();
                        _errLog += "found Person";
                        //new code 2020-10-13
                        //return ReturnCleanData(Person, mode);
                        return Person;
                    }
                    // var Person =  _partycontext.TblPerson.ToList();
                    //_errLog += "found Person";
                    //must become a function 
                    //return ReturnCleanData(Person, mode);
                    //return Person;
                }

            }
            catch (Exception ex)
            {
                /* return new HttpResponseMessage
                 {
                     Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                 };*/
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> RequestGetPersonByIdNumberAsync(int agreementKindId, string PersonIDNumber = null)
        {
            var RedisAvail = Redisdatabase.CheckConnection();
            var newPersonContact = new PersonContactDetails();
            var contactPerson = new List<RolePersonPartyContactDetails>();
            var Person = _registrationContext.TblIdentityCard.Include(x => x.PersonRegistration).ThenInclude(x => x.PersonRegistrationTypeCode).Include(x => x.PersonRegistration)
            .Where(x => x.IdentityNumber == PersonIDNumber && x.PersonRegistration.PersonRegistrationTypeCode.PersonRegistrationTypeCode == "ID Number").Select(x => x.PersonRegistration.PersonId).OrderByDescending(x => x).FirstOrDefault();

            try
            {
                var person = _partycontext.TblPerson.Include(p => p.GenderCode).FirstOrDefault(x => x.PersonId == Person);

                if (person != null)
                {
                    var personDetails = _partycontext.TblPersonDetail.FirstOrDefault(x => x.PersonId == Person);
                    var personName = _partycontext.TblPersonName.Include(p => p.PrefixTitleCode).FirstOrDefault(x => x.PersonId == Person);

                    if (personDetails != null && personName != null)
                    {

                        var agreementId = _partycontext.TblPartyRoleInAgreement.FirstOrDefault(x => x.PartyId == personDetails.PartyId)?.AgreementId;
                        var agreementCheck = _agreementcontext.TblAgreement.Where(x => x.AgreementId == agreementId.GetValueOrDefault(-1) && x.AgreementKindCodeListId == agreementKindId).Any();
                        if (agreementCheck)
                        {
                            throw new Exception("User with same agreement exists");
                        }

                        var personRegistration = _registrationContext.TblPersonRegistration.Include(p => p.PersonRegistrationTypeCode).FirstOrDefault(x => x.PersonId == Person);
                        var DOB = new DateTime();
                        var idNumber = "";
                        if (personRegistration != null)
                        {
                            var personRegistrationId = personRegistration.PersonRegistrationId;
                            var DBDOB = _registrationContext.TblBirthCertificate.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationId);

                            if (DBDOB != null)
                            {
                                DOB = DBDOB.BirthDate;
                            }

                            idNumber = _registrationContext.TblIdentityCard.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationId).IdentityNumber;
                        }

                        var personCountry = _partycontext.TblCountry.FirstOrDefault(x => x.PersonId == Person);
                        var personNationalityCode = "";
                        if (personCountry != null)
                        {
                            personNationalityCode = _partycontext.TblLtNationality.FirstOrDefault(x => x.NationalityId == personCountry.NationalityId).NationalityCode;
                        }

                        PrincipleMemberDetails responseObj = new PrincipleMemberDetails
                        {
                            PersonId = personName.PersonId,
                            PartyId = personDetails.PartyId,
                            Initials = personName.Initials,
                            FullName = personName.GivenName + " " + personName.MiddleName,
                            PreferedName = personName.PreferredName,
                            Surname = personName.Surname,
                            GenderCode = person.GenderCode?.GenderCode,
                            TitleCode = personName.PrefixTitleCode?.PrefixTitleCode,
                            AgreementId = agreementId,
                            DateOfBirth = DOB,
                            IdTypeCode = personRegistration.PersonRegistrationTypeCode.PersonRegistrationTypeCode,
                            IdNumber = idNumber,
                            NationalityCode = personNationalityCode
                        };

                        var contactAndPlaceMSURL = Environment.GetEnvironmentVariable("ContactAndPlaceMSURL");
                        var contactClient = new HttpClient();
                        var httpContactRespMsg = contactClient.GetAsync(contactAndPlaceMSURL + "/" + Person);
                        var contactResult = httpContactRespMsg.Result;
                        if (contactResult.IsSuccessStatusCode)
                        {
                            string contactResponseBody = await contactResult.Content.ReadAsStringAsync();

                            RootRoleObject contactAndPlaceObj = new RootRoleObject();
                            contactAndPlaceObj = JsonConvert.DeserializeObject<RootRoleObject>(contactResponseBody);

                            if (contactAndPlaceObj.rolePersonPartyContactDetails?.Count > 0)
                            {
                                if (contactAndPlaceObj.rolePersonPartyContactDetails[0].emailContact != null)
                                {
                                    var personEmail = contactAndPlaceObj.rolePersonPartyContactDetails[0].emailContact;
                                    responseObj.Emailaddress = personEmail.EmailAddress;
                                    responseObj.EmailId = personEmail.PkemailContactId;
                                }
                                else
                                {
                                    responseObj.Emailaddress = "";
                                }

                                var perosonTelephoneList = contactAndPlaceObj.rolePersonPartyContactDetails[0]?.telephoneNumberList;
                                responseObj.TelephoneLists = new List<Telephone>();
                                foreach (var telephone in perosonTelephoneList)
                                {
                                    var currentTelephoneTypeCode = _contactContext.TblLtTelephoneTypeCodeList.FirstOrDefault(x => x.TelephoneTypeCodeListId == telephone.TelephoneTypeCodeListId).TelephoneTypeCode;

                                    Telephone currentTelephneObj = new Telephone();
                                    currentTelephneObj.TelephoneNumberId = telephone.PktelephoneNumberId;
                                    currentTelephneObj.TelephoneTypeCodeListCode = currentTelephoneTypeCode;
                                    currentTelephneObj.Number = telephone.FullNumber;
                                    currentTelephneObj.PreferedNumber = telephone.isPrimary;

                                    responseObj.TelephoneLists.Add(currentTelephneObj);
                                }
                            }
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject(responseObj, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, ReferenceLoopHandling = ReferenceLoopHandling.Ignore }))
                            };
                        }
                        else
                        {
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: Failed to get person Contact Details", Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }

                    }
                    else
                    {
                        return new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject("Error: person Details not found", Formatting.Indented)),
                            StatusCode = System.Net.HttpStatusCode.InternalServerError

                        };
                    }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: person not found", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
            }
            catch (Exception ex) when (ex.Message == "User with same agreement exists")
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject($"Error: {ex.Message}", Formatting.Indented)),
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<HttpResponseMessage> RequestGetByPersonNameEmail(List<int> requestBody, string mode = null)
        {
            string _errLog = "RequestGetByPersonNameEmail";
            try
            {
                var RedisAvail = Redisdatabase.CheckConnection();
                var CacheResponse = "";
                List<PersonNameEmail> lstPersonNameEmail = new List<PersonNameEmail>();

                _errLog += string.Format("RequestGetByPerson {0}", requestBody == null ? string.Empty : Convert.ToString(requestBody));

                CachedValue += Convert.ToString(requestBody);

                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    CacheResponse = await Redisdatabase.GetAsync<string>(CachedValue);
                }

                if (!string.IsNullOrWhiteSpace(CacheResponse))
                {
                    var resp = new HttpResponseMessage()
                    {
                        Content = new StringContent(CacheResponse)
                    };
                    resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return resp;
                }
                else
                {
                    List<PersonNameEmail> items = new List<PersonNameEmail>();

                    if (requestBody != null && requestBody.Count > 0)
                    {
                        items = _partycontext.TblPersonName.Where(q => requestBody.Contains(q.PersonId)).Select(q => new PersonNameEmail
                        {
                            MiddleName = q.MiddleName,
                            GivenName = q.GivenName,
                            PersonId = q.PersonId
                        }).ToList();
                    }
                    else
                    {
                        items = (from q in _partycontext.TblPersonName
                                 select new PersonNameEmail
                                 {
                                     MiddleName = q.MiddleName,
                                     GivenName = q.GivenName,
                                     PersonId = q.PersonId
                                 }).ToList();
                    }

                    List<int> getids = items.Select(q => q.PersonId).ToList();
                    var query = (from a in _contactContext.TblEmailContact
                                 join b in _contactContext.TblRolePersonPartyContactDetails on
                                 a.PkemailContactId equals b.PkemailContactId
                                 where getids.Contains(b.PersonId)
                                 select new
                                 {
                                     EmailAddress = a.EmailAddress,
                                     PersonId = b.PersonId
                                 });
                    foreach (var item in items)
                    {
                        try
                        {
                            var email = query.Where(q => q.PersonId == item.PersonId).Select(q => q.EmailAddress).FirstOrDefault();
                            lstPersonNameEmail.Add(new PersonNameEmail
                            {
                                MiddleName = item.MiddleName,
                                GivenName = item.GivenName,
                                PersonId = item.PersonId,
                                Email = email
                            }); ;
                        }
                        catch { }

                    }
                    _errLog += "found RequestGetByPerson";
                    return ReturnCleanDataPersonNameEmail(lstPersonNameEmail, CachedValue, mode);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                };
            }
        }
        public HttpResponseMessage ReturnCleanDataPersonNameEmail(object ObjectToConvert, string CachedValue, string mode = null)
        {
            var RedisAvail = Redisdatabase.CheckConnection();
            if ((mode != null) && (mode.ToUpper() == "RAW"))
            {

                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    if (!string.IsNullOrWhiteSpace(CachedValue))
                        Redisdatabase.AddAsync<string>(CachedValue, JsonConvert.SerializeObject(ObjectToConvert, Formatting.Indented)).ConfigureAwait(false);

                }
                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ObjectToConvert, Formatting.Indented,
                                 new JsonSerializerSettings
                                 {
                                     ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                     PreserveReferencesHandling = PreserveReferencesHandling.Arrays,
                                     NullValueHandling = NullValueHandling.Ignore,
                                 }))
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;
            }
            else
            {
                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    if (!string.IsNullOrWhiteSpace(CachedValue))
                        Redisdatabase.AddAsync<string>(CachedValue, JsonConvert.SerializeObject(ObjectToConvert, Formatting.Indented)).ConfigureAwait(false);
                }
                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ObjectToConvert, Formatting.Indented))
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;
            }
        }
        public List<ReqPersonBasicObj> RequestGetBasicPerson(string requestBody, string mode = null, string PersonIDreq = null)
        {

            var TblPersonList = RequestGetPerson(requestBody, mode, PersonIDreq);

            PersonArrayObject personArrayObject = GetPersonTablewithLookups(TblPersonList);
            List<ReqPersonBasicObj> basicPersons = FormatObjectDetails.ConvertPerson_BasicPerson(personArrayObject);
            return basicPersons;
        }


        public PersonArrayObject GetPersonTablewithLookups(List<TblPerson> Persons)
        {
            PersonArrayObject personArrayObject = new PersonArrayObject
            {
                PersonalDetail = FormatObjectDetails.ConvertToPersonInformation(Persons, _partycontext, _roleAndRelationshipContext),
                Relationships = FormatObjectDetails.GetRelationships(Persons, _partycontext),
            };
            return personArrayObject;
        }
        public HttpResponseMessage ReturnVirtualPartyCleanData(List<TblVirtualParty> ObjectToConvert, string mode = null)
        {
            var RedisAvail = Redisdatabase.CheckConnection();

            if ((mode != null) && (mode.ToUpper() == "RAW"))
            {
                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(CachedValue))
                            Redisdatabase.AddAsync<string>(CachedValue, JsonConvert.SerializeObject(ObjectToConvert, Formatting.Indented)).ConfigureAwait(false);
                    }
                    catch (Exception)
                    {

                    }

                }
                var Returnlist = FormatObjectDetails.ConvertTblVirtualPartyToVirtualparty(ObjectToConvert, _partycontext);
                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(Returnlist, Formatting.Indented))
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;
            }
            else
            {
                var Returnlist = FormatObjectDetails.ConvertTblVirtualPartyToVirtualparty(ObjectToConvert, _partycontext);
                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    if (!string.IsNullOrWhiteSpace(CachedValue))
                        Redisdatabase.AddAsync<string>(CachedValue, JsonConvert.SerializeObject(Returnlist, Formatting.Indented)).ConfigureAwait(false);
                }
                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(Returnlist, Formatting.Indented))
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;
            }
        }

        public List<TblVirtualParty> RequestGetVirtualParty(string requestBody, string mode = null, string PersonIDreq = null, string count = null, string where = null)
        {
            string _errLog = "RequestGet";
            var RedisAvail = Redisdatabase.CheckConnection();
            try
            {
                dynamic PersonInformation = JsonConvert.DeserializeObject(requestBody);
                // get 
                int? VirtualPartyId = PersonInformation?.VirtualPartyId;
                VirtualPartyId = (PersonIDreq == null) ? VirtualPartyId : Convert.ToInt32(PersonIDreq);

                if (VirtualPartyId != null)
                {
                    var Person = _partycontext.TblVirtualParty.Where(cl => cl.VirtualPartyId == VirtualPartyId).ToList();
                    _errLog += "found VirtualParty";
                    //must become a function 
                    //return ReturnCleanData(Person, mode);     
                    return Person;
                }
                else
                {
                    //new code 2020-10-13
                    bool Querable = false;
                    //bool Toprows = false;
                    int recCount = 1000; // default

                    Querable = string.IsNullOrEmpty(where) ? false : true;
                    recCount = string.IsNullOrEmpty(count) ? recCount : Convert.ToInt32(count);

                    if (Querable)
                    {
                        var VirtualParty = _partycontext.TblVirtualParty
                        .WhereDynamic(c => mode.Replace("Where", where))
                        .Take(recCount)
                        .ToList();
                        //must become a function 
                        // return ReturnCleanData(Person, mode);
                        return VirtualParty;
                    }
                    else
                    {
                        var VirtualParty = _partycontext.TblVirtualParty.Take(recCount).ToList();
                        _errLog += "found Person";
                        //new code 2020-10-13
                        //return ReturnCleanData(Person, mode);
                        return VirtualParty;
                    }
                    // var Person =  _partycontext.TblPerson.ToList();
                    //_errLog += "found Person";
                    //must become a function 
                    //return ReturnCleanData(Person, mode);
                    //return Person;
                }

            }
            catch (Exception ex)
            {
                /* return new HttpResponseMessage
                 {
                     Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                 };*/
                throw ex;
            }
        }

        #endregion
        public HttpResponseMessage ReturnCleanData(object ObjectToConvert, string mode = null)
        {
            var RedisAvail = Redisdatabase.CheckConnection();

            if ((mode != null) && (mode.ToUpper() == "RAW"))
            {
                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(CachedValue))
                            Redisdatabase.AddAsync<string>(CachedValue, JsonConvert.SerializeObject(ObjectToConvert, Formatting.Indented)).ConfigureAwait(false);
                    }
                    catch (Exception)
                    {

                    }

                }

                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ObjectToConvert, Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                PreserveReferencesHandling = PreserveReferencesHandling.Arrays,
                                NullValueHandling = NullValueHandling.Ignore,
                            }))
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;
            }
            else
            {
                var Returnlist = GetPersonTablewithLookups((List<TblPerson>)ObjectToConvert);
                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    if (!string.IsNullOrWhiteSpace(CachedValue))
                        Redisdatabase.AddAsync<string>(CachedValue, JsonConvert.SerializeObject(Returnlist, Formatting.Indented)).ConfigureAwait(false);
                }
                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(Returnlist, Formatting.Indented))

                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;
            }
        }
        //public  PersonArrayObject GetPersonTablewithLookups(List<TblPerson> Persons)
        //{
        //    PersonArrayObject personArrayObject = new PersonArrayObject
        //    {
        //        PersonalDetail = FormatObjectDetails.ConvertToPersonInformation(Persons, _partycontext),
        //        Relationships   = FormatObjectDetails.GetRelationships(Persons, _partycontext),
        //    };
        //    return personArrayObject;
        //}

        public HttpResponseMessage ReturnPersonCleanData(object ObjectToConvert, string mode = null)
        {
            var RedisAvail = Redisdatabase.CheckConnection();

            if ((mode != null) && (mode.ToUpper() == "RAW"))
            {
                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(CachedValue))
                            Redisdatabase.AddAsync<string>(CachedValue, JsonConvert.SerializeObject(ObjectToConvert, Formatting.Indented)).ConfigureAwait(false);
                    }
                    catch (Exception)
                    {

                    }
                }
                var Returnlist = GetPersonTablewithLookups((List<TblPerson>)ObjectToConvert);
                var content = new StringContent(JsonConvert.SerializeObject(Returnlist, Formatting.Indented));

                var resp = new HttpResponseMessage()
                {
                    Content = content
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;
            }
            else
            {
                var Returnlist = GetPersonTablewithLookups((List<TblPerson>)ObjectToConvert);
                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    if (!string.IsNullOrWhiteSpace(CachedValue))
                        Redisdatabase.AddAsync<string>(CachedValue, JsonConvert.SerializeObject(Returnlist, Formatting.Indented)).ConfigureAwait(false);
                }
                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(Returnlist, Formatting.Indented))
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;
            }
        }

        public async Task<HttpResponseMessage> RequestGetPartyRoleInAgreement(string requestBody, string mode = null, string PersonIDreq = null)
        {
            string _errLog = "RequestGetPartyRoleInAgreement";

            try
            {
                dynamic PartyRoleInAgreementInformation = JsonConvert.DeserializeObject(requestBody);
                // get 
                int? PartyRoleInAgreementID = PartyRoleInAgreementInformation?.PartyRoleInAgreementInformationId;
                PartyRoleInAgreementID = (PersonIDreq == null) ? PartyRoleInAgreementID : Convert.ToInt32(PersonIDreq);

                if (PartyRoleInAgreementID != null)
                {

                    _errLog += string.Format("PersonID {0}", PartyRoleInAgreementID.ToString());

                    var PartyRoleInAgreement = await _partycontext.TblPartyRoleInAgreement.Where(cl => cl.PartyRoleInAgreementId == PartyRoleInAgreementID).ToListAsync();
                    _errLog += "PartyRoleInAgreement";
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(PartyRoleInAgreement, Formatting.Indented

                    ))
                    };
                }
                else
                {
                    var PartyRoleInAgreements = await _partycontext.TblPartyRoleInAgreement.ToListAsync();
                    _errLog += "PartyRoleInAgreement";
                    //must become a function 
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(PartyRoleInAgreements, Formatting.Indented

                    ))
                    };
                }

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(_errLog + ex.Message + ":" + ex.StackTrace))
                };
            }
        }

        public async Task<HttpResponseMessage> RequestGetPrincipleMember(string personId, string agreementId)
        {
            try
            {
                int convertedPersonId = int.Parse(personId);
                var person = _partycontext.TblPerson.Include(p => p.GenderCode).FirstOrDefault(x => x.PersonId == convertedPersonId);

                var convertedAgreementId = int.Parse(agreementId);
                var PMPartyRoleinAgreementTypeCode = Environment.GetEnvironmentVariable("PMPartyRoleinAgreementTypeCode");

                if (person != null)
                {
                    var personDetails = _partycontext.TblPersonDetail.FirstOrDefault(x => x.PersonId == convertedPersonId);
                    var personName = _partycontext.TblPersonName.Include(p => p.PrefixTitleCode).FirstOrDefault(x => x.PersonId == convertedPersonId);

                    if (personDetails != null && personName != null)
                    {
                        var partyRoleInAgreementTypeCode = _partycontext.TblLtPartyRoleinAgreementTypeCodeList.FirstOrDefault(x => x.PartyRoleinAgreementTypeCode.ToUpper() == "PRINCIPLE").PartyRoleinAgreementTypeCodeId;
                        //var agreementId = _partycontext.TblPartyRoleInAgreement.FirstOrDefault(x => x.PartyId == personDetails.PartyId && x.PartyRoleinAgreementTypeCodeId == partyRoleInAgreementTypeCode).AgreementId;
                        var partyRoleinAgreement = _partycontext.TblPartyRoleInAgreement.Include(p => p.PartyRoleinAgreementTypeCode).FirstOrDefault(x => x.PartyId == personDetails.PartyId && x.AgreementId == convertedAgreementId && x.PartyRoleinAgreementTypeCode.PartyRoleinAgreementTypeCode.ToUpper() == PMPartyRoleinAgreementTypeCode);

                        if (partyRoleinAgreement != null)
                        {
                            var agreementKindId = _agreementcontext.TblAgreement.FirstOrDefault(x => x.AgreementId == convertedAgreementId).AgreementKindCodeListId; 
                            var personRegistration = _registrationContext.TblPersonRegistration.Include(p => p.PersonRegistrationTypeCode).FirstOrDefault(x => x.PersonId == convertedPersonId);
                            var DOB = new DateTime();
                            var idNumber = "";
                            if (personRegistration != null)
                            {
                                var personRegistrationId = personRegistration.PersonRegistrationId;
                                var DBDOB = _registrationContext.TblBirthCertificate.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationId);

                                if (DBDOB != null)
                                {
                                    DOB = DBDOB.BirthDate;
                                }

                                idNumber = _registrationContext.TblIdentityCard.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationId).IdentityNumber;
                            }

                            var personCountry = _partycontext.TblCountry.FirstOrDefault(x => x.PersonId == convertedPersonId);
                            var personNationalityCode = "";
                            if (personCountry != null)
                            {
                                personNationalityCode = _partycontext.TblLtNationality.FirstOrDefault(x => x.NationalityId == personCountry.NationalityId).NationalityCode;
                            }

                            PrincipleMemberDetails responseObj = new PrincipleMemberDetails
                            {
                                PersonId = personName.PersonId,
                                PartyId = personDetails.PartyId,
                                Initials = personName.Initials,
                                FullName = personName.GivenName + " " + personName.MiddleName,
                                PreferedName = personName.PreferredName,
                                Surname = personName.Surname,
                                GenderCode = person.GenderCode?.GenderCode,
                                TitleCode = personName.PrefixTitleCode?.PrefixTitleCode,
                                AgreementId = convertedAgreementId,
                                DateOfBirth = DOB,
                                IdTypeCode = personRegistration.PersonRegistrationTypeCode.PersonRegistrationTypeCode,
                                IdNumber = idNumber,
                                NationalityCode = personNationalityCode, 
                                AgreementKindCodeId = agreementKindId
                            };

                            var contactAndPlaceMSURL = Environment.GetEnvironmentVariable("ContactAndPlaceMSURL");
                            var contactClient = new HttpClient();
                            var httpContactRespMsg = contactClient.GetAsync(contactAndPlaceMSURL + "/" + personId);
                            var contactResult = httpContactRespMsg.Result;
                            if (contactResult.IsSuccessStatusCode)
                            {
                                string contactResponseBody = await contactResult.Content.ReadAsStringAsync();

                                RootRoleObject contactAndPlaceObj = new RootRoleObject();
                                contactAndPlaceObj = JsonConvert.DeserializeObject<RootRoleObject>(contactResponseBody);

                                if (contactAndPlaceObj.rolePersonPartyContactDetails?.Count > 0)
                                {
                                    if (contactAndPlaceObj.rolePersonPartyContactDetails[0].emailContact != null)
                                    {
                                        var personEmail = contactAndPlaceObj.rolePersonPartyContactDetails[0].emailContact;
                                        responseObj.Emailaddress = personEmail.EmailAddress;
                                        responseObj.EmailId = personEmail.PkemailContactId;
                                    }
                                    else
                                    {
                                        responseObj.Emailaddress = "";
                                    }

                                    var perosonTelephoneList = contactAndPlaceObj.rolePersonPartyContactDetails[0]?.telephoneNumberList;
                                    responseObj.TelephoneLists = new List<Telephone>();
                                    foreach (var telephone in perosonTelephoneList)
                                    {
                                        var currentTelephoneTypeCode = _contactContext.TblLtTelephoneTypeCodeList.FirstOrDefault(x => x.TelephoneTypeCodeListId == telephone.TelephoneTypeCodeListId).TelephoneTypeCode;

                                        Telephone currentTelephneObj = new Telephone();
                                        currentTelephneObj.TelephoneNumberId = telephone.PktelephoneNumberId;
                                        currentTelephneObj.TelephoneTypeCodeListCode = currentTelephoneTypeCode;
                                        currentTelephneObj.Number = telephone.FullNumber;
                                        currentTelephneObj.PreferedNumber = telephone.isPrimary;

                                        responseObj.TelephoneLists.Add(currentTelephneObj);
                                    }
                                }


                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject(responseObj, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }))
                                };
                            }
                            else
                            {
                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject("Error: Failed to get principle member Contact Details", Formatting.Indented)),
                                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                                };
                            }
                        }
                        else
                        {
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: Person " + personId + " is not the Principle Member of agreement " + agreementId, Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }

                    }
                    else
                    {
                        return new HttpResponseMessage
                        {
                            Content = new StringContent(JsonConvert.SerializeObject("Error: principle member Details not found", Formatting.Indented)),
                            StatusCode = System.Net.HttpStatusCode.InternalServerError

                        };
                    }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: principle member not found", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<HttpResponseMessage> RequestGetPrinciplememberByAgreementId(string agreementId)
        {
            try
            {
                var convertedAgreementId = int.Parse(agreementId);
                var PMPartyRoleinAgreementTypeCode = Environment.GetEnvironmentVariable("PMPartyRoleinAgreementTypeCode");

                var PMPartyRoleinAgreement = await _partycontext.TblPartyRoleInAgreement.Include(p => p.PartyRoleinAgreementTypeCode)
                    .Where(x => x.AgreementId == convertedAgreementId && x.PartyRoleinAgreementTypeCode.PartyRoleinAgreementTypeCode.ToUpper() == PMPartyRoleinAgreementTypeCode).ToListAsync(); 

                if(PMPartyRoleinAgreement.Count == 1)
                {
                    var PMPersonDetails = await _partycontext.TblPersonDetail.FirstOrDefaultAsync(x => x.PartyId == PMPartyRoleinAgreement[0].PartyId);
                    return await RequestGetPrincipleMember(PMPersonDetails.PersonId.ToString(), agreementId);
                }
                else if(PMPartyRoleinAgreement.Count > 1)
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: Data error. Agreement has more then 1 Principle Member", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: No Principle Member found for provided AgreementID", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
        public async Task<HttpResponseMessage> RequestGetContactPerson(string personId, string agreementId)
        {
            try
            {
                int convertedPersonId = int.Parse(personId);
                int convertedAgreementId = int.Parse(agreementId); 
                var person = _partycontext.TblPerson.Include(p => p.GenderCode).FirstOrDefault(x => x.PersonId == convertedPersonId);

                if (person != null)
                {
                    var personDetails = _partycontext.TblPersonDetail.FirstOrDefault(x => x.PersonId == convertedPersonId);
                    var personName = _partycontext.TblPersonName.Include(p => p.PrefixTitleCode).FirstOrDefault(x => x.PersonId == convertedPersonId);

                    if (personDetails != null && personName != null)
                    {
                        var partyRoleinAgreement = _partycontext.TblPartyRoleInAgreement.Include(p => p.PartyRoleinAgreementTypeCode).FirstOrDefault(x => x.PartyId == personDetails.PartyId && x.AgreementId == convertedAgreementId && x.PartyRoleinAgreementTypeCode.PartyRoleinAgreementTypeCode.ToUpper() == "PMPROXY");

                        if (partyRoleinAgreement != null) { 
                            var personRegistration = _registrationContext.TblPersonRegistration.Include(p => p.PersonRegistrationTypeCode).FirstOrDefault(x => x.PersonId == convertedPersonId);
                            var DOB = new DateTime();
                            var idNumber = "";
                            if (personRegistration != null)
                            {
                                var personRegistrationId = personRegistration.PersonRegistrationId;
                                var DBDOB = _registrationContext.TblBirthCertificate.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationId);

                                if (DBDOB != null)
                                {
                                    DOB = DBDOB.BirthDate;
                                }

                                idNumber = _registrationContext.TblIdentityCard.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationId).IdentityNumber;
                            }

                            var personCountry = _partycontext.TblCountry.FirstOrDefault(x => x.PersonId == convertedPersonId);
                            var personNationalityCode = "";
                            if (personCountry != null)
                            {
                                personNationalityCode = _partycontext.TblLtNationality.FirstOrDefault(x => x.NationalityId == personCountry.NationalityId).NationalityCode;
                            }

                            var principleMemberPartyRoleInAgreement = _partycontext.TblPartyRoleInAgreement.Include(p => p.PartyRoleinAgreementTypeCode).FirstOrDefault(x => x.AgreementId == convertedAgreementId && x.PartyRoleinAgreementTypeCode.PartyRoleinAgreementTypeCode.ToUpper() == "PRINCIPLE");
                            var principleMemberPersonDetails = _partycontext.TblPersonDetail.FirstOrDefault(x => x.PartyId == principleMemberPartyRoleInAgreement.PartyId);


                           var partyRoleInRelationship = _partycontext.TblPartyRoleInRelationship.Include(p => p.PartyRoleInRelationshipTypeCode).FirstOrDefault(x => x.PartyRoleId == partyRoleinAgreement.PartyRoleId);


                            ContactPersonDetails responseObj = new ContactPersonDetails();

                            responseObj.PersonId = personName.PersonId;
                            responseObj.PartyId = personDetails.PartyId;
                            responseObj.Initials = personName.Initials;
                            responseObj.FullName = personName.GivenName + " " + personName.MiddleName;
                            responseObj.PreferedName = personName.PreferredName;
                            responseObj.Surname = personName.Surname;
                            responseObj.GenderCode = person.GenderCode?.GenderCode;
                            responseObj.TitleCode = personName.PrefixTitleCode?.PrefixTitleCode;
                            responseObj.AgreementId = convertedAgreementId;
                            responseObj.DateOfBirth = DOB;
                            responseObj.IdTypeCode = personRegistration.PersonRegistrationTypeCode.PersonRegistrationTypeCode;
                            responseObj.IdNumber = idNumber;
                            responseObj.NationalityCode = personNationalityCode;
                            responseObj.PrincipleMemberPersonId = principleMemberPersonDetails.PersonId;
                            responseObj.PartyRoleinRelationShipTypeCode = partyRoleInRelationship.PartyRoleInRelationshipTypeCode.RelationshipDescriptionCode;

                            var contactAndPlaceMSURL = Environment.GetEnvironmentVariable("ContactAndPlaceMSURL");
                            var contactClient = new HttpClient();
                            var httpContactRespMsg = contactClient.GetAsync(contactAndPlaceMSURL + "/" + personId);
                            var contactResult = httpContactRespMsg.Result;
                            if (contactResult.IsSuccessStatusCode)
                            {
                                string contactResponseBody = await contactResult.Content.ReadAsStringAsync();

                                RootRoleObject contactAndPlaceObj = new RootRoleObject();
                                contactAndPlaceObj = JsonConvert.DeserializeObject<RootRoleObject>(contactResponseBody);

                                if (contactAndPlaceObj.rolePersonPartyContactDetails?.Count > 0)
                                {
                                    if (contactAndPlaceObj.rolePersonPartyContactDetails[0].emailContact != null)
                                    {
                                        var personEmail = contactAndPlaceObj.rolePersonPartyContactDetails[0].emailContact;
                                        responseObj.Emailaddress = personEmail.EmailAddress;
                                        responseObj.EmailId = personEmail.PkemailContactId;
                                    }
                                    else
                                    {
                                        responseObj.Emailaddress = "";
                                    }

                                    var perosonTelephoneList = contactAndPlaceObj.rolePersonPartyContactDetails[0]?.telephoneNumberList;
                                    responseObj.TelephoneLists = new List<Telephone>();
                                    foreach (var telephone in perosonTelephoneList)
                                    {
                                        var currentTelephoneTypeCode = _contactContext.TblLtTelephoneTypeCodeList.FirstOrDefault(x => x.TelephoneTypeCodeListId == telephone.TelephoneTypeCodeListId).TelephoneTypeCode;

                                        Telephone currentTelephneObj = new Telephone();
                                        currentTelephneObj.TelephoneNumberId = telephone.PktelephoneNumberId;
                                        currentTelephneObj.TelephoneTypeCodeListCode = currentTelephoneTypeCode;
                                        currentTelephneObj.Number = telephone.FullNumber;
                                        currentTelephneObj.PreferedNumber = telephone.isPrimary;

                                        responseObj.TelephoneLists.Add(currentTelephneObj);
                                    }
                                }


                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject(responseObj, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }))
                                };
                            }
                            else
                            {
                                return new HttpResponseMessage
                                {
                                    Content = new StringContent(JsonConvert.SerializeObject("Error: Failed to get Contact Person Contact Details", Formatting.Indented)),
                                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                                };
                            }

                        }
                        else
                        {
                            return new HttpResponseMessage
                            {
                                Content = new StringContent(JsonConvert.SerializeObject("Error: Person " + personId + " is not a contact person for agreement " + agreementId, Formatting.Indented)),
                                StatusCode = System.Net.HttpStatusCode.InternalServerError
                            };
                        }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: Contact Person Details not found", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }
                }
                else
                {
                    return new HttpResponseMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject("Error: Contact Person not found", Formatting.Indented)),
                        StatusCode = System.Net.HttpStatusCode.InternalServerError
                    };
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> RequestGetContactPersonsByAgreementId(string agreementId)
        {
            try
            {
                var convertedAgreementId = int.Parse(agreementId); 
                var CPPartyRoleinAgreementTypeCode = Environment.GetEnvironmentVariable("CPPartyRoleinAgreementTypeCode");

                var contactPersonsPartyRoleInAgreement = await _partycontext.TblPartyRoleInAgreement.Include(p => p.PartyRoleinAgreementTypeCode)
                    .Where(x => x.AgreementId == convertedAgreementId && x.PartyRoleinAgreementTypeCode.PartyRoleinAgreementTypeCode.ToUpper() == CPPartyRoleinAgreementTypeCode).ToListAsync();

                List<ContactPersonDetails> responseList = new List<ContactPersonDetails>(); 
                foreach(var contactPerson in contactPersonsPartyRoleInAgreement)
                {
                    var currentPersonDetails = await _partycontext.TblPersonDetail.FirstOrDefaultAsync(x => x.PartyId == contactPerson.PartyId);

                    var currentContactPerson = await RequestGetContactPerson(currentPersonDetails.PersonId.ToString(), agreementId);

                    string contactPersonBody = await currentContactPerson.Content.ReadAsStringAsync();
                    var contactPersonObj = JsonConvert.DeserializeObject<ContactPersonDetails>(contactPersonBody);
                    responseList.Add(contactPersonObj); 
                }

                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(responseList, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }))
                };
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }

        public bool DoesPrincipleMemberExist(string IdNumber,string agreementKindId)
        {
            var response = false;
            var personId = _registrationContext.TblIdentityCard.Include(x => x.PersonRegistration).ThenInclude(x => x.PersonRegistrationTypeCode).Include(x => x.PersonRegistration)
             .Where(x => x.IdentityNumber == IdNumber && x.PersonRegistration.PersonRegistrationTypeCode.PersonRegistrationTypeCode == "ID Number").Select(x => x.PersonRegistration.PersonId).OrderByDescending(x => x).FirstOrDefault();
            try
            {
                var partyRoleInAgreement = _partycontext.TblPartyRoleInAgreement.Include(x => x.PartyRoleinAgreementTypeCode).Include(x => x.Party).ThenInclude(x => x.TblPersonDetail).FirstOrDefault(x => x.Party.TblPersonDetail.FirstOrDefault(x => x.PersonId == personId) != null);
                if (partyRoleInAgreement != null)
                {
                    response = partyRoleInAgreement.PartyRoleinAgreementTypeCode.PartyRoleinAgreementTypeCode.Contains("Principle");
                    if (!response)
                    {
                        return false;
                    }
                    response = partyRoleInAgreement.AgreementId > 0;
                    if (!response)
                    {
                        return false;
                    }
                    var agreementId = _partycontext.TblPartyRoleInAgreement.FirstOrDefault(x => x.PartyId == partyRoleInAgreement.PartyId)?.AgreementId;
                    var agreekemtKindint = int.Parse(agreementKindId ?? "1");
                    response = _agreementcontext.TblAgreement.Where(x => x.AgreementId == agreementId.GetValueOrDefault(-1) && x.AgreementKindCodeListId == agreekemtKindint).Any();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return response;
        }
    }
}
