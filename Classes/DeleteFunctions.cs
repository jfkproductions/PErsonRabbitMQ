using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Party_Dll.Models;
using TIH.Common.RedisCacheHandler;
using RegistrationDAL.Models; 

namespace FnPerson.Classes
{
    public class DeleteFunctions
    {
        private readonly PartyContext _context;
        private readonly RegistrationContext _registrationContext;
        private readonly ICacheServiceClient Redisdatabase;

        public DeleteFunctions(PartyContext context, ICacheServiceClient _database)
        {
               Redisdatabase = _database;
               _context = context;

            _registrationContext = new RegistrationContext(); 
        }
        #region delete

        public async Task<HttpResponseMessage> RequestDeletePerson(string personIDreq)
        {
            try
            {   // must go into seperate funtions 
                var RedisAvail = Redisdatabase.CheckConnection();
                var Person = await _context.TblPerson.Where(cl => cl.PersonId == int.Parse(personIDreq)).ToListAsync();
                var PersonName = await _context.TblPersonName.Where(cl => cl.PersonId == int.Parse(personIDreq)).ToListAsync();
                //var Peronregistration = await _context.TblPersonRegistration.Where(cl => cl.PersonId == int.Parse(personIDreq)).ToListAsync();
                var PersonDetail = await _context.TblPersonDetail.Where(cl => cl.PersonId == int.Parse(personIDreq)).ToListAsync();
                var ReferalLookup = await _context.TblPersonReferalLink.Where(cl => cl.PersonId == int.Parse(personIDreq)).ToListAsync();
                var Country = await _context.TblCountry.Where(cl => cl.PersonId == int.Parse(personIDreq)).ToListAsync();
                var partRoleRelationshipId = PersonDetail[0].PartyRoleRelationshipId;
                var HouseholdRelationshipList = await _context.TblHouseholdRelationship.Where(cl => cl.PartyRoleRelationshipId == partRoleRelationshipId).ToListAsync();

                //foreach (var pr in Peronregistration)
                //{
                //    var IdentityCard = await _context.TblIdentityCard.Where(c1 => c1.PersonRegistrationId == pr.PersonRegistrationId).ToListAsync();
                //    foreach (var id in IdentityCard)
                //    {
                //        _context.TblIdentityCard.Remove(id);
                //        _context.SaveChanges();
                //    }
                //    var ResidentReg = await _context.TblResidentRegistration.Where(c1 => c1.PersonRegistrationId == pr.PersonRegistrationId).ToListAsync();
                //    foreach (var id in ResidentReg)
                //    {
                //        _context.TblResidentRegistration.Remove(id);
                //        _context.SaveChanges();
                //    }

                //    var PersonLicence = await _context.TblPersonalActivityLicence.Where(c1 => c1.PersonRegistrationId == pr.PersonRegistrationId).ToListAsync();
                //    foreach (var id in PersonLicence)
                //    {
                //        _context.TblPersonalActivityLicence.Remove(id);
                //        _context.SaveChanges();
                //    }

                //    var Education = await _context.TblEducationCertificate.Where(c1 => c1.PersonRegistrationId == pr.PersonRegistrationId).ToListAsync();
                //    foreach (var id in Education)
                //    {
                //        _context.TblEducationCertificate.Remove(id);
                //        _context.SaveChanges();
                //    }


                //    var Civilregitration = await _context.TblCivilRegistration.Where(c1 => c1.PersonRegistrationId == pr.PersonRegistrationId).ToListAsync();
                //    foreach (var id in Civilregitration)
                //    {
                //        _context.TblCivilRegistration.Remove(id);
                //        _context.SaveChanges();
                //    }

                //    _context.TblPersonRegistration.Remove(pr);
                //    _context.SaveChanges();
                //}
                foreach (var id in Country)
                {
                    _context.TblCountry.Remove(id);
                    _context.SaveChanges();
                }

                foreach (var householdRelationship in HouseholdRelationshipList)
                {
                    _context.TblHouseholdRelationship.Remove(householdRelationship);
                    _context.SaveChanges();
                }


                foreach (var id in ReferalLookup)
                {
                    _context.TblPersonReferalLink.Remove(id);
                    _context.SaveChanges();
                }

                foreach (var name in PersonName)
                {
                    _context.TblPersonName.Remove(name);
                }
                _context.SaveChanges();

                foreach (var item in PersonDetail)
                {
                    _context.TblPersonDetail.Remove(item);
                    _context.SaveChanges();
                }
                foreach (var pers in Person)
                {
                    _context.TblPerson.Remove(pers);
                }
                _context.SaveChanges();
                var CachedPersonId = "PersonContext_" + personIDreq;
                if (RedisAvail.Status != TaskStatus.Faulted)
                {
                    await Redisdatabase.RemoveAsync(CachedPersonId);
                }
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject("successfully deleted Person"))
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
        public async Task<HttpResponseMessage> RequestDeletePartyRoleInAgreement(string partyRoleInAgreementIDreq)
        {
            try
            {   // must go into seperate funtions 

                var PartyRoleInAgreements = await _context.TblPartyRoleInAgreement.Where(cl => cl.PartyRoleInAgreementId == int.Parse(partyRoleInAgreementIDreq)).ToListAsync();

                foreach (var PartyRoleInAgreement in PartyRoleInAgreements)
                {
                    _context.TblPartyRoleInAgreement.Remove(PartyRoleInAgreement);
                }
                _context.SaveChanges();

                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject("successfully deleted PartyRoleInAgreement"))
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

        public async Task<HttpResponseMessage> RequestDeletePrincipleMember(string personId)
        {
            try
            {

                var contactAndPlaceMSURL = Environment.GetEnvironmentVariable("ContactAndPlaceMSURL");
                var contactClient = new HttpClient();
                var httpContactRespMsg = contactClient.DeleteAsync(contactAndPlaceMSURL + "/" + personId);
                var contactResult = httpContactRespMsg.Result;
                if (contactResult.IsSuccessStatusCode)
                {
                    int convertedPersonId = int.Parse(personId);
                    var countryToDelete = _context.TblCountry.FirstOrDefault(x => x.PersonId == convertedPersonId);
                    _context.TblCountry.Remove(countryToDelete);
                    _context.SaveChanges();


                    var personRegistrationObj = _registrationContext.TblPersonRegistration.FirstOrDefault(x => x.PersonId == convertedPersonId); 

                    if(personRegistrationObj != null)
                    {
                        var birthDateToDelete = _context.TblBirthCertificate.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationObj.PersonRegistrationId);
                        _context.TblBirthCertificate.Remove(birthDateToDelete);
                        _context.SaveChanges();

                        var identityCardToDelete = _registrationContext.TblIdentityCard.FirstOrDefault(x => x.PersonRegistrationId == personRegistrationObj.PersonRegistrationId);
                        _registrationContext.TblIdentityCard.Remove(identityCardToDelete);
                        _registrationContext.SaveChanges();

                        _registrationContext.TblPersonRegistration.Remove(personRegistrationObj);
                        _registrationContext.SaveChanges();
                    }


                    var partyId = _context.TblPersonDetail.FirstOrDefault(x => x.PersonId == convertedPersonId).PartyId;

                    var partyRoleInAgreementObj = _context.TblPartyRoleInAgreement.FirstOrDefault(x => x.PartyId == partyId);

                    if (partyRoleInAgreementObj != null)
                    {
                        var agreementId = partyRoleInAgreementObj.AgreementId;

                        _context.TblPartyRoleInAgreement.Remove(partyRoleInAgreementObj); 




                    }

                }
                else
                {
                    throw new Exception("Error: Failed to Delete principle member contact details");
                }

                    return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject("successfully deleted Principle Member"))
                };
            }
            catch(Exception ex)
            {
                return new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex.Message + ":" + ex.StackTrace))
                };
            }
        }
    }
}
#endregion