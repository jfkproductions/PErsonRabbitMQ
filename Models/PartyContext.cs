using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dal.Models
{
    public partial class PartyContext : DbContext
    {
        public PartyContext()
        {
        }

        public PartyContext(DbContextOptions<PartyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbLLtNafCode> TbLLtNafCode { get; set; }
        public virtual DbSet<TblAccountHolder> TblAccountHolder { get; set; }
        public virtual DbSet<TblAccountProvider> TblAccountProvider { get; set; }
        public virtual DbSet<TblAdditionalInterest> TblAdditionalInterest { get; set; }
        public virtual DbSet<TblAgreementApprover> TblAgreementApprover { get; set; }
        public virtual DbSet<TblAgreementAuditor> TblAgreementAuditor { get; set; }
        public virtual DbSet<TblAgreementHolder> TblAgreementHolder { get; set; }
        public virtual DbSet<TblAgreementManager> TblAgreementManager { get; set; }
        public virtual DbSet<TblAgreementProducer> TblAgreementProducer { get; set; }
        public virtual DbSet<TblAgreementRequester> TblAgreementRequester { get; set; }
        public virtual DbSet<TblAgreementServicer> TblAgreementServicer { get; set; }
        public virtual DbSet<TblAgreementUnderwriter> TblAgreementUnderwriter { get; set; }
        public virtual DbSet<TblApplicant> TblApplicant { get; set; }
        public virtual DbSet<TblArtDirector> TblArtDirector { get; set; }
        public virtual DbSet<TblAssignee> TblAssignee { get; set; }
        public virtual DbSet<TblBankDistributionRelationship> TblBankDistributionRelationship { get; set; }
        public virtual DbSet<TblBankRegistration> TblBankRegistration { get; set; }
        public virtual DbSet<TblBeneficiary> TblBeneficiary { get; set; }
        public virtual DbSet<TblBenefitBeneficiary> TblBenefitBeneficiary { get; set; }
        public virtual DbSet<TblBiller> TblBiller { get; set; }
        public virtual DbSet<TblBirthCertificate> TblBirthCertificate { get; set; }
        public virtual DbSet<TblBorrower> TblBorrower { get; set; }
        public virtual DbSet<TblBranch> TblBranch { get; set; }
        public virtual DbSet<TblCedent> TblCedent { get; set; }
        public virtual DbSet<TblChildOrganization> TblChildOrganization { get; set; }
        public virtual DbSet<TblCivilRegistration> TblCivilRegistration { get; set; }
        public virtual DbSet<TblCivilRelationShip> TblCivilRelationShip { get; set; }
        public virtual DbSet<TblClaimAdjuster> TblClaimAdjuster { get; set; }
        public virtual DbSet<TblClaimDeclarer> TblClaimDeclarer { get; set; }
        public virtual DbSet<TblClaimDriver> TblClaimDriver { get; set; }
        public virtual DbSet<TblClaimExpert> TblClaimExpert { get; set; }
        public virtual DbSet<TblClaimLegalExpert> TblClaimLegalExpert { get; set; }
        public virtual DbSet<TblClaimPayor> TblClaimPayor { get; set; }
        public virtual DbSet<TblClaimRecorder> TblClaimRecorder { get; set; }
        public virtual DbSet<TblClaimRepresentative> TblClaimRepresentative { get; set; }
        public virtual DbSet<TblClaimant> TblClaimant { get; set; }
        public virtual DbSet<TblClaimee> TblClaimee { get; set; }
        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblContributionPayer> TblContributionPayer { get; set; }
        public virtual DbSet<TblCopyEditor> TblCopyEditor { get; set; }
        public virtual DbSet<TblCopyWriter> TblCopyWriter { get; set; }
        public virtual DbSet<TblCountry> TblCountry { get; set; }
        public virtual DbSet<TblCreator> TblCreator { get; set; }
        public virtual DbSet<TblCreditor> TblCreditor { get; set; }
        public virtual DbSet<TblCriminalIncident> TblCriminalIncident { get; set; }
        public virtual DbSet<TblCustomerRelationship> TblCustomerRelationship { get; set; }
        public virtual DbSet<TblDeathCertificate> TblDeathCertificate { get; set; }
        public virtual DbSet<TblDefendant> TblDefendant { get; set; }
        public virtual DbSet<TblDepartmentalUnit> TblDepartmentalUnit { get; set; }
        public virtual DbSet<TblDriverLicence> TblDriverLicence { get; set; }
        public virtual DbSet<TblDriverLicenseClassification> TblDriverLicenseClassification { get; set; }
        public virtual DbSet<TblDrivingIncident> TblDrivingIncident { get; set; }
        public virtual DbSet<TblEducationCertificate> TblEducationCertificate { get; set; }
        public virtual DbSet<TblEmailContact> TblEmailContact { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }
        public virtual DbSet<TblEmployeeSummeryDetail> TblEmployeeSummeryDetail { get; set; }
        public virtual DbSet<TblEmployer> TblEmployer { get; set; }
        public virtual DbSet<TblFamilyMember> TblFamilyMember { get; set; }
        public virtual DbSet<TblFamilyRelationShip> TblFamilyRelationShip { get; set; }
        public virtual DbSet<TblFinancialResult> TblFinancialResult { get; set; }
        public virtual DbSet<TblFiscalDomicile> TblFiscalDomicile { get; set; }
        public virtual DbSet<TblFrontend> TblFrontend { get; set; }
        public virtual DbSet<TblFronter> TblFronter { get; set; }
        public virtual DbSet<TblFsaCompanyRegistration> TblFsaCompanyRegistration { get; set; }
        public virtual DbSet<TblGeneralOwnershipInformation> TblGeneralOwnershipInformation { get; set; }
        public virtual DbSet<TblGovermentBody> TblGovermentBody { get; set; }
        public virtual DbSet<TblGraphicsDesigner> TblGraphicsDesigner { get; set; }
        public virtual DbSet<TblGuarantor> TblGuarantor { get; set; }
        public virtual DbSet<TblHeadOfHouseHold> TblHeadOfHouseHold { get; set; }
        public virtual DbSet<TblHealthCareProviderRegistration> TblHealthCareProviderRegistration { get; set; }
        public virtual DbSet<TblHealthInstitution> TblHealthInstitution { get; set; }
        public virtual DbSet<TblHospital> TblHospital { get; set; }
        public virtual DbSet<TblHospitalLicense> TblHospitalLicense { get; set; }
        public virtual DbSet<TblHostipalWard> TblHostipalWard { get; set; }
        public virtual DbSet<TblHouseholdRelationship> TblHouseholdRelationship { get; set; }
        public virtual DbSet<TblIdentityCard> TblIdentityCard { get; set; }
        public virtual DbSet<TblIncomeDetail> TblIncomeDetail { get; set; }
        public virtual DbSet<TblIncomeTaxRegistration> TblIncomeTaxRegistration { get; set; }
        public virtual DbSet<TblInpatient> TblInpatient { get; set; }
        public virtual DbSet<TblInsurancePoolRelationship> TblInsurancePoolRelationship { get; set; }
        public virtual DbSet<TblInsuranceProviderRegistration> TblInsuranceProviderRegistration { get; set; }
        public virtual DbSet<TblInsured> TblInsured { get; set; }
        public virtual DbSet<TblInsuredBorrower> TblInsuredBorrower { get; set; }
        public virtual DbSet<TblInsurer> TblInsurer { get; set; }
        public virtual DbSet<TblInternalMedicalApprover> TblInternalMedicalApprover { get; set; }
        public virtual DbSet<TblLender> TblLender { get; set; }
        public virtual DbSet<TblLessor> TblLessor { get; set; }
        public virtual DbSet<TblLossAdjuster> TblLossAdjuster { get; set; }
        public virtual DbSet<TblLtActivityTypeCodeList> TblLtActivityTypeCodeList { get; set; }
        public virtual DbSet<TblLtAgreementHolderRejectionCodeList> TblLtAgreementHolderRejectionCodeList { get; set; }
        public virtual DbSet<TblLtAgreementServicerTypeCodeList> TblLtAgreementServicerTypeCodeList { get; set; }
        public virtual DbSet<TblLtApplicabilityCodeList> TblLtApplicabilityCodeList { get; set; }
        public virtual DbSet<TblLtBeneficiaryDesignationCodeList> TblLtBeneficiaryDesignationCodeList { get; set; }
        public virtual DbSet<TblLtBenefitBeneficiaryTypeCodeList> TblLtBenefitBeneficiaryTypeCodeList { get; set; }
        public virtual DbSet<TblLtBenefitDistributionCalculationCodeList> TblLtBenefitDistributionCalculationCodeList { get; set; }
        public virtual DbSet<TblLtBloodTypeCodeList> TblLtBloodTypeCodeList { get; set; }
        public virtual DbSet<TblLtCivilRelationNatureCodeList> TblLtCivilRelationNatureCodeList { get; set; }
        public virtual DbSet<TblLtCivilStatusCodeList> TblLtCivilStatusCodeList { get; set; }
        public virtual DbSet<TblLtClaimExpertTypeCodeList> TblLtClaimExpertTypeCodeList { get; set; }
        public virtual DbSet<TblLtCompanyStatusCodeList> TblLtCompanyStatusCodeList { get; set; }
        public virtual DbSet<TblLtCountryCodeList> TblLtCountryCodeList { get; set; }
        public virtual DbSet<TblLtCriminalIncidentCodeList> TblLtCriminalIncidentCodeList { get; set; }
        public virtual DbSet<TblLtCriminalIncidentStatusCodeList> TblLtCriminalIncidentStatusCodeList { get; set; }
        public virtual DbSet<TblLtCriminalIncidentTypeCodeList> TblLtCriminalIncidentTypeCodeList { get; set; }
        public virtual DbSet<TblLtCustomerImportanceLevelCodeList> TblLtCustomerImportanceLevelCodeList { get; set; }
        public virtual DbSet<TblLtCustomerStatusCodeList> TblLtCustomerStatusCodeList { get; set; }
        public virtual DbSet<TblLtDomicileTaxCodeList> TblLtDomicileTaxCodeList { get; set; }
        public virtual DbSet<TblLtDrivingIncidentCodeList> TblLtDrivingIncidentCodeList { get; set; }
        public virtual DbSet<TblLtDrivingRestrictionsCodeList> TblLtDrivingRestrictionsCodeList { get; set; }
        public virtual DbSet<TblLtEducationCertificateCodeList> TblLtEducationCertificateCodeList { get; set; }
        public virtual DbSet<TblLtEducationCertificateTitleCodeList> TblLtEducationCertificateTitleCodeList { get; set; }
        public virtual DbSet<TblLtEducationGradeCodeList> TblLtEducationGradeCodeList { get; set; }
        public virtual DbSet<TblLtEthnicityCodeList> TblLtEthnicityCodeList { get; set; }
        public virtual DbSet<TblLtFamilyMemberTypeCodeList> TblLtFamilyMemberTypeCodeList { get; set; }
        public virtual DbSet<TblLtFamilyRelationCodeList> TblLtFamilyRelationCodeList { get; set; }
        public virtual DbSet<TblLtFrequency> TblLtFrequency { get; set; }
        public virtual DbSet<TblLtFsaCompanyRegistrationTypeCodeList> TblLtFsaCompanyRegistrationTypeCodeList { get; set; }
        public virtual DbSet<TblLtFundAsset> TblLtFundAsset { get; set; }
        public virtual DbSet<TblLtGenderCodeList> TblLtGenderCodeList { get; set; }
        public virtual DbSet<TblLtGrossMonthlyIncomeCodeList> TblLtGrossMonthlyIncomeCodeList { get; set; }
        public virtual DbSet<TblLtHealthCareProviderRegistrationTypeCodeList> TblLtHealthCareProviderRegistrationTypeCodeList { get; set; }
        public virtual DbSet<TblLtHealthInstitutionCodeList> TblLtHealthInstitutionCodeList { get; set; }
        public virtual DbSet<TblLtHomeOwnershipCodeList> TblLtHomeOwnershipCodeList { get; set; }
        public virtual DbSet<TblLtInsurableInterestCodeList> TblLtInsurableInterestCodeList { get; set; }
        public virtual DbSet<TblLtInsuredTypeCodeList> TblLtInsuredTypeCodeList { get; set; }
        public virtual DbSet<TblLtInsurerCodeList> TblLtInsurerCodeList { get; set; }
        public virtual DbSet<TblLtInsurerRejectionReasonCodeList> TblLtInsurerRejectionReasonCodeList { get; set; }
        public virtual DbSet<TblLtJobTitleCodeList> TblLtJobTitleCodeList { get; set; }
        public virtual DbSet<TblLtLanguageCode> TblLtLanguageCode { get; set; }
        public virtual DbSet<TblLtLastDischargeFacilityTypeCodeList> TblLtLastDischargeFacilityTypeCodeList { get; set; }
        public virtual DbSet<TblLtLegalEntityCodeList> TblLtLegalEntityCodeList { get; set; }
        public virtual DbSet<TblLtLicenseStatusCodeList> TblLtLicenseStatusCodeList { get; set; }
        public virtual DbSet<TblLtMaritalStatusCodeList> TblLtMaritalStatusCodeList { get; set; }
        public virtual DbSet<TblLtMembershipStatusCodeList> TblLtMembershipStatusCodeList { get; set; }
        public virtual DbSet<TblLtNaicsCode> TblLtNaicsCode { get; set; }
        public virtual DbSet<TblLtNationality> TblLtNationality { get; set; }
        public virtual DbSet<TblLtNatureOfInterestCodeList> TblLtNatureOfInterestCodeList { get; set; }
        public virtual DbSet<TblLtOrganizationDetail> TblLtOrganizationDetail { get; set; }
        public virtual DbSet<TblLtOrganizationDetailTypeCodeList> TblLtOrganizationDetailTypeCodeList { get; set; }
        public virtual DbSet<TblLtOrganizationNameUsageCodeList> TblLtOrganizationNameUsageCodeList { get; set; }
        public virtual DbSet<TblLtOrganizationStatusCodeList> TblLtOrganizationStatusCodeList { get; set; }
        public virtual DbSet<TblLtOrganizationTypeCodeList> TblLtOrganizationTypeCodeList { get; set; }
        public virtual DbSet<TblLtOrginazationUnitKindTypeCodeList> TblLtOrginazationUnitKindTypeCodeList { get; set; }
        public virtual DbSet<TblLtOwnershipCodeList> TblLtOwnershipCodeList { get; set; }
        public virtual DbSet<TblLtOwnershipTypeCodeList> TblLtOwnershipTypeCodeList { get; set; }
        public virtual DbSet<TblLtPartyDetailTypeCodeList> TblLtPartyDetailTypeCodeList { get; set; }
        public virtual DbSet<TblLtPartyRoleInProductTypeCodeList> TblLtPartyRoleInProductTypeCodeList { get; set; }
        public virtual DbSet<TblLtPartyRoleInRelationShipTypeCodeList> TblLtPartyRoleInRelationShipTypeCodeList { get; set; }
        public virtual DbSet<TblLtPartyRoleOnPhysicalObjectTypeCodeList> TblLtPartyRoleOnPhysicalObjectTypeCodeList { get; set; }
        public virtual DbSet<TblLtPartyRoleRegistrationCodeList> TblLtPartyRoleRegistrationCodeList { get; set; }
        public virtual DbSet<TblLtPartyRoleinAgreementTypeCodeList> TblLtPartyRoleinAgreementTypeCodeList { get; set; }
        public virtual DbSet<TblLtPartyRoleinMarketingTypeCodeList> TblLtPartyRoleinMarketingTypeCodeList { get; set; }
        public virtual DbSet<TblLtPartyTypeCodeList> TblLtPartyTypeCodeList { get; set; }
        public virtual DbSet<TblLtPatientTypeCodeList> TblLtPatientTypeCodeList { get; set; }
        public virtual DbSet<TblLtPersonDetailTypeCodeList> TblLtPersonDetailTypeCodeList { get; set; }
        public virtual DbSet<TblLtPersonNameUsageCodeList> TblLtPersonNameUsageCodeList { get; set; }
        public virtual DbSet<TblLtPersonRegistrationTypeCodeList> TblLtPersonRegistrationTypeCodeList { get; set; }
        public virtual DbSet<TblLtPhysicalObjectUserTypeCodeList> TblLtPhysicalObjectUserTypeCodeList { get; set; }
        public virtual DbSet<TblLtPilotLogTypeCodeList> TblLtPilotLogTypeCodeList { get; set; }
        public virtual DbSet<TblLtPrefixTitleCodeList> TblLtPrefixTitleCodeList { get; set; }
        public virtual DbSet<TblLtProducerRegistrationAuthorityCodeList> TblLtProducerRegistrationAuthorityCodeList { get; set; }
        public virtual DbSet<TblLtProducerRelationShipCodeList> TblLtProducerRelationShipCodeList { get; set; }
        public virtual DbSet<TblLtProducerRelationshipTypeCodeList> TblLtProducerRelationshipTypeCodeList { get; set; }
        public virtual DbSet<TblLtProficiencyLevelCodeList> TblLtProficiencyLevelCodeList { get; set; }
        public virtual DbSet<TblLtReferalCodeList> TblLtReferalCodeList { get; set; }
        public virtual DbSet<TblLtRelationShipDescriptionCodeList> TblLtRelationShipDescriptionCodeList { get; set; }
        public virtual DbSet<TblLtRepresentativeTypeCodeList> TblLtRepresentativeTypeCodeList { get; set; }
        public virtual DbSet<TblLtServiceProviderTypeCodeList> TblLtServiceProviderTypeCodeList { get; set; }
        public virtual DbSet<TblLtSicCode> TblLtSicCode { get; set; }
        public virtual DbSet<TblLtSignatoryDesignationCodeList> TblLtSignatoryDesignationCodeList { get; set; }
        public virtual DbSet<TblLtSubjectAreaCodeList> TblLtSubjectAreaCodeList { get; set; }
        public virtual DbSet<TblLtTaxCalculationCodeList> TblLtTaxCalculationCodeList { get; set; }
        public virtual DbSet<TblLtTaxRegistrationTypeCodeList> TblLtTaxRegistrationTypeCodeList { get; set; }
        public virtual DbSet<TblLtTaxonomyCodeList> TblLtTaxonomyCodeList { get; set; }
        public virtual DbSet<TblLtValidityCodeList> TblLtValidityCodeList { get; set; }
        public virtual DbSet<TblLtVehicleClassCodeList> TblLtVehicleClassCodeList { get; set; }
        public virtual DbSet<TblLtVirtualPartyNameCodeList> TblLtVirtualPartyNameCodeList { get; set; }
        public virtual DbSet<TblMarketingManager> TblMarketingManager { get; set; }
        public virtual DbSet<TblMarketingSpecialist> TblMarketingSpecialist { get; set; }
        public virtual DbSet<TblMedicalExaminer> TblMedicalExaminer { get; set; }
        public virtual DbSet<TblMedicalFacility> TblMedicalFacility { get; set; }
        public virtual DbSet<TblMedicalUnit> TblMedicalUnit { get; set; }
        public virtual DbSet<TblMembershipRegistration> TblMembershipRegistration { get; set; }
        public virtual DbSet<TblMilitaryRegistration> TblMilitaryRegistration { get; set; }
        public virtual DbSet<TblNotificationAuthority> TblNotificationAuthority { get; set; }
        public virtual DbSet<TblObligee> TblObligee { get; set; }
        public virtual DbSet<TblOccupant> TblOccupant { get; set; }
        public virtual DbSet<TblOperationsDetial> TblOperationsDetial { get; set; }
        public virtual DbSet<TblOpponentThirdParty> TblOpponentThirdParty { get; set; }
        public virtual DbSet<TblOrganization> TblOrganization { get; set; }
        public virtual DbSet<TblOrganizationDetail> TblOrganizationDetail { get; set; }
        public virtual DbSet<TblOrganizationLegalStatus> TblOrganizationLegalStatus { get; set; }
        public virtual DbSet<TblOrganizationName> TblOrganizationName { get; set; }
        public virtual DbSet<TblOrganizationRelationship> TblOrganizationRelationship { get; set; }
        public virtual DbSet<TblOrganizationUnit> TblOrganizationUnit { get; set; }
        public virtual DbSet<TblOtherHouseHoldMember> TblOtherHouseHoldMember { get; set; }
        public virtual DbSet<TblOutpatient> TblOutpatient { get; set; }
        public virtual DbSet<TblOwner> TblOwner { get; set; }
        public virtual DbSet<TblParentOrganization> TblParentOrganization { get; set; }
        public virtual DbSet<TblParty> TblParty { get; set; }
        public virtual DbSet<TblPartyDetail> TblPartyDetail { get; set; }
        public virtual DbSet<TblPartyName> TblPartyName { get; set; }
        public virtual DbSet<TblPartyRoleInAgreement> TblPartyRoleInAgreement { get; set; }
        public virtual DbSet<TblPartyRoleInProduct> TblPartyRoleInProduct { get; set; }
        public virtual DbSet<TblPartyRolePhysicalObject> TblPartyRolePhysicalObject { get; set; }
        public virtual DbSet<TblPartyRoleRegistration> TblPartyRoleRegistration { get; set; }
        public virtual DbSet<TblPartyRoleRelationship> TblPartyRoleRelationship { get; set; }
        public virtual DbSet<TblPartyRoleinMarketing> TblPartyRoleinMarketing { get; set; }
        public virtual DbSet<TblPartyRoleinRelationShip> TblPartyRoleinRelationShip { get; set; }
        public virtual DbSet<TblPassport> TblPassport { get; set; }
        public virtual DbSet<TblPatient> TblPatient { get; set; }
        public virtual DbSet<TblPayingServicer> TblPayingServicer { get; set; }
        public virtual DbSet<TblPerson> TblPerson { get; set; }
        public virtual DbSet<TblPersonDetail> TblPersonDetail { get; set; }
        public virtual DbSet<TblPersonName> TblPersonName { get; set; }
        public virtual DbSet<TblPersonReferalLink> TblPersonReferalLink { get; set; }
        public virtual DbSet<TblPersonRegistration> TblPersonRegistration { get; set; }
        public virtual DbSet<TblPersonalActivityLicence> TblPersonalActivityLicence { get; set; }
        public virtual DbSet<TblPhysicalObjectUser> TblPhysicalObjectUser { get; set; }
        public virtual DbSet<TblPilot> TblPilot { get; set; }
        public virtual DbSet<TblPilotLog> TblPilotLog { get; set; }
        public virtual DbSet<TblPlaintiff> TblPlaintiff { get; set; }
        public virtual DbSet<TblPostalAddress> TblPostalAddress { get; set; }
        public virtual DbSet<TblPremiumCollector> TblPremiumCollector { get; set; }
        public virtual DbSet<TblPremiumPayer> TblPremiumPayer { get; set; }
        public virtual DbSet<TblPrincipal> TblPrincipal { get; set; }
        public virtual DbSet<TblProducerRegistration> TblProducerRegistration { get; set; }
        public virtual DbSet<TblProducerRelationShip> TblProducerRelationShip { get; set; }
        public virtual DbSet<TblProductAdministrator> TblProductAdministrator { get; set; }
        public virtual DbSet<TblProductDistributor> TblProductDistributor { get; set; }
        public virtual DbSet<TblProductManager> TblProductManager { get; set; }
        public virtual DbSet<TblProjectManager> TblProjectManager { get; set; }
        public virtual DbSet<TblPropiertorTypeCodeList> TblPropiertorTypeCodeList { get; set; }
        public virtual DbSet<TblPropietor> TblPropietor { get; set; }
        public virtual DbSet<TblPropietorRelationship> TblPropietorRelationship { get; set; }
        public virtual DbSet<TblPropietorShip> TblPropietorShip { get; set; }
        public virtual DbSet<TblRegionalUnit> TblRegionalUnit { get; set; }
        public virtual DbSet<TblReinsurer> TblReinsurer { get; set; }
        public virtual DbSet<TblRepresentative> TblRepresentative { get; set; }
        public virtual DbSet<TblRepresentedParty> TblRepresentedParty { get; set; }
        public virtual DbSet<TblResidentRegistration> TblResidentRegistration { get; set; }
        public virtual DbSet<TblRiskManager> TblRiskManager { get; set; }
        public virtual DbSet<TblRolePersonPartyContactDetails> TblRolePersonPartyContactDetails { get; set; }
        public virtual DbSet<TblSalaryGradeCodeList> TblSalaryGradeCodeList { get; set; }
        public virtual DbSet<TblServiceProvider> TblServiceProvider { get; set; }
        public virtual DbSet<TblSignatory> TblSignatory { get; set; }
        public virtual DbSet<TblSpouse> TblSpouse { get; set; }
        public virtual DbSet<TblSurety> TblSurety { get; set; }
        public virtual DbSet<TblTaxRegistration> TblTaxRegistration { get; set; }
        public virtual DbSet<TblTeam> TblTeam { get; set; }
        public virtual DbSet<TblTelephoneNumber> TblTelephoneNumber { get; set; }
        public virtual DbSet<TblVehicleUser> TblVehicleUser { get; set; }
        public virtual DbSet<TblVictim> TblVictim { get; set; }
        public virtual DbSet<TblVirtualParty> TblVirtualParty { get; set; }
        public virtual DbSet<TblVirtualPartyLink> TblVirtualPartyLink { get; set; }
        public virtual DbSet<TblVirtualPartyName> TblVirtualPartyName { get; set; }
        public virtual DbSet<TblWitness> TblWitness { get; set; }
        public virtual DbSet<TlbStreetAddress> TlbStreetAddress { get; set; }
        public virtual DbSet<VwEmployee> VwEmployee { get; set; }
        public virtual DbSet<VwOrgDepartment> VwOrgDepartment { get; set; }
        public virtual DbSet<VwOrganization> VwOrganization { get; set; }
        public virtual DbSet<VwPartypersondetailbasic> VwPartypersondetailbasic { get; set; }
        public virtual DbSet<VwPersondetail> VwPersondetail { get; set; }
        public virtual DbSet<VwVirtualPartyPartyLink> VwVirtualPartyPartyLink { get; set; }
        public virtual DbSet<VwVirtualPartyPartyLinkV2> VwVirtualPartyPartyLinkV2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ttsaztopsqldev02.database.windows.net;Database=Party;User ID=gitsqladmin;Password=J0uM@s3P@55w0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbLLtNafCode>(entity =>
            {
                entity.HasKey(e => e.NafCodeId);

                entity.ToTable("TbL_lt_NafCode");

                entity.Property(e => e.NafCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NafCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAccountHolder>(entity =>
            {
                entity.HasKey(e => e.AccountHolderId);

                entity.ToTable("Tbl_AccountHolder");

                entity.Property(e => e.AccountHolderId).HasColumnName("AccountHolderID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblAccountHolder)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_AccountHolder_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblAccountProvider>(entity =>
            {
                entity.HasKey(e => e.AccountProviderId);

                entity.ToTable("Tbl_AccountProvider");

                entity.Property(e => e.AccountProviderId).HasColumnName("AccountProviderID");
            });

            modelBuilder.Entity<TblAdditionalInterest>(entity =>
            {
                entity.HasKey(e => e.AdditionalInterestId);

                entity.ToTable("Tbl_AdditionalInterest");

                entity.Property(e => e.AdditionalInterestId).HasColumnName("AdditionalInterestID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.NatureOfInterestCodeId).HasColumnName("NatureOfInterestCodeID");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.NatureOfInterestCode)
                    .WithMany(p => p.TblAdditionalInterest)
                    .HasForeignKey(d => d.NatureOfInterestCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_AdditionalInterest_Tbl_Lt_NatureOfInterestCodeList");
            });

            modelBuilder.Entity<TblAgreementApprover>(entity =>
            {
                entity.HasKey(e => e.AgreementApproverId);

                entity.ToTable("TBl_AgreementApprover");

                entity.Property(e => e.AgreementApproverId).HasColumnName("AgreementApproverID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblAgreementApprover)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBl_AgreementApprover_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblAgreementAuditor>(entity =>
            {
                entity.HasKey(e => e.AgreementAuditorId);

                entity.ToTable("Tbl_AgreementAuditor");

                entity.Property(e => e.AgreementAuditorId).HasColumnName("AgreementAuditorID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblAgreementAuditor)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_AgreementAuditor_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblAgreementHolder>(entity =>
            {
                entity.HasKey(e => e.AgreementHolderId);

                entity.ToTable("Tbl_AgreementHolder");

                entity.Property(e => e.AgreementHolderId).HasColumnName("AgreementHolderID");

                entity.Property(e => e.AgreementHolderRejectionCodeId).HasColumnName("AgreementHolderRejectionCodeID");

                entity.HasOne(d => d.AgreementHolderRejectionCode)
                    .WithMany(p => p.TblAgreementHolder)
                    .HasForeignKey(d => d.AgreementHolderRejectionCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_AgreementHolder_Tbl_Lt_AgreementHolderRejectionCodeList");
            });

            modelBuilder.Entity<TblAgreementManager>(entity =>
            {
                entity.HasKey(e => e.AgreementManagerId);

                entity.ToTable("Tbl_AgreementManager");

                entity.Property(e => e.AgreementManagerId).HasColumnName("AgreementManagerID");
            });

            modelBuilder.Entity<TblAgreementProducer>(entity =>
            {
                entity.HasKey(e => e.AgreementProducerId);

                entity.ToTable("Tbl_AgreementProducer");

                entity.Property(e => e.AgreementProducerId)
                    .HasColumnName("AgreementProducerID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TblAgreementRequester>(entity =>
            {
                entity.HasKey(e => e.AgreementRequesterId);

                entity.ToTable("Tbl_AgreementRequester");

                entity.Property(e => e.AgreementRequesterId).HasColumnName("AgreementRequesterID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblAgreementRequester)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_AgreementRequester_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblAgreementServicer>(entity =>
            {
                entity.HasKey(e => e.AgreementServicerId);

                entity.ToTable("Tbl_AgreementServicer");

                entity.Property(e => e.AgreementServicerId).HasColumnName("AgreementServicerID");

                entity.Property(e => e.AgreementServicerTypeCodeId).HasColumnName("AgreementServicerTypeCodeID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.Property(e => e.RepresentativeTypeCodeId).HasColumnName("RepresentativeTypeCodeID");

                entity.HasOne(d => d.AgreementServicerTypeCode)
                    .WithMany(p => p.TblAgreementServicer)
                    .HasForeignKey(d => d.AgreementServicerTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_AgreementServicer_Tbl_Lt_AgreementServicerTypeCodeList");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblAgreementServicer)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_AgreementServicer_Tbl_PartyRoleInAgreement");

                entity.HasOne(d => d.RepresentativeTypeCode)
                    .WithMany(p => p.TblAgreementServicer)
                    .HasForeignKey(d => d.RepresentativeTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_AgreementServicer_TBl_Lt_RepresentativeTypeCodeList");
            });

            modelBuilder.Entity<TblAgreementUnderwriter>(entity =>
            {
                entity.HasKey(e => e.AgreementUnderWriterId);

                entity.ToTable("Tbl_AgreementUnderwriter");

                entity.Property(e => e.AgreementUnderWriterId).HasColumnName("AgreementUnderWriterID");
            });

            modelBuilder.Entity<TblApplicant>(entity =>
            {
                entity.HasKey(e => e.ApplicantId);

                entity.ToTable("Tbl_Applicant");

                entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");

                entity.Property(e => e.AgreementTerminationReason)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.Property(e => e.TimeSinceAgreementTermination)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblApplicant)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Applicant_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblArtDirector>(entity =>
            {
                entity.HasKey(e => e.ArtDirector);

                entity.ToTable("Tbl_ArtDirector");

                entity.Property(e => e.PartyRoleinMarketingId).HasColumnName("PartyRoleinMarketingID");

                entity.HasOne(d => d.PartyRoleinMarketing)
                    .WithMany(p => p.TblArtDirector)
                    .HasForeignKey(d => d.PartyRoleinMarketingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ArtDirector_Tbl_PartyRoleinMarketing");
            });

            modelBuilder.Entity<TblAssignee>(entity =>
            {
                entity.HasKey(e => e.AssigneeId);

                entity.ToTable("Tbl_Assignee");

                entity.Property(e => e.AssigneeId).HasColumnName("AssigneeID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblAssignee)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Assignee_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblBankDistributionRelationship>(entity =>
            {
                entity.HasKey(e => e.BankDistributionRelationshipId);

                entity.ToTable("Tbl_BankDistributionRelationship");

                entity.Property(e => e.BankDistributionRelationshipId)
                    .HasColumnName("BankDistributionRelationshipID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblBankDistributionRelationship)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_BankDistributionRelationship_Tbl_PartyRoleRelationship");
            });

            modelBuilder.Entity<TblBankRegistration>(entity =>
            {
                entity.HasKey(e => e.BankRegistrationId);

                entity.ToTable("Tbl_BankRegistration");

                entity.Property(e => e.BankRegistrationId).HasColumnName("BankRegistrationID");

                entity.Property(e => e.FsaCompanyRegistrationId).HasColumnName("FSA_CompanyRegistrationID");

                entity.HasOne(d => d.FsaCompanyRegistration)
                    .WithMany(p => p.TblBankRegistration)
                    .HasForeignKey(d => d.FsaCompanyRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_BankRegistration_Tbl_FSA_CompanyRegistration");
            });

            modelBuilder.Entity<TblBeneficiary>(entity =>
            {
                entity.HasKey(e => e.BeneficiaryId);

                entity.ToTable("Tbl_Beneficiary");

                entity.Property(e => e.BeneficiaryId).HasColumnName("BeneficiaryID");

                entity.Property(e => e.AcceptedIndicator)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BeneficiaryDesignationCodeId).HasColumnName("BeneficiaryDesignationCodeID");

                entity.Property(e => e.BenefitDistributionCalculationCodeId).HasColumnName("BenefitDistributionCalculationCodeID");

                entity.Property(e => e.LegalWording)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.BeneficiaryDesignationCode)
                    .WithMany(p => p.TblBeneficiary)
                    .HasForeignKey(d => d.BeneficiaryDesignationCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Beneficiary_Tbl_Lt_BeneficiaryDesignationCodeList");

                entity.HasOne(d => d.BenefitDistributionCalculationCode)
                    .WithMany(p => p.TblBeneficiary)
                    .HasForeignKey(d => d.BenefitDistributionCalculationCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Beneficiary_Tbl_Lt_BenefitDistributionCalculationCodeList");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblBeneficiary)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Beneficiary_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblBenefitBeneficiary>(entity =>
            {
                entity.HasKey(e => e.BenefitBeneficiaryId);

                entity.ToTable("Tbl_BenefitBeneficiary");

                entity.Property(e => e.BenefitBeneficiaryId).HasColumnName("BenefitBeneficiaryID");

                entity.Property(e => e.BenefitBeneficiaryTypeCodeId).HasColumnName("BenefitBeneficiaryTypeCodeID");

                entity.Property(e => e.OwnershipCodeId).HasColumnName("OwnershipCodeID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");

                entity.Property(e => e.TelephoneContactAvailability)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Vip).HasColumnName("VIP");

                entity.HasOne(d => d.BenefitBeneficiaryTypeCode)
                    .WithMany(p => p.TblBenefitBeneficiary)
                    .HasForeignKey(d => d.BenefitBeneficiaryTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_BenefitBeneficiary_Tbl_Lt_BenefitBeneficiaryTypeCodeList");
            });

            modelBuilder.Entity<TblBiller>(entity =>
            {
                entity.HasKey(e => e.BillerId);

                entity.ToTable("Tbl_Biller");

                entity.Property(e => e.BillerId).HasColumnName("BillerID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblBiller)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Biller_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblBirthCertificate>(entity =>
            {
                entity.HasKey(e => e.BirthCertificateId);

                entity.ToTable("Tbl_BirthCertificate");

                entity.Property(e => e.BirthCertificateId).HasColumnName("BirthCertificateID");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.HasOne(d => d.PersonRegistration)
                    .WithMany(p => p.TblBirthCertificate)
                    .HasForeignKey(d => d.PersonRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_BirthCertificate_Tbl_PersonRegistration");
            });

            modelBuilder.Entity<TblBorrower>(entity =>
            {
                entity.HasKey(e => e.BorrowerId);

                entity.ToTable("Tbl_Borrower");

                entity.Property(e => e.BorrowerId).HasColumnName("BorrowerID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblBorrower)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Borrower_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblBranch>(entity =>
            {
                entity.HasKey(e => e.BranchId);

                entity.ToTable("Tbl_Branch");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationUnitId).HasColumnName("OrganizationUnitID");

                entity.HasOne(d => d.OrganizationUnit)
                    .WithMany(p => p.TblBranch)
                    .HasForeignKey(d => d.OrganizationUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Branch_Tbl_OrganizationUnit");
            });

            modelBuilder.Entity<TblCedent>(entity =>
            {
                entity.HasKey(e => e.CedentId);

                entity.ToTable("Tbl_Cedent");

                entity.Property(e => e.CedentId).HasColumnName("CedentID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblCedent)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Cedent_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblChildOrganization>(entity =>
            {
                entity.HasKey(e => e.ChildOrganizationId);

                entity.ToTable("Tbl_ChildOrganization");

                entity.Property(e => e.ChildOrganizationId).HasColumnName("ChildOrganizationID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblChildOrganization)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ChildOrganization_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblCivilRegistration>(entity =>
            {
                entity.HasKey(e => e.CivilRefistrationId);

                entity.ToTable("Tbl_CivilRegistration");

                entity.Property(e => e.CivilRefistrationId).HasColumnName("CivilRefistrationID");

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.HasOne(d => d.PersonRegistration)
                    .WithMany(p => p.TblCivilRegistration)
                    .HasForeignKey(d => d.PersonRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CivilRegistration_Tbl_PersonRegistration");
            });

            modelBuilder.Entity<TblCivilRelationShip>(entity =>
            {
                entity.HasKey(e => e.CivilRelationshipId);

                entity.ToTable("Tbl_CivilRelationShip");

                entity.Property(e => e.CivilRelationshipId).HasColumnName("CivilRelationshipID");

                entity.Property(e => e.CivilStatusCodeId).HasColumnName("CivilStatusCodeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.HasOne(d => d.CivilStatusCode)
                    .WithMany(p => p.TblCivilRelationShip)
                    .HasForeignKey(d => d.CivilStatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CivilRelationShip_Tbl_Lt_CivilStatusCodeList");

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblCivilRelationShip)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CivilRelationShip_Tbl_PartyRoleRelationship");
            });

            modelBuilder.Entity<TblClaimAdjuster>(entity =>
            {
                entity.HasKey(e => e.ClaimAdjusterId);

                entity.ToTable("Tbl_ClaimAdjuster");

                entity.Property(e => e.ClaimAdjusterId).HasColumnName("ClaimAdjusterID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblClaimDeclarer>(entity =>
            {
                entity.HasKey(e => e.ClaimDeclarerId);

                entity.ToTable("Tbl_ClaimDeclarer");

                entity.Property(e => e.ClaimDeclarerId).HasColumnName("ClaimDeclarerID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");

                entity.Property(e => e.RelationshipDescriptionCodeId).HasColumnName("RelationshipDescriptionCodeID");

                entity.HasOne(d => d.RelationshipDescriptionCode)
                    .WithMany(p => p.TblClaimDeclarer)
                    .HasForeignKey(d => d.RelationshipDescriptionCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ClaimDeclarer_Tbl_Lt_RelationShipDescriptionCodeList");
            });

            modelBuilder.Entity<TblClaimDriver>(entity =>
            {
                entity.HasKey(e => e.ClaimDriverId);

                entity.ToTable("Tbl_ClaimDriver");

                entity.Property(e => e.ClaimDriverId).HasColumnName("ClaimDriverID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblClaimExpert>(entity =>
            {
                entity.HasKey(e => e.ClaimExpertId);

                entity.ToTable("Tbl_ClaimExpert");

                entity.Property(e => e.ClaimExpertId).HasColumnName("ClaimExpertID");

                entity.Property(e => e.ClaimExportTypeCodeId).HasColumnName("ClaimExportTypeCodeID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");

                entity.HasOne(d => d.ClaimExportTypeCode)
                    .WithMany(p => p.TblClaimExpert)
                    .HasForeignKey(d => d.ClaimExportTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ClaimExpert_Tbl_Lt_ClaimExpertTypeCodeList");
            });

            modelBuilder.Entity<TblClaimLegalExpert>(entity =>
            {
                entity.HasKey(e => e.ClaimLegalExpertId);

                entity.ToTable("Tbl_ClaimLegalExpert");

                entity.Property(e => e.ClaimLegalExpertId).HasColumnName("ClaimLegalExpertID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblClaimPayor>(entity =>
            {
                entity.HasKey(e => e.ClaimPayorId);

                entity.ToTable("Tbl_ClaimPayor");

                entity.Property(e => e.ClaimPayorId).HasColumnName("ClaimPayorID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblClaimRecorder>(entity =>
            {
                entity.HasKey(e => e.ClaimRecorderId);

                entity.ToTable("Tbl_ClaimRecorder");

                entity.Property(e => e.ClaimRecorderId).HasColumnName("ClaimRecorderID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblClaimRepresentative>(entity =>
            {
                entity.HasKey(e => e.ClaimRepresentativeId);

                entity.ToTable("Tbl_ClaimRepresentative");

                entity.Property(e => e.ClaimRepresentativeId)
                    .HasColumnName("ClaimRepresentativeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblClaimant>(entity =>
            {
                entity.HasKey(e => e.ClaimantId);

                entity.ToTable("Tbl_Claimant");

                entity.Property(e => e.ClaimantId).HasColumnName("ClaimantID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblClaimee>(entity =>
            {
                entity.HasKey(e => e.ClaimeeId);

                entity.ToTable("Tbl_Claimee");

                entity.Property(e => e.ClaimeeId).HasColumnName("ClaimeeID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("Tbl_Company");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyStatusCodeListId).HasColumnName("CompanyStatusCodeListID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.StatusReason)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompanyStatusCodeList)
                    .WithMany(p => p.TblCompany)
                    .HasForeignKey(d => d.CompanyStatusCodeListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Company_Tbl_Lt_CompanyStatusCodeList");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblCompany)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Company_Tbl_Organization");
            });

            modelBuilder.Entity<TblContributionPayer>(entity =>
            {
                entity.HasKey(e => e.ContributionPayerId);

                entity.ToTable("Tbl_ContributionPayer");

                entity.Property(e => e.ContributionPayerId).HasColumnName("ContributionPayerID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblContributionPayer)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ContributionPayer_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblCopyEditor>(entity =>
            {
                entity.HasKey(e => e.CopyEditorId);

                entity.ToTable("Tbl_CopyEditor");

                entity.Property(e => e.CopyEditorId).HasColumnName("CopyEditorID");

                entity.Property(e => e.PartyRoleinMarketingId).HasColumnName("PartyRoleinMarketingID");

                entity.HasOne(d => d.PartyRoleinMarketing)
                    .WithMany(p => p.TblCopyEditor)
                    .HasForeignKey(d => d.PartyRoleinMarketingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CopyEditor_Tbl_PartyRoleinMarketing");
            });

            modelBuilder.Entity<TblCopyWriter>(entity =>
            {
                entity.HasKey(e => e.CopyWriterId);

                entity.ToTable("Tbl_CopyWriter");

                entity.Property(e => e.CopyWriterId)
                    .HasColumnName("CopyWriterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinMarketingId).HasColumnName("PartyRoleinMarketingID");

                entity.HasOne(d => d.PartyRoleinMarketing)
                    .WithMany(p => p.TblCopyWriter)
                    .HasForeignKey(d => d.PartyRoleinMarketingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CopyWriter_Tbl_PartyRoleinMarketing");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("Tbl_Country");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Capital)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCodeId).HasColumnName("CountryCodeID");

                entity.Property(e => e.FundAssetId).HasColumnName("FundAssetID");

                entity.HasOne(d => d.CountryCode)
                    .WithMany(p => p.TblCountry)
                    .HasForeignKey(d => d.CountryCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_Tbl_Lt_CountryCodeList");

                entity.HasOne(d => d.FundAsset)
                    .WithMany(p => p.TblCountry)
                    .HasForeignKey(d => d.FundAssetId)
                    .HasConstraintName("FK_Table_1_Tbl_lt_Fund_Asset");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.TblCountry)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_Table_1_Tbl_lt_Nationality");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblCountry)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_Tbl_Person");
            });

            modelBuilder.Entity<TblCreator>(entity =>
            {
                entity.HasKey(e => e.CreatorId);

                entity.ToTable("Tbl_Creator");

                entity.Property(e => e.CreatorId).HasColumnName("CreatorID");

                entity.HasOne(d => d.PartyRolePhysicalObjectNavigation)
                    .WithMany(p => p.TblCreator)
                    .HasForeignKey(d => d.PartyRolePhysicalObject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Creator_Tbl_PartyRolePhysicalObject");
            });

            modelBuilder.Entity<TblCreditor>(entity =>
            {
                entity.HasKey(e => e.CreditorId);

                entity.ToTable("Tbl_Creditor");

                entity.Property(e => e.CreditorId).HasColumnName("CreditorID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblCreditor)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Creditor_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblCriminalIncident>(entity =>
            {
                entity.HasKey(e => e.CriminalIncidentId);

                entity.ToTable("Tbl_CriminalIncident");

                entity.Property(e => e.CriminalIncidentId).HasColumnName("CriminalIncidentID");

                entity.Property(e => e.CriminalIncidentCodeId).HasColumnName("CriminalIncidentCodeID");

                entity.Property(e => e.CriminalIncidentStatusCodeId).HasColumnName("CriminalIncidentStatusCodeID");

                entity.Property(e => e.CriminalIncidentTypeCodeId).HasColumnName("CriminalIncidentTypeCodeID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.HasOne(d => d.CriminalIncidentCode)
                    .WithMany(p => p.TblCriminalIncident)
                    .HasForeignKey(d => d.CriminalIncidentCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CriminalIncident_Tbl_Lt_CriminalIncidentCodeList");

                entity.HasOne(d => d.CriminalIncidentStatusCode)
                    .WithMany(p => p.TblCriminalIncident)
                    .HasForeignKey(d => d.CriminalIncidentStatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CriminalIncident_Tbl_lt_CriminalIncidentStatusCodeList");

                entity.HasOne(d => d.CriminalIncidentTypeCode)
                    .WithMany(p => p.TblCriminalIncident)
                    .HasForeignKey(d => d.CriminalIncidentTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CriminalIncident_Tbl_Lt_CriminalIncidentTypeCodeList");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblCriminalIncident)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CriminalIncident_Tbl_Party");
            });

            modelBuilder.Entity<TblCustomerRelationship>(entity =>
            {
                entity.HasKey(e => e.CustomerRelationshipId);

                entity.ToTable("Tbl_CustomerRelationship");

                entity.Property(e => e.CustomerRelationshipId)
                    .HasColumnName("CustomerRelationshipID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommercialAssistanceDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEvalutation)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerImportanceLevelCodeId).HasColumnName("CustomerImportanceLevelCodeID");

                entity.Property(e => e.CustomerStatusCodeId).HasColumnName("CustomerStatusCodeID");

                entity.Property(e => e.FirstContactMethod)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LegalEntityCodeId).HasColumnName("LegalEntityCodeID");

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.Property(e => e.PotentialCommercialAssistanceDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Vip).HasColumnName("VIP");

                entity.HasOne(d => d.CustomerImportanceLevelCode)
                    .WithMany(p => p.TblCustomerRelationship)
                    .HasForeignKey(d => d.CustomerImportanceLevelCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerRelationship_Tbl_Lt_CustomerImportanceLevelCodeList");

                entity.HasOne(d => d.CustomerStatusCode)
                    .WithMany(p => p.TblCustomerRelationship)
                    .HasForeignKey(d => d.CustomerStatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerRelationship_Tbl_Lt_CustomerStatusCodeList");

                entity.HasOne(d => d.LegalEntityCode)
                    .WithMany(p => p.TblCustomerRelationship)
                    .HasForeignKey(d => d.LegalEntityCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerRelationship_Tbl_Lt_LegalEntityCodeList");

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblCustomerRelationship)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_CustomerRelationship_Tbl_PartyRoleRelationship");
            });

            modelBuilder.Entity<TblDeathCertificate>(entity =>
            {
                entity.HasKey(e => e.DeathCertificateId);

                entity.ToTable("Tbl_DeathCertificate");

                entity.Property(e => e.DeathCertificateId).HasColumnName("DeathCertificateID");

                entity.Property(e => e.DateOfDeath).HasColumnType("datetime");

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.HasOne(d => d.PersonRegistration)
                    .WithMany(p => p.TblDeathCertificate)
                    .HasForeignKey(d => d.PersonRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_DeathCertificate_Tbl_CivilRegistration");
            });

            modelBuilder.Entity<TblDefendant>(entity =>
            {
                entity.HasKey(e => e.DefendantId);

                entity.ToTable("Tbl_Defendant");

                entity.Property(e => e.DefendantId).HasColumnName("DefendantID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblDepartmentalUnit>(entity =>
            {
                entity.HasKey(e => e.DepartmentalUnitId);

                entity.ToTable("Tbl_DepartmentalUnit");

                entity.Property(e => e.DepartmentalUnitId).HasColumnName("DepartmentalUnitID");

                entity.Property(e => e.DepartmentalUnitCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentalUnitName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationUnitId).HasColumnName("OrganizationUnitID");

                entity.HasOne(d => d.OrganizationUnit)
                    .WithMany(p => p.TblDepartmentalUnit)
                    .HasForeignKey(d => d.OrganizationUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_DepartmentalUnit_Tbl_OrganizationUnit");
            });

            modelBuilder.Entity<TblDriverLicence>(entity =>
            {
                entity.HasKey(e => e.DriverLicenceId);

                entity.ToTable("Tbl_DriverLicence");

                entity.Property(e => e.DriverLicenceId).HasColumnName("DriverLicenceID");

                entity.Property(e => e.DrivingRestrinctionsCodeId).HasColumnName("DrivingRestrinctionsCodeID");

                entity.Property(e => e.LicenceStatusCodeId).HasColumnName("LicenceStatusCodeID");

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.HasOne(d => d.DrivingRestrinctionsCode)
                    .WithMany(p => p.TblDriverLicence)
                    .HasForeignKey(d => d.DrivingRestrinctionsCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_DriverLicence_Tbl_Lt_DrivingRestrictionsCodeList");

                entity.HasOne(d => d.LicenceStatusCode)
                    .WithMany(p => p.TblDriverLicence)
                    .HasForeignKey(d => d.LicenceStatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_DriverLicence_Tbl_Lt_LicenseStatusCodeList");
            });

            modelBuilder.Entity<TblDriverLicenseClassification>(entity =>
            {
                entity.HasKey(e => e.DriverLicenseClassificationId);

                entity.ToTable("Tbl_DriverLicenseClassification");

                entity.Property(e => e.DriverLicenseClassificationId).HasColumnName("DriverLicenseClassificationID");

                entity.Property(e => e.ComerialEndorsement)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DriverLicenceId).HasColumnName("DriverLicenceID");

                entity.Property(e => e.VehicleClassCodeId).HasColumnName("VehicleClassCodeID");

                entity.Property(e => e.VehicleSubClass)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.DriverLicence)
                    .WithMany(p => p.TblDriverLicenseClassification)
                    .HasForeignKey(d => d.DriverLicenceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_DriverLicenseClassification_Tbl_DriverLicence");

                entity.HasOne(d => d.VehicleClassCode)
                    .WithMany(p => p.TblDriverLicenseClassification)
                    .HasForeignKey(d => d.VehicleClassCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_DriverLicenseClassification_Tbl_Lt_VehicleClassCodeList");
            });

            modelBuilder.Entity<TblDrivingIncident>(entity =>
            {
                entity.HasKey(e => e.DrivingIncidentId);

                entity.ToTable("Tbl_DrivingIncident");

                entity.Property(e => e.DrivingIncidentId).HasColumnName("DrivingIncidentID");

                entity.Property(e => e.DrivingIncidentCodeId).HasColumnName("DrivingIncidentCodeID");

                entity.Property(e => e.PartyDetailId).HasColumnName("PartyDetailID");

                entity.HasOne(d => d.DrivingIncidentCode)
                    .WithMany(p => p.TblDrivingIncident)
                    .HasForeignKey(d => d.DrivingIncidentCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_DrivingIncident_Tbl_Lt_DrivingIncidentCodeList");

                entity.HasOne(d => d.PartyDetail)
                    .WithMany(p => p.TblDrivingIncident)
                    .HasForeignKey(d => d.PartyDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_DrivingIncident_Tbl_Party_Detail");
            });

            modelBuilder.Entity<TblEducationCertificate>(entity =>
            {
                entity.HasKey(e => e.EducationCertificateId);

                entity.ToTable("Tbl_EducationCertificate");

                entity.HasIndex(e => new { e.Name, e.EducationCertificateId, e.PersonRegistrationId, e.EducationGradeCodeId, e.SubjectAreaCodeId })
                    .HasName("IX_Tbl_EducationCertificate")
                    .IsUnique();

                entity.Property(e => e.EducationCertificateId).HasColumnName("EducationCertificateID");

                entity.Property(e => e.EducationCertificateCodeId).HasColumnName("EducationCertificateCodeID");

                entity.Property(e => e.EducationCertificateTitleCodeId).HasColumnName("EducationCertificateTitleCodeID");

                entity.Property(e => e.EducationGradeCodeId).HasColumnName("EducationGradeCodeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.Property(e => e.SubjectAreaCodeId).HasColumnName("SubjectAreaCodeID");

                entity.HasOne(d => d.EducationCertificateCode)
                    .WithMany(p => p.TblEducationCertificate)
                    .HasForeignKey(d => d.EducationCertificateCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EducationCertificate_Tbl_Lt_EducationCertificateCodeList");

                entity.HasOne(d => d.EducationCertificateTitleCode)
                    .WithMany(p => p.TblEducationCertificate)
                    .HasForeignKey(d => d.EducationCertificateTitleCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EducationCertificate_Tbl_Lt_EducationCertificateTitleCodeList");

                entity.HasOne(d => d.EducationGradeCode)
                    .WithMany(p => p.TblEducationCertificate)
                    .HasForeignKey(d => d.EducationGradeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EducationCertificate_Tbl_Lt_EducationGradeCodeList");

                entity.HasOne(d => d.PersonRegistration)
                    .WithMany(p => p.TblEducationCertificate)
                    .HasForeignKey(d => d.PersonRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EducationCertificate_Tbl_PersonRegistration");

                entity.HasOne(d => d.SubjectAreaCode)
                    .WithMany(p => p.TblEducationCertificate)
                    .HasForeignKey(d => d.SubjectAreaCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_EducationCertificate_Tbl_Lt_SubjectAreaCodeList");
            });

            modelBuilder.Entity<TblEmailContact>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tbl_EmailContact");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PkemailContactId).HasColumnName("PKEmailContactID");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("Tbl_Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitleCodeId).HasColumnName("JobTitleCodeID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.Property(e => e.ProficiencyLevelCodeId).HasColumnName("ProficiencyLevelCodeID");

                entity.Property(e => e.SalaryGradeCodeId).HasColumnName("SalaryGradeCodeID");

                entity.HasOne(d => d.JobTitleCode)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.JobTitleCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_Lt_JobTitleCodeList");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_PartyRoleinRelationShip");

                entity.HasOne(d => d.ProficiencyLevelCode)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.ProficiencyLevelCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_lt_ProficiencyLevelCodeList");

                entity.HasOne(d => d.SalaryGradeCode)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.SalaryGradeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Employee_Tbl_SalaryGradeCodeList");
            });

            modelBuilder.Entity<TblEmployeeSummeryDetail>(entity =>
            {
                entity.HasKey(e => e.EmployeeSummeryDetailId)
                    .HasName("PK_Table_1_1");

                entity.ToTable("Tbl_EmployeeSummeryDetail");

                entity.Property(e => e.EmployeeSummeryDetailId).HasColumnName("EmployeeSummeryDetailID");

                entity.Property(e => e.AverageEmployeeAge).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AverageEmployeeCount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EmployeeTurnoverPercentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FemaleStaffPercentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaleStaffPercentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalWagesPaidAmount).HasColumnType("money");
            });

            modelBuilder.Entity<TblEmployer>(entity =>
            {
                entity.HasKey(e => e.EmployerId);

                entity.ToTable("Tbl_Employer");

                entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblEmployer)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Employer_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblFamilyMember>(entity =>
            {
                entity.HasKey(e => e.FamilyMemberId);

                entity.ToTable("Tbl_FamilyMember");

                entity.Property(e => e.FamilyMemberId).HasColumnName("FamilyMemberID");

                entity.Property(e => e.FamilyMemberTypeCodeId).HasColumnName("FamilyMemberTypeCodeID");

                entity.Property(e => e.FamilyRelationShipId).HasColumnName("FamilyRelationShipID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.FamilyMemberTypeCode)
                    .WithMany(p => p.TblFamilyMember)
                    .HasForeignKey(d => d.FamilyMemberTypeCodeId)
                    .HasConstraintName("FK_Tbl_FamilyMember_Tbl_Lt_FamilyMemberTypeCodeList");

                entity.HasOne(d => d.FamilyRelationShip)
                    .WithMany(p => p.TblFamilyMember)
                    .HasForeignKey(d => d.FamilyRelationShipId)
                    .HasConstraintName("FK_Tbl_FamilyMember_Tbl_Lt_FamilyRelationCodeList");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblFamilyMember)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .HasConstraintName("FK_Tbl_FamilyMember_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblFamilyRelationShip>(entity =>
            {
                entity.HasKey(e => e.FamilyRelationShipId);

                entity.ToTable("Tbl_FamilyRelationShip");

                entity.Property(e => e.FamilyRelationShipId).HasColumnName("FamilyRelationShipID");

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblFamilyRelationShip)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_FamilyRelationShip_Tbl_PartyRoleRelationship");
            });

            modelBuilder.Entity<TblFinancialResult>(entity =>
            {
                entity.HasKey(e => e.FinancialResultId)
                    .HasName("PK_Tbl_Lt_FinancialResult");

                entity.ToTable("Tbl_FinancialResult");

                entity.Property(e => e.FinancialResultId).HasColumnName("FinancialResultID");

                entity.Property(e => e.ChangedValueAmount).HasColumnType("money");

                entity.Property(e => e.DividentPerShareAmount).HasColumnType("money");

                entity.Property(e => e.EarningsPerShareAmount).HasColumnType("money");

                entity.Property(e => e.EbitAmount).HasColumnType("money");

                entity.Property(e => e.EbitadaAmount).HasColumnType("money");

                entity.Property(e => e.EbtAmount).HasColumnType("money");

                entity.Property(e => e.GrossEarningsAmount).HasColumnType("money");

                entity.Property(e => e.GrossProfitAmount).HasColumnType("money");

                entity.Property(e => e.InterestPaidAmount).HasColumnType("money");

                entity.Property(e => e.InventoryTurnover).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.NetEarningsAmount).HasColumnType("money");

                entity.Property(e => e.NetResultAmount).HasColumnType("money");

                entity.Property(e => e.OperationsCostAmount).HasColumnType("money");

                entity.Property(e => e.ProfitAfterTaxAmount).HasColumnType("money");

                entity.Property(e => e.RevenueAmount).HasColumnType("money");

                entity.Property(e => e.TaxesPaidAmount).HasColumnType("money");
            });

            modelBuilder.Entity<TblFiscalDomicile>(entity =>
            {
                entity.HasKey(e => e.FiscalDomicleId);

                entity.ToTable("Tbl_FiscalDomicile");

                entity.Property(e => e.FiscalDomicleId).HasColumnName("FiscalDomicleID");

                entity.Property(e => e.DomicileTaxCodeId).HasColumnName("DomicileTaxCodeID");

                entity.HasOne(d => d.DomicileTaxCode)
                    .WithMany(p => p.TblFiscalDomicile)
                    .HasForeignKey(d => d.DomicileTaxCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_FiscalDomicile_Tbl_Lt_DomicileTaxCodeList");
            });

            modelBuilder.Entity<TblFrontend>(entity =>
            {
                entity.HasKey(e => e.FrontendId);

                entity.ToTable("Tbl_Frontend");

                entity.Property(e => e.FrontendId).HasColumnName("FrontendID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblFrontend)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Frontend_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblFronter>(entity =>
            {
                entity.HasKey(e => e.FronterId);

                entity.ToTable("Tbl_Fronter");

                entity.Property(e => e.FronterId).HasColumnName("FronterID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblFronter)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Fronter_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblFsaCompanyRegistration>(entity =>
            {
                entity.HasKey(e => e.FsaCompanyRegistrationId);

                entity.ToTable("Tbl_FSA_CompanyRegistration");

                entity.Property(e => e.FsaCompanyRegistrationId).HasColumnName("FSA_CompanyRegistrationID");

                entity.Property(e => e.FsacompanyRegistrationTypeCodeId).HasColumnName("FSACompanyRegistrationTypeCodeID");

                entity.Property(e => e.PartyRoleRegistrationId).HasColumnName("PartyRoleRegistrationID");

                entity.HasOne(d => d.FsacompanyRegistrationTypeCode)
                    .WithMany(p => p.TblFsaCompanyRegistration)
                    .HasForeignKey(d => d.FsacompanyRegistrationTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_FSA_CompanyRegistration_Tbl_Lt_FSA_CompanyRegistrationTypeCodeList");

                entity.HasOne(d => d.PartyRoleRegistration)
                    .WithMany(p => p.TblFsaCompanyRegistration)
                    .HasForeignKey(d => d.PartyRoleRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_FSA_CompanyRegistration_Tbl_PartyRoleRegistration");
            });

            modelBuilder.Entity<TblGeneralOwnershipInformation>(entity =>
            {
                entity.HasKey(e => e.GeneralOwnershipinformationId);

                entity.ToTable("Tbl_GeneralOwnershipInformation");

                entity.Property(e => e.GeneralOwnershipinformationId).HasColumnName("GeneralOwnershipinformationID");

                entity.Property(e => e.OwnershipTypeCodeId).HasColumnName("OwnershipTypeCodeID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.HasOne(d => d.OwnershipTypeCode)
                    .WithMany(p => p.TblGeneralOwnershipInformation)
                    .HasForeignKey(d => d.OwnershipTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_GeneralOwnershipInformation_Tbl_Lt_OwnershipTypeCodeList");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblGeneralOwnershipInformation)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_GeneralOwnershipInformation_Tbl_Party");
            });

            modelBuilder.Entity<TblGovermentBody>(entity =>
            {
                entity.HasKey(e => e.GovermentBodyId);

                entity.ToTable("Tbl_GovermentBody");

                entity.Property(e => e.GovermentBodyId).HasColumnName("GovermentBodyID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblGovermentBody)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_GovermentBody_Tbl_Organization");
            });

            modelBuilder.Entity<TblGraphicsDesigner>(entity =>
            {
                entity.HasKey(e => e.GraphicsDesignerId);

                entity.ToTable("Tbl_GraphicsDesigner");

                entity.Property(e => e.GraphicsDesignerId)
                    .HasColumnName("GraphicsDesignerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinMarketingId).HasColumnName("PartyRoleinMarketingID");

                entity.HasOne(d => d.PartyRoleinMarketing)
                    .WithMany(p => p.TblGraphicsDesigner)
                    .HasForeignKey(d => d.PartyRoleinMarketingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_GraphicsDesigner_Tbl_PartyRoleinMarketing");
            });

            modelBuilder.Entity<TblGuarantor>(entity =>
            {
                entity.HasKey(e => e.GuarantorId);

                entity.ToTable("Tbl_Guarantor");

                entity.Property(e => e.GuarantorId).HasColumnName("GuarantorID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblGuarantor)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Guarantor_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblHeadOfHouseHold>(entity =>
            {
                entity.HasKey(e => e.HeadOfHouseHoldId);

                entity.ToTable("Tbl_HeadOfHouseHold");

                entity.Property(e => e.HeadOfHouseHoldId).HasColumnName("HeadOfHouseHoldID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblHeadOfHouseHold)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_HeadOfHouseHold_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblHealthCareProviderRegistration>(entity =>
            {
                entity.HasKey(e => e.HealthCareProviderRegId);

                entity.ToTable("Tbl_HealthCareProviderRegistration");

                entity.Property(e => e.HealthCareProviderRegId).HasColumnName("HealthCareProviderRegID");

                entity.Property(e => e.HealthCareProvRegCodeId).HasColumnName("HealthCareProvRegCodeID");

                entity.Property(e => e.PartyRoleRegistrationId).HasColumnName("PartyRoleRegistrationID");

                entity.Property(e => e.TaxonomyCodeId).HasColumnName("TaxonomyCodeID");

                entity.HasOne(d => d.HealthCareProvRegCode)
                    .WithMany(p => p.TblHealthCareProviderRegistration)
                    .HasForeignKey(d => d.HealthCareProvRegCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_HealthCareProviderRegistration_Tbl_Lt_HealthCareProviderRegistrationTypeCodeList");

                entity.HasOne(d => d.PartyRoleRegistration)
                    .WithMany(p => p.TblHealthCareProviderRegistration)
                    .HasForeignKey(d => d.PartyRoleRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_HealthCareProviderRegistration_Tbl_PartyRoleRegistration");

                entity.HasOne(d => d.TaxonomyCode)
                    .WithMany(p => p.TblHealthCareProviderRegistration)
                    .HasForeignKey(d => d.TaxonomyCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_HealthCareProviderRegistration_Tbl_Lt_TaxonomyCodeList");
            });

            modelBuilder.Entity<TblHealthInstitution>(entity =>
            {
                entity.HasKey(e => e.HealthInstitutionId);

                entity.ToTable("Tbl_HealthInstitution");

                entity.Property(e => e.HealthInstitutionId).HasColumnName("HealthInstitutionID");

                entity.Property(e => e.HealthinstitutionTypeCodeId).HasColumnName("HealthinstitutionTypeCodeID");

                entity.HasOne(d => d.HealthinstitutionTypeCode)
                    .WithMany(p => p.TblHealthInstitution)
                    .HasForeignKey(d => d.HealthinstitutionTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_HealthInstitution_Tbl_Lt_HealthInstitutionCodeList");
            });

            modelBuilder.Entity<TblHospital>(entity =>
            {
                entity.HasKey(e => e.HospitalId);

                entity.ToTable("Tbl_Hospital");

                entity.Property(e => e.HospitalId).HasColumnName("HospitalID");

                entity.Property(e => e.HealthInstitutionId).HasColumnName("HealthInstitutionID");

                entity.Property(e => e.HospitalCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.HealthInstitution)
                    .WithMany(p => p.TblHospital)
                    .HasForeignKey(d => d.HealthInstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Hospital_Tbl_HealthInstitution");
            });

            modelBuilder.Entity<TblHospitalLicense>(entity =>
            {
                entity.HasKey(e => e.HospitalLicenseId);

                entity.ToTable("Tbl_HospitalLicense");

                entity.Property(e => e.HospitalLicenseId).HasColumnName("HospitalLicenseID");

                entity.Property(e => e.BedCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.HealthCareProviderRegId).HasColumnName("HealthCareProviderRegID");

                entity.HasOne(d => d.HealthCareProviderReg)
                    .WithMany(p => p.TblHospitalLicense)
                    .HasForeignKey(d => d.HealthCareProviderRegId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_HospitalLicense_Tbl_HealthCareProviderRegistration");
            });

            modelBuilder.Entity<TblHostipalWard>(entity =>
            {
                entity.HasKey(e => e.HospitalWardId);

                entity.ToTable("Tbl_HostipalWard");

                entity.Property(e => e.HospitalWardId).HasColumnName("HospitalWardID");

                entity.Property(e => e.HospitalWardCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalWardName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MedicalUnitId).HasColumnName("MedicalUnitID");

                entity.HasOne(d => d.MedicalUnit)
                    .WithMany(p => p.TblHostipalWard)
                    .HasForeignKey(d => d.MedicalUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_HostipalWard_Tbl_MedicalUnit");
            });

            modelBuilder.Entity<TblHouseholdRelationship>(entity =>
            {
                entity.HasKey(e => e.HouseholdRelationshipId);

                entity.ToTable("Tbl_HouseholdRelationship");

                entity.Property(e => e.HouseholdRelationshipId).HasColumnName("HouseholdRelationshipID");

                entity.Property(e => e.CrossMonthlyIncomeId).HasColumnName("CrossMonthlyIncomeID");

                entity.Property(e => e.HomeOwnerShipCodeId).HasColumnName("HomeOwnerShipCodeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.HasOne(d => d.CrossMonthlyIncome)
                    .WithMany(p => p.TblHouseholdRelationship)
                    .HasForeignKey(d => d.CrossMonthlyIncomeId)
                    .HasConstraintName("FK_Tbl_HouseholdRelationship_Tbl_Lt_GrossMonthlyIncomeCodeList");

                entity.HasOne(d => d.HomeOwnerShipCode)
                    .WithMany(p => p.TblHouseholdRelationship)
                    .HasForeignKey(d => d.HomeOwnerShipCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_HouseholdRelationship_Tbl_Lt_HomeOwnershipCodeList");

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblHouseholdRelationship)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_HouseholdRelationship_Tbl_PartyRoleRelationship");
            });

            modelBuilder.Entity<TblIdentityCard>(entity =>
            {
                entity.HasKey(e => e.IdentityCard);

                entity.ToTable("Tbl_IdentityCard");

                entity.Property(e => e.IdentityNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.Property(e => e.ValidityCodeId).HasColumnName("ValidityCodeID");

                entity.HasOne(d => d.PersonRegistration)
                    .WithMany(p => p.TblIdentityCard)
                    .HasForeignKey(d => d.PersonRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_IdentityCard_Tbl_PersonRegistration");

                entity.HasOne(d => d.ValidityCode)
                    .WithMany(p => p.TblIdentityCard)
                    .HasForeignKey(d => d.ValidityCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_IdentityCard_Tbl_Lt_ValidityCodeList");
            });

            modelBuilder.Entity<TblIncomeDetail>(entity =>
            {
                entity.HasKey(e => e.IncomeDetailId)
                    .HasName("PK_Table_1_2");

                entity.ToTable("Tbl_IncomeDetail");

                entity.Property(e => e.IncomeDetailId).HasColumnName("IncomeDetailID");

                entity.Property(e => e.FrequencyId).HasColumnName("FrequencyID");

                entity.Property(e => e.IndividualIncome).HasColumnType("money");

                entity.HasOne(d => d.Frequency)
                    .WithMany(p => p.TblIncomeDetail)
                    .HasForeignKey(d => d.FrequencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_IncomeDetail_Tbl_Lt_Frequency");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblIncomeDetail)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_Tbl_Person1");
            });

            modelBuilder.Entity<TblIncomeTaxRegistration>(entity =>
            {
                entity.HasKey(e => e.IncomeTaxRegistrationId);

                entity.ToTable("Tbl_IncomeTaxRegistration");

                entity.Property(e => e.IncomeTaxRegistrationId).HasColumnName("IncomeTaxRegistrationID");

                entity.Property(e => e.TaxRegistrationId).HasColumnName("TaxRegistrationID");

                entity.HasOne(d => d.TaxRegistration)
                    .WithMany(p => p.TblIncomeTaxRegistration)
                    .HasForeignKey(d => d.TaxRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_IncomeTaxRegistration_Tbl_TaxRegistration");
            });

            modelBuilder.Entity<TblInpatient>(entity =>
            {
                entity.HasKey(e => e.InpatientId);

                entity.ToTable("Tbl_Inpatient");

                entity.Property(e => e.InpatientId)
                    .HasColumnName("InpatientID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblInpatient)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Inpatient_Tbl_Patient");
            });

            modelBuilder.Entity<TblInsurancePoolRelationship>(entity =>
            {
                entity.HasKey(e => e.InsurancePoolRelationshipId);

                entity.ToTable("Tbl_InsurancePoolRelationship");

                entity.Property(e => e.InsurancePoolRelationshipId).HasColumnName("InsurancePoolRelationshipID");

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblInsurancePoolRelationship)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_InsurancePoolRelationship_Tbl_PartyRoleRelationship");
            });

            modelBuilder.Entity<TblInsuranceProviderRegistration>(entity =>
            {
                entity.HasKey(e => e.InsuranceProviderRegistration);

                entity.ToTable("Tbl_InsuranceProviderRegistration");

                entity.Property(e => e.FsaCompanyRegistrationId).HasColumnName("FSA_CompanyRegistrationID");

                entity.HasOne(d => d.FsaCompanyRegistration)
                    .WithMany(p => p.TblInsuranceProviderRegistration)
                    .HasForeignKey(d => d.FsaCompanyRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_InsuranceProviderRegistration_Tbl_FSA_CompanyRegistration");
            });

            modelBuilder.Entity<TblInsured>(entity =>
            {
                entity.HasKey(e => e.InsuredId);

                entity.ToTable("Tbl_Insured");

                entity.Property(e => e.InsuredId).HasColumnName("InsuredID");

                entity.Property(e => e.InsurableInterestCodeId).HasColumnName("InsurableInterestCodeID");

                entity.Property(e => e.InsuredTypeCodeId).HasColumnName("InsuredTypeCodeID");

                entity.Property(e => e.LegalWording)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.InsurableInterestCode)
                    .WithMany(p => p.TblInsured)
                    .HasForeignKey(d => d.InsurableInterestCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Insured_Tbl_Lt_InsurableInterestCodeList");

                entity.HasOne(d => d.InsuredTypeCode)
                    .WithMany(p => p.TblInsured)
                    .HasForeignKey(d => d.InsuredTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Insured_Tbl_Lt_InsuredTypeCodeList");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblInsured)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Insured_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblInsuredBorrower>(entity =>
            {
                entity.HasKey(e => e.InsuredBorrowerId);

                entity.ToTable("Tbl_InsuredBorrower");

                entity.Property(e => e.InsuredBorrowerId).HasColumnName("InsuredBorrowerID");

                entity.Property(e => e.BorrowerQuality)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblInsuredBorrower)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_InsuredBorrower_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblInsurer>(entity =>
            {
                entity.HasKey(e => e.InsurerId);

                entity.ToTable("Tbl_Insurer");

                entity.Property(e => e.InsurerId).HasColumnName("InsurerID");

                entity.Property(e => e.InsurerCodeId).HasColumnName("InsurerCodeID");

                entity.Property(e => e.InsurerRejectionReasonCodeId).HasColumnName("InsurerRejectionReasonCodeID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.InsurerCode)
                    .WithMany(p => p.TblInsurer)
                    .HasForeignKey(d => d.InsurerCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Insurer_Tbl_Lt_InsurerCodeList");

                entity.HasOne(d => d.InsurerRejectionReasonCode)
                    .WithMany(p => p.TblInsurer)
                    .HasForeignKey(d => d.InsurerRejectionReasonCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Insurer_Tbl_Lt_InsurerRejectionReasonCodeList");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblInsurer)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Insurer_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblInternalMedicalApprover>(entity =>
            {
                entity.HasKey(e => e.InternalMedicalApproverId);

                entity.ToTable("Tbl_InternalMedicalApprover");

                entity.Property(e => e.InternalMedicalApproverId)
                    .HasColumnName("InternalMedicalApproverID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblLender>(entity =>
            {
                entity.HasKey(e => e.LenderId);

                entity.ToTable("Tbl_Lender");

                entity.Property(e => e.LenderId).HasColumnName("LenderID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblLender)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Lender_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblLessor>(entity =>
            {
                entity.HasKey(e => e.LessorId);

                entity.ToTable("Tbl_Lessor");

                entity.Property(e => e.LessorId).HasColumnName("LessorID");

                entity.Property(e => e.PhysicalObjectUserId).HasColumnName("PhysicalObjectUserID");

                entity.HasOne(d => d.PhysicalObjectUser)
                    .WithMany(p => p.TblLessor)
                    .HasForeignKey(d => d.PhysicalObjectUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Lessor_Tbl_PhysicalObjectUser");
            });

            modelBuilder.Entity<TblLossAdjuster>(entity =>
            {
                entity.HasKey(e => e.LossAdjusterId);

                entity.ToTable("Tbl_LossAdjuster");

                entity.Property(e => e.LossAdjusterId).HasColumnName("LossAdjusterID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblLtActivityTypeCodeList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tbl_Lt_ActivityTypeCodeList");

                entity.Property(e => e.ActivityTypeCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityTypeCodeDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityTypeCodeId).HasColumnName("ActivityTypeCodeID");
            });

            modelBuilder.Entity<TblLtAgreementHolderRejectionCodeList>(entity =>
            {
                entity.HasKey(e => e.AgreementHolderRejectionCodeId);

                entity.ToTable("Tbl_Lt_AgreementHolderRejectionCodeList");

                entity.HasIndex(e => e.AgreementHolderRejectionCode)
                    .HasName("IX_Tbl_Lt_AgreementHolderRejectionCodeList")
                    .IsUnique();

                entity.Property(e => e.AgreementHolderRejectionCodeId).HasColumnName("AgreementHolderRejectionCodeID");

                entity.Property(e => e.AgreementHolderRejectionCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AgreementHolderRejectionCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtAgreementServicerTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.AgreementServicerTypeCodeId);

                entity.ToTable("Tbl_Lt_AgreementServicerTypeCodeList");

                entity.HasIndex(e => e.AgreementServicerTypeCode)
                    .HasName("IX_Tbl_Lt_AgreementServicerTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.AgreementServicerTypeCodeId).HasColumnName("AgreementServicerTypeCodeID");

                entity.Property(e => e.AgreementServicerTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AgreementServicerTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtApplicabilityCodeList>(entity =>
            {
                entity.HasKey(e => e.ApplicabilityCodeId);

                entity.ToTable("Tbl_lt_ApplicabilityCodeList");

                entity.HasIndex(e => e.ApplicabilityCode)
                    .HasName("IX_Tbl_lt_ApplicabilityCodeList")
                    .IsUnique();

                entity.Property(e => e.ApplicabilityCodeId).HasColumnName("ApplicabilityCodeID");

                entity.Property(e => e.ApplicabilityCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicabilityCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtBeneficiaryDesignationCodeList>(entity =>
            {
                entity.HasKey(e => e.BeneficiaryDesignationCodeId);

                entity.ToTable("Tbl_Lt_BeneficiaryDesignationCodeList");

                entity.HasIndex(e => e.BeneficiaryDesignationCode)
                    .HasName("IX_Tbl_Lt_BeneficiaryDesignationCodeList")
                    .IsUnique();

                entity.Property(e => e.BeneficiaryDesignationCodeId).HasColumnName("BeneficiaryDesignationCodeID");

                entity.Property(e => e.BeneficiaryDesignationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BeneficiaryDesignationCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtBenefitBeneficiaryTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.BenefitBeneficiaryTypeCodeId);

                entity.ToTable("Tbl_Lt_BenefitBeneficiaryTypeCodeList");

                entity.HasIndex(e => e.BenefitBeneficiaryTypeCode)
                    .HasName("IX_Tbl_Lt_BenefitBeneficiaryTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.BenefitBeneficiaryTypeCodeId).HasColumnName("BenefitBeneficiaryTypeCodeID");

                entity.Property(e => e.BenefitBeneficiaryTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BenefitBeneficiaryTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtBenefitDistributionCalculationCodeList>(entity =>
            {
                entity.HasKey(e => e.BenefitDistributionCalculationCodeId);

                entity.ToTable("Tbl_Lt_BenefitDistributionCalculationCodeList");

                entity.HasIndex(e => e.BenefitDistributionCalculationCode)
                    .HasName("IX_Tbl_Lt_BenefitDistributionCalculationCodeList")
                    .IsUnique();

                entity.Property(e => e.BenefitDistributionCalculationCodeId).HasColumnName("BenefitDistributionCalculationCodeID");

                entity.Property(e => e.BenefitDistributionCalculationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BenefitDistributionCalculationCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtBloodTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.BloodTypeCodeId);

                entity.ToTable("Tbl_Lt_BloodTypeCodeList");

                entity.HasIndex(e => e.BloodTypeCode)
                    .HasName("IX_Tbl_Lt_BloodTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.BloodTypeCodeId).HasColumnName("BloodTypeCodeID");

                entity.Property(e => e.BloodTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BloodTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtCivilRelationNatureCodeList>(entity =>
            {
                entity.HasKey(e => e.CivilRelationNatureCodeId);

                entity.ToTable("Tbl_Lt_CivilRelationNatureCodeList");

                entity.HasIndex(e => e.CivilRelationNatureCode)
                    .HasName("IX_Tbl_Lt_CivilRelationNatureCodeList")
                    .IsUnique();

                entity.Property(e => e.CivilRelationNatureCodeId)
                    .HasColumnName("CivilRelationNatureCodeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CivilRelationNatureCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CivilRelationNatureCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtCivilStatusCodeList>(entity =>
            {
                entity.HasKey(e => e.CivilStatusCodeId);

                entity.ToTable("Tbl_Lt_CivilStatusCodeList");

                entity.HasIndex(e => e.CivilStatusCode)
                    .HasName("IX_Tbl_Lt_CivilStatusCodeList")
                    .IsUnique();

                entity.Property(e => e.CivilStatusCodeId)
                    .HasColumnName("CivilStatusCodeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CivilStatusCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CivilStatusCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtClaimExpertTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.ClaimExportTypeCodeId);

                entity.ToTable("Tbl_Lt_ClaimExpertTypeCodeList");

                entity.HasIndex(e => e.ClaimExportTypeCode)
                    .HasName("IX_Tbl_Lt_ClaimExpertTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.ClaimExportTypeCodeId).HasColumnName("ClaimExportTypeCodeID");

                entity.Property(e => e.ClaimExportTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClaimExportTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtCompanyStatusCodeList>(entity =>
            {
                entity.HasKey(e => e.CompanyStatusCodeListId);

                entity.ToTable("Tbl_Lt_CompanyStatusCodeList");

                entity.Property(e => e.CompanyStatusCodeListId).HasColumnName("CompanyStatusCodeListID");

                entity.Property(e => e.CompanyStatusCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyStatusCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtCountryCodeList>(entity =>
            {
                entity.HasKey(e => e.CountryCodeId);

                entity.ToTable("Tbl_Lt_CountryCodeList");

                entity.Property(e => e.CountryCodeId).HasColumnName("CountryCodeID");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtCriminalIncidentCodeList>(entity =>
            {
                entity.HasKey(e => e.CriminalIncidentCodeId);

                entity.ToTable("Tbl_Lt_CriminalIncidentCodeList");

                entity.Property(e => e.CriminalIncidentCodeId).HasColumnName("CriminalIncidentCodeID");

                entity.Property(e => e.CriminalIncidentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CriminalIncidentCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtCriminalIncidentStatusCodeList>(entity =>
            {
                entity.HasKey(e => e.CriminalIncidentStatusCodeId);

                entity.ToTable("Tbl_lt_CriminalIncidentStatusCodeList");

                entity.HasIndex(e => e.CriminalIncidentStatusCode)
                    .HasName("IX_Tbl_lt_CriminalIncidentStatusCodeList")
                    .IsUnique();

                entity.Property(e => e.CriminalIncidentStatusCodeId).HasColumnName("CriminalIncidentStatusCodeID");

                entity.Property(e => e.CriminalIncidentStatusCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CriminalIncidentStatusCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtCriminalIncidentTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.CriminalIncidentTypeCodeId);

                entity.ToTable("Tbl_Lt_CriminalIncidentTypeCodeList");

                entity.HasIndex(e => e.CriminalIncidentTypeCode)
                    .HasName("IX_Tbl_Lt_CriminalIncidentTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.CriminalIncidentTypeCodeId).HasColumnName("CriminalIncidentTypeCodeID");

                entity.Property(e => e.CriminalIncidentTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CriminalIncidentTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtCustomerImportanceLevelCodeList>(entity =>
            {
                entity.HasKey(e => e.CustomerImportanceLevelCodeId);

                entity.ToTable("Tbl_Lt_CustomerImportanceLevelCodeList");

                entity.HasIndex(e => e.CustomerImportanceLevelCode)
                    .HasName("IX_Tbl_Lt_CustomerImportanceLevelCodeList")
                    .IsUnique();

                entity.Property(e => e.CustomerImportanceLevelCodeId).HasColumnName("CustomerImportanceLevelCodeID");

                entity.Property(e => e.CustomerImportanceLevelCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerImportanceLevelCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtCustomerStatusCodeList>(entity =>
            {
                entity.HasKey(e => e.CustomerStatusCodeId);

                entity.ToTable("Tbl_Lt_CustomerStatusCodeList");

                entity.Property(e => e.CustomerStatusCodeId).HasColumnName("CustomerStatusCodeID");

                entity.Property(e => e.CustomerStatusCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerStatusCodeDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtDomicileTaxCodeList>(entity =>
            {
                entity.HasKey(e => e.DomicileTaxCodeId);

                entity.ToTable("Tbl_Lt_DomicileTaxCodeList");

                entity.HasIndex(e => e.DomicileTaxCode)
                    .HasName("IX_Tbl_Lt_DomicileTaxCodeList")
                    .IsUnique();

                entity.Property(e => e.DomicileTaxCodeId).HasColumnName("DomicileTaxCodeID");

                entity.Property(e => e.DomicileTaxCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DomicileTaxCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtDrivingIncidentCodeList>(entity =>
            {
                entity.HasKey(e => e.DrivingIncidentCodeId);

                entity.ToTable("Tbl_Lt_DrivingIncidentCodeList");

                entity.HasIndex(e => e.DrivingIncidentCode)
                    .HasName("IX_Tbl_Lt_DrivingIncidentCodeList")
                    .IsUnique();

                entity.Property(e => e.DrivingIncidentCodeId).HasColumnName("DrivingIncidentCodeID");

                entity.Property(e => e.DrivingIncidentCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DrivingIncidentCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtDrivingRestrictionsCodeList>(entity =>
            {
                entity.HasKey(e => e.DrivingRestrinctionsCodeId);

                entity.ToTable("Tbl_Lt_DrivingRestrictionsCodeList");

                entity.HasIndex(e => e.DrivingRestrinctionsCode)
                    .HasName("IX_Tbl_Lt_DrivingRestrictionsCodeList")
                    .IsUnique();

                entity.Property(e => e.DrivingRestrinctionsCodeId).HasColumnName("DrivingRestrinctionsCodeID");

                entity.Property(e => e.DrivingRestrinctionsCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DrivingRestrinctionsCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtEducationCertificateCodeList>(entity =>
            {
                entity.HasKey(e => e.EducationCertificateCodeId);

                entity.ToTable("Tbl_Lt_EducationCertificateCodeList");

                entity.HasIndex(e => e.EducationCertificateCode)
                    .HasName("IX_Tbl_Lt_EducationCertificateCodeList")
                    .IsUnique();

                entity.Property(e => e.EducationCertificateCodeId).HasColumnName("EducationCertificateCodeID");

                entity.Property(e => e.EducationCertificateCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EducationCertificateCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtEducationCertificateTitleCodeList>(entity =>
            {
                entity.HasKey(e => e.EducationCertificateTitleCodeId);

                entity.ToTable("Tbl_Lt_EducationCertificateTitleCodeList");

                entity.HasIndex(e => e.EducationCertificateTitleCode)
                    .HasName("IX_Tbl_Lt_EducationCertificateTitleCodeList")
                    .IsUnique();

                entity.Property(e => e.EducationCertificateTitleCodeId).HasColumnName("EducationCertificateTitleCodeID");

                entity.Property(e => e.EducationCertificateTitleCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EducationCertificateTitleCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtEducationGradeCodeList>(entity =>
            {
                entity.HasKey(e => e.EducationGradeCodeId);

                entity.ToTable("Tbl_Lt_EducationGradeCodeList");

                entity.HasIndex(e => e.EducationGradeCode)
                    .HasName("IX_Tbl_Lt_EducationGradeCodeList")
                    .IsUnique();

                entity.Property(e => e.EducationGradeCodeId).HasColumnName("EducationGradeCodeID");

                entity.Property(e => e.EducationGradeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EducationGradeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtEthnicityCodeList>(entity =>
            {
                entity.HasKey(e => e.EthnicityId);

                entity.ToTable("Tbl_Lt_EthnicityCodeList");

                entity.HasIndex(e => e.EthnicityCode)
                    .HasName("IX_Tbl_Lt_EthnicityCodeList")
                    .IsUnique();

                entity.Property(e => e.EthnicityId).HasColumnName("EthnicityID");

                entity.Property(e => e.EthnicityCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EthnicityCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtFamilyMemberTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.FamilyMemberTypeCodeId);

                entity.ToTable("Tbl_Lt_FamilyMemberTypeCodeList");

                entity.HasIndex(e => e.FamilyMemberTypeCode)
                    .HasName("IX_Tbl_Lt_FamilyMemberTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.FamilyMemberTypeCodeId).HasColumnName("FamilyMemberTypeCodeID");

                entity.Property(e => e.FamilyMemberTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyMemberTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtFamilyRelationCodeList>(entity =>
            {
                entity.HasKey(e => e.FamilyRelationCodeId);

                entity.ToTable("Tbl_Lt_FamilyRelationCodeList");

                entity.HasIndex(e => e.FamilyRelationCode)
                    .HasName("IX_Tbl_Lt_FamilyRelationCodeList")
                    .IsUnique();

                entity.Property(e => e.FamilyRelationCodeId).HasColumnName("FamilyRelationCodeID");

                entity.Property(e => e.FamilyRelationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FamilyRelationCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtFrequency>(entity =>
            {
                entity.HasKey(e => e.FrequencyId);

                entity.ToTable("Tbl_Lt_Frequency");

                entity.Property(e => e.FrequencyId).HasColumnName("FrequencyID");

                entity.Property(e => e.FrequencyCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FrequencyCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtFsaCompanyRegistrationTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.FsacompanyRegistrationTypeCodeId);

                entity.ToTable("Tbl_Lt_FSA_CompanyRegistrationTypeCodeList");

                entity.HasIndex(e => e.FsacompanyRegistrationTypeCode)
                    .HasName("IX_Tbl_Lt_FSA_CompanyRegistrationTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.FsacompanyRegistrationTypeCodeId).HasColumnName("FSACompanyRegistrationTypeCodeID");

                entity.Property(e => e.FsacompanyRegistrationTypeCode)
                    .IsRequired()
                    .HasColumnName("FSACompanyRegistrationTypeCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FsacompanyRegistrationTypeCodeDesc)
                    .IsRequired()
                    .HasColumnName("FSACompanyRegistrationTypeCodeDesc")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtFundAsset>(entity =>
            {
                entity.HasKey(e => e.FundAssetId);

                entity.ToTable("Tbl_lt_Fund_Asset");

                entity.Property(e => e.FundAssetId)
                    .HasColumnName("FundAssetID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FundAssetCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FundAssetCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtGenderCodeList>(entity =>
            {
                entity.HasKey(e => e.GenderCodeId);

                entity.ToTable("Tbl_Lt_GenderCodeList");

                entity.HasIndex(e => e.GenderCode)
                    .HasName("IX_Tbl_Lt_GenderCodeList")
                    .IsUnique();

                entity.Property(e => e.GenderCodeId).HasColumnName("GenderCodeID");

                entity.Property(e => e.GenderCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GenderCodeDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtGrossMonthlyIncomeCodeList>(entity =>
            {
                entity.HasKey(e => e.CrossMonthlyIncomeId)
                    .HasName("PK_Tbl_Lt_CrossMonthlyIncomeCodeList");

                entity.ToTable("Tbl_Lt_GrossMonthlyIncomeCodeList");

                entity.Property(e => e.CrossMonthlyIncomeId).HasColumnName("CrossMonthlyIncomeID");

                entity.Property(e => e.CrossMonthlyIncomeCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrossMonthlyIncomeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtHealthCareProviderRegistrationTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.HealthCareProvRegCodeId);

                entity.ToTable("Tbl_Lt_HealthCareProviderRegistrationTypeCodeList");

                entity.HasIndex(e => e.HealthCareProvRegCode)
                    .HasName("IX_Tbl_Lt_HealthCareProviderRegistrationTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.HealthCareProvRegCodeId).HasColumnName("HealthCareProvRegCodeID");

                entity.Property(e => e.HealthCareProvRegCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HealthCareProvRegCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtHealthInstitutionCodeList>(entity =>
            {
                entity.HasKey(e => e.HealthinstitutionTypeCodeId);

                entity.ToTable("Tbl_Lt_HealthInstitutionCodeList");

                entity.Property(e => e.HealthinstitutionTypeCodeId).HasColumnName("HealthinstitutionTypeCodeID");

                entity.Property(e => e.HealthinstitutionTypeCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.HealthinstitutionTypeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtHomeOwnershipCodeList>(entity =>
            {
                entity.HasKey(e => e.HomeOwnerShipCodeId);

                entity.ToTable("Tbl_Lt_HomeOwnershipCodeList");

                entity.HasIndex(e => e.HomeOwnerShipCode)
                    .HasName("IX_Tbl_Lt_HomeOwnershipCodeList")
                    .IsUnique();

                entity.Property(e => e.HomeOwnerShipCodeId).HasColumnName("HomeOwnerShipCodeID");

                entity.Property(e => e.HomeOwnerShipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HomeOwnerShipCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtInsurableInterestCodeList>(entity =>
            {
                entity.HasKey(e => e.InsurableInterestCodeId);

                entity.ToTable("Tbl_Lt_InsurableInterestCodeList");

                entity.HasIndex(e => e.InsurableInterestCode)
                    .HasName("IX_Tbl_Lt_InsurableInterestCodeList")
                    .IsUnique();

                entity.Property(e => e.InsurableInterestCodeId).HasColumnName("InsurableInterestCodeID");

                entity.Property(e => e.InsurableInterestCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InsurableInterestCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtInsuredTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.InsuredTypeCodeId);

                entity.ToTable("Tbl_Lt_InsuredTypeCodeList");

                entity.HasIndex(e => e.InsuredTypeCode)
                    .HasName("IX_Tbl_Lt_InsuredTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.InsuredTypeCodeId).HasColumnName("InsuredTypeCodeID");

                entity.Property(e => e.InsuredTypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InsuredTypeCodeDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtInsurerCodeList>(entity =>
            {
                entity.HasKey(e => e.InsurerCodeId);

                entity.ToTable("Tbl_Lt_InsurerCodeList");

                entity.HasIndex(e => e.InsurerCode)
                    .HasName("IX_Tbl_Lt_InsurerCodeList")
                    .IsUnique();

                entity.Property(e => e.InsurerCodeId).HasColumnName("InsurerCodeID");

                entity.Property(e => e.InsurerCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InsurerCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtInsurerRejectionReasonCodeList>(entity =>
            {
                entity.HasKey(e => e.InsurerRejectionReasonCodeId);

                entity.ToTable("Tbl_Lt_InsurerRejectionReasonCodeList");

                entity.HasIndex(e => e.InsurerRejectionReasonCode)
                    .HasName("IX_Tbl_Lt_InsurerRejectionReasonCodeList")
                    .IsUnique();

                entity.Property(e => e.InsurerRejectionReasonCodeId).HasColumnName("InsurerRejectionReasonCodeID");

                entity.Property(e => e.InsurerRejectionReasonCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InsurerRejectionReasonCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtJobTitleCodeList>(entity =>
            {
                entity.HasKey(e => e.JobTitleCodeId);

                entity.ToTable("Tbl_Lt_JobTitleCodeList");

                entity.HasIndex(e => e.JobTitleCode)
                    .HasName("IX_Tbl_Lt_JobTitleCodeList")
                    .IsUnique();

                entity.Property(e => e.JobTitleCodeId).HasColumnName("JobTitleCodeID");

                entity.Property(e => e.JobTitleCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitleCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtLanguageCode>(entity =>
            {
                entity.HasKey(e => e.LanguageId);

                entity.ToTable("Tbl_Lt_LanguageCode");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtLastDischargeFacilityTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.LastDischargeFacilityTypeCodeId);

                entity.ToTable("Tbl_Lt_LastDischargeFacilityTypeCodeList");

                entity.HasIndex(e => e.LastDischargeFacilityTypeCode)
                    .HasName("IX_Tbl_Lt_LastDischargeFacilityTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.LastDischargeFacilityTypeCodeId).HasColumnName("LastDischargeFacilityTypeCodeID");

                entity.Property(e => e.LastDischargeFacilityTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastDischargeFacilityTypeCodeDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtLegalEntityCodeList>(entity =>
            {
                entity.HasKey(e => e.LegalEntityCodeId);

                entity.ToTable("Tbl_Lt_LegalEntityCodeList");

                entity.HasIndex(e => e.LegalEntityCode)
                    .HasName("IX_Tbl_Lt_LegalEntityCodeList")
                    .IsUnique();

                entity.Property(e => e.LegalEntityCodeId).HasColumnName("LegalEntityCodeID");

                entity.Property(e => e.LegalEntityCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LegalEntityCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtLicenseStatusCodeList>(entity =>
            {
                entity.HasKey(e => e.LicenceStatusCodeId);

                entity.ToTable("Tbl_Lt_LicenseStatusCodeList");

                entity.HasIndex(e => e.LicenceStatusCode)
                    .HasName("IX_Tbl_Lt_LicenseStatusCodeList")
                    .IsUnique();

                entity.Property(e => e.LicenceStatusCodeId)
                    .HasColumnName("LicenceStatusCodeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LicenceStatusCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LicenceStatusCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtMaritalStatusCodeList>(entity =>
            {
                entity.HasKey(e => e.MaritalStatusId);

                entity.ToTable("Tbl_Lt_MaritalStatusCodeList");

                entity.HasIndex(e => e.MaritalStatusCode)
                    .HasName("IX_Tbl_Lt_MaritalStatusCodeList")
                    .IsUnique();

                entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");

                entity.Property(e => e.MaritalStatusCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatusCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtMembershipStatusCodeList>(entity =>
            {
                entity.HasKey(e => e.MembershipStatusCodeId);

                entity.ToTable("Tbl_Lt_MembershipStatusCodeList");

                entity.HasIndex(e => e.MembershipStatusCode)
                    .HasName("IX_Tbl_Lt_MembershipStatusCodeList")
                    .IsUnique();

                entity.Property(e => e.MembershipStatusCodeId).HasColumnName("MembershipStatusCodeID");

                entity.Property(e => e.MembershipStatusCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MembershipStatusCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtNaicsCode>(entity =>
            {
                entity.HasKey(e => e.NiacsCodeId);

                entity.ToTable("Tbl_Lt_NaicsCode");

                entity.Property(e => e.NiacsCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NiacsCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtNationality>(entity =>
            {
                entity.HasKey(e => e.NationalityId);

                entity.ToTable("Tbl_lt_Nationality");

                entity.Property(e => e.NationalityId).HasColumnName("NationalityID");

                entity.Property(e => e.NationalityCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.NationalityDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtNatureOfInterestCodeList>(entity =>
            {
                entity.HasKey(e => e.NatureOfInterestCodeId);

                entity.ToTable("Tbl_Lt_NatureOfInterestCodeList");

                entity.HasIndex(e => e.NatureOfInterestCode)
                    .HasName("IX_Tbl_Lt_NatureOfInterestCodeList")
                    .IsUnique();

                entity.Property(e => e.NatureOfInterestCodeId)
                    .HasColumnName("NatureOfInterestCodeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.NatureOfInterestCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NatureOfInterestCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtOrganizationDetail>(entity =>
            {
                entity.HasKey(e => e.OrganizationDetailId);

                entity.ToTable("Tbl_Lt_OrganizationDetail");

                entity.Property(e => e.OrganizationDetailId).HasColumnName("OrganizationDetailID");

                entity.Property(e => e.OrganizationDetailTypeCodeId).HasColumnName("OrganizationDetailTypeCodeID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.HasOne(d => d.OrganizationDetailTypeCode)
                    .WithMany(p => p.TblLtOrganizationDetail)
                    .HasForeignKey(d => d.OrganizationDetailTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Lt_OrganizationDetail_Tbl_Lt_OrganizationDetailTypeCodeList");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblLtOrganizationDetail)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Lt_OrganizationDetail_Tbl_Organization");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblLtOrganizationDetail)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Lt_OrganizationDetail_Tbl_Party");
            });

            modelBuilder.Entity<TblLtOrganizationDetailTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.OrganizationDetailTypeCodeId);

                entity.ToTable("Tbl_Lt_OrganizationDetailTypeCodeList");

                entity.HasIndex(e => e.OrganizationDetailTypeCode)
                    .HasName("IX_Tbl_Lt_OrganizationDetailTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.OrganizationDetailTypeCodeId).HasColumnName("OrganizationDetailTypeCodeID");

                entity.Property(e => e.OrganizationDetailTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationDetailTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtOrganizationNameUsageCodeList>(entity =>
            {
                entity.HasKey(e => e.OrganizationNameUsageCodeId);

                entity.ToTable("Tbl_Lt_OrganizationNameUsageCodeList");

                entity.Property(e => e.OrganizationNameUsageCodeId).HasColumnName("OrganizationNameUsageCodeID");

                entity.Property(e => e.OrganizationNameUsageCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationNameUsageCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtOrganizationStatusCodeList>(entity =>
            {
                entity.HasKey(e => e.OrganizationStatusCodeId);

                entity.ToTable("Tbl_Lt_OrganizationStatusCodeList");

                entity.HasIndex(e => e.OrganizationStatusCode)
                    .HasName("IX_Tbl_Lt_OrganizationStatusCodeList")
                    .IsUnique();

                entity.Property(e => e.OrganizationStatusCodeId).HasColumnName("OrganizationStatusCodeID");

                entity.Property(e => e.OrganizationStatusCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationStatusCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtOrganizationTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.OrganizationTypeCodeId);

                entity.ToTable("Tbl_Lt_OrganizationTypeCodeList");

                entity.HasIndex(e => e.OrganizationTypeCode)
                    .HasName("IX_Tbl_Lt_OrganizationTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.OrganizationTypeCodeId).HasColumnName("OrganizationTypeCodeID");

                entity.Property(e => e.OrganizationTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtOrginazationUnitKindTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.OrganizationUnitKindTypeId);

                entity.ToTable("Tbl_Lt_OrginazationUnitKindTypeCodeList");

                entity.Property(e => e.OrganizationUnitKindTypeCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationUnitKindTypeDesc)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtOwnershipCodeList>(entity =>
            {
                entity.HasKey(e => e.OwnershipCodeId);

                entity.ToTable("Tbl_Lt_OwnershipCodeList");

                entity.Property(e => e.OwnershipCodeId).HasColumnName("OwnershipCodeID");
            });

            modelBuilder.Entity<TblLtOwnershipTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.OwnershipTypeCodeId);

                entity.ToTable("Tbl_Lt_OwnershipTypeCodeList");

                entity.HasIndex(e => e.OwnershipTypeCode)
                    .HasName("IX_Tbl_Lt_OwnershipTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.OwnershipTypeCodeId).HasColumnName("OwnershipTypeCodeID");

                entity.Property(e => e.OwnershipTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OwnershipTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPartyDetailTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PartyDetailTypeCodeId);

                entity.ToTable("Tbl_Lt_PartyDetailTypeCodeList");

                entity.HasIndex(e => e.PartyDetailTypeCode)
                    .HasName("IX_Tbl_Lt_PartyDetailTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PartyDetailTypeCodeId).HasColumnName("PartyDetailTypeCodeID");

                entity.Property(e => e.PartyDetailTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartyDetailTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPartyRoleInProductTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PartyRoleInProductTypeCodeId);

                entity.ToTable("Tbl_Lt_PartyRoleInProductTypeCodeList");

                entity.HasIndex(e => e.PartyRoleInProductTypeCode)
                    .HasName("IX_Tbl_Lt_PartyRoleInProductTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PartyRoleInProductTypeCodeId).HasColumnName("PartyRoleInProductTypeCodeID");

                entity.Property(e => e.PartyRoleInProductTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleInProductTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPartyRoleInRelationShipTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PartyRoleInRelationShipTypeCodeId)
                    .HasName("PK_Tbl_Lt_PartyRoleInRElationShipTypeCodeList");

                entity.ToTable("Tbl_Lt_PartyRoleInRelationShipTypeCodeList");

                entity.HasIndex(e => e.PartyRoleInRelationShipTypeCode)
                    .HasName("IX_Tbl_Lt_PartyRoleInRElationShipTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PartyRoleInRelationShipTypeCodeId).HasColumnName("PartyRoleInRElationShipTypeCodeID");

                entity.Property(e => e.PartyRoleInRelationShipTypeCode)
                    .IsRequired()
                    .HasColumnName("PartyRoleInRElationShipTypeCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleInRelationShipTypeCodeDesc)
                    .IsRequired()
                    .HasColumnName("PartyRoleInRElationShipTypeCodeDesc")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPartyRoleOnPhysicalObjectTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PartyRoleOnPhysicalObjectTypeCodeId);

                entity.ToTable("Tbl_Lt_PartyRoleOnPhysicalObjectTypeCodeList");

                entity.HasIndex(e => e.PartyRoleOnPhysicalObjectTypeCode)
                    .HasName("IX_Tbl_Lt_PartyRoleOnPhysicalObjectTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PartyRoleOnPhysicalObjectTypeCodeId).HasColumnName("PartyRoleOnPhysicalObjectTypeCodeID");

                entity.Property(e => e.PartyRoleOnPhysicalObjectTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleOnPhysicalObjectTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPartyRoleRegistrationCodeList>(entity =>
            {
                entity.HasKey(e => e.PartyRoleRegistrationCodeId);

                entity.ToTable("Tbl_Lt_PartyRoleRegistrationCodeList");

                entity.Property(e => e.PartyRoleRegistrationCodeId).HasColumnName("PartyRoleRegistrationCodeID");

                entity.Property(e => e.PartyRoleRegistrationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleRegistrationCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPartyRoleinAgreementTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PartyRoleinAgreementTypeCodeId);

                entity.ToTable("Tbl_Lt_PartyRoleinAgreementTypeCodeList");

                entity.HasIndex(e => e.PartyRoleinAgreementTypeCode)
                    .HasName("IX_Tbl_Lt_PartyRoleinAgreementTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PartyRoleinAgreementTypeCodeId).HasColumnName("PartyRoleinAgreementTypeCodeID");

                entity.Property(e => e.PartyRoleinAgreementTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleinAgreementTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPartyRoleinMarketingTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PartyRoleinMarketingTypeCodeId);

                entity.ToTable("Tbl_Lt_PartyRoleinMarketingTypeCodeList");

                entity.HasIndex(e => e.PartyRoleinMarketingTypeCode)
                    .HasName("IX_Tbl_Lt_PartyRoleinMarketingTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PartyRoleinMarketingTypeCodeId).HasColumnName("PartyRoleinMarketingTypeCodeID");

                entity.Property(e => e.PartyRoleinMarketingTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleinMarketingTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPartyTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PartyTypeCodeId);

                entity.ToTable("Tbl_Lt_PartyTypeCodeList");

                entity.Property(e => e.PartyTypeCodeId).HasColumnName("PartyTypeCodeID");

                entity.Property(e => e.PartyTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PartyTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPatientTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PatientTypeCodeId);

                entity.ToTable("Tbl_Lt_PatientTypeCodeList");

                entity.HasIndex(e => e.PatientTypeCode)
                    .HasName("IX_Tbl_Lt_PatientTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PatientTypeCodeId).HasColumnName("PatientTypeCodeID");

                entity.Property(e => e.PatientTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPersonDetailTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PersonDetailCodeId);

                entity.ToTable("Tbl_Lt_PersonDetailTypeCodeList");

                entity.HasIndex(e => e.PersonDetailCode)
                    .HasName("IX_Tbl_Lt_PersonDetailTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PersonDetailCodeId).HasColumnName("PersonDetailCodeID");

                entity.Property(e => e.PersonDetailCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PersonDetailCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPersonNameUsageCodeList>(entity =>
            {
                entity.HasKey(e => e.PersonNameUsageCodeId);

                entity.ToTable("TBl_Lt_PersonNameUsageCodeList");

                entity.HasIndex(e => e.PersonNameUsageCode)
                    .HasName("IX_TBl_Lt_PersonNameUsageCodeList")
                    .IsUnique();

                entity.Property(e => e.PersonNameUsageCodeId).HasColumnName("PersonNameUsageCodeID");

                entity.Property(e => e.PersonNameUsageCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PersonNameUsageCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPersonRegistrationTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PersonRegistrationTypeCodeId);

                entity.ToTable("Tbl_Lt_PersonRegistrationTypeCodeList");

                entity.HasIndex(e => e.PersonRegistrationTypeCode)
                    .HasName("IX_Tbl_Lt_PersonRegistrationTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PersonRegistrationTypeCodeId).HasColumnName("PersonRegistrationTypeCodeID");

                entity.Property(e => e.PersonRegistrationTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PersonRegistrationTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPhysicalObjectUserTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PhysicalObjectUserTypeCodeId);

                entity.ToTable("Tbl_Lt_PhysicalObjectUserTypeCodeList");

                entity.HasIndex(e => e.PhysicalObjectUserTypeCode)
                    .HasName("IX_Tbl_Lt_PhysicalObjectUserTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PhysicalObjectUserTypeCodeId).HasColumnName("PhysicalObjectUserTypeCodeID");

                entity.Property(e => e.PhysicalObjectUserTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalObjectUserTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPilotLogTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PilotLogCodeId);

                entity.ToTable("Tbl_Lt_PilotLogTypeCodeList");

                entity.HasIndex(e => e.PilotLogCode)
                    .HasName("IX_Tbl_Lt_PilotLogTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PilotLogCodeId).HasColumnName("PilotLogCodeID");

                entity.Property(e => e.PilotLogCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PilotLogCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtPrefixTitleCodeList>(entity =>
            {
                entity.HasKey(e => e.PrefixTitleCodeId);

                entity.ToTable("Tbl_Lt_PrefixTitleCodeList");

                entity.HasIndex(e => e.PrefixTitleCode)
                    .HasName("IX_Tbl_Lt_PrefixTitleCodeList")
                    .IsUnique();

                entity.Property(e => e.PrefixTitleCodeId).HasColumnName("PrefixTitleCodeID");

                entity.Property(e => e.PrefixTitleCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrefixTitleCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtProducerRegistrationAuthorityCodeList>(entity =>
            {
                entity.HasKey(e => e.ProdRegAuthCodeId);

                entity.ToTable("Tbl_Lt_ProducerRegistrationAuthorityCodeList");

                entity.HasIndex(e => e.ProdRegAuthCode)
                    .HasName("IX_Tbl_Lt_ProducerRegistrationAuthorityCodeList")
                    .IsUnique();

                entity.Property(e => e.ProdRegAuthCodeId).HasColumnName("ProdRegAuthCodeID");

                entity.Property(e => e.ProdRegAuthCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProdRegAuthCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtProducerRelationShipCodeList>(entity =>
            {
                entity.HasKey(e => e.ProducerRelationShipCodeId);

                entity.ToTable("Tbl_Lt_ProducerRelationShipCodeList");

                entity.HasIndex(e => e.ProducerRelationShipCode)
                    .HasName("IX_Tbl_Lt_ProducerRelationShipCodeList")
                    .IsUnique();

                entity.Property(e => e.ProducerRelationShipCodeId).HasColumnName("ProducerRelationShipCodeID");

                entity.Property(e => e.ProducerRelationShipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProducerRelationShipCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtProducerRelationshipTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.ProducerRelationshipTypeCodeId);

                entity.ToTable("Tbl_Lt_ProducerRelationshipTypeCodeList");

                entity.HasIndex(e => e.ProducerRelationshipTypeCode)
                    .HasName("IX_Tbl_Lt_ProducerRelationshipTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.ProducerRelationshipTypeCodeId)
                    .HasColumnName("ProducerRelationshipTypeCodeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProducerRelationshipTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProducerRelationshipTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtProficiencyLevelCodeList>(entity =>
            {
                entity.HasKey(e => e.ProficiencyLevelCodeId);

                entity.ToTable("Tbl_lt_ProficiencyLevelCodeList");

                entity.HasIndex(e => e.ProficiencyLevelCode)
                    .HasName("IX_Tbl_lt_ProficiencyLevelCodeList")
                    .IsUnique();

                entity.Property(e => e.ProficiencyLevelCodeId)
                    .HasColumnName("ProficiencyLevelCodeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProficiencyLevelCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProficiencyLevelCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtReferalCodeList>(entity =>
            {
                entity.HasKey(e => e.ReferalId);

                entity.ToTable("Tbl_lt_ReferalCodeList");

                entity.Property(e => e.ReferalId).HasColumnName("ReferalID");

                entity.Property(e => e.ReferalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferalDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtRelationShipDescriptionCodeList>(entity =>
            {
                entity.HasKey(e => e.RelationshipDescriptionCodeId);

                entity.ToTable("Tbl_Lt_RelationShipDescriptionCodeList");

                entity.HasIndex(e => e.RelationshipDescriptionCode)
                    .HasName("IX_Tbl_Lt_RelationShipDescriptionCodeList")
                    .IsUnique();

                entity.Property(e => e.RelationshipDescriptionCodeId).HasColumnName("RelationshipDescriptionCodeID");

                entity.Property(e => e.RelationshipDescriptionCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RelationshipDescriptionCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtRepresentativeTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.RepresentativeTypeCodeId);

                entity.ToTable("TBl_Lt_RepresentativeTypeCodeList");

                entity.HasIndex(e => e.RepresentativeTypeCode)
                    .HasName("IX_TBl_Lt_RepresentativeTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.RepresentativeTypeCodeId).HasColumnName("RepresentativeTypeCodeID");

                entity.Property(e => e.RepresentativeTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RepresentativeTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtServiceProviderTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.ServiceProviderTypeCodeId);

                entity.ToTable("Tbl_Lt_ServiceProviderTypeCodeList");

                entity.HasIndex(e => e.ServiceProviderTypeCode)
                    .HasName("IX_Tbl_Lt_ServiceProviderTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.ServiceProviderTypeCodeId).HasColumnName("ServiceProviderTypeCodeID");

                entity.Property(e => e.ServiceProviderTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceProviderTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtSicCode>(entity =>
            {
                entity.HasKey(e => e.SicCodeId);

                entity.ToTable("Tbl_Lt_SicCode");

                entity.Property(e => e.SicCodeId).HasColumnName("sicCodeId");

                entity.Property(e => e.SicCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SicCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtSignatoryDesignationCodeList>(entity =>
            {
                entity.HasKey(e => e.SignatoryDesignationCodeId);

                entity.ToTable("Tbl_Lt_SignatoryDesignationCodeList");

                entity.HasIndex(e => e.SignatoryDesignationCode)
                    .HasName("IX_Tbl_Lt_SignatoryDesignationCodeList")
                    .IsUnique();

                entity.Property(e => e.SignatoryDesignationCodeId).HasColumnName("SignatoryDesignationCodeID");

                entity.Property(e => e.SignatoryDesignationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SignatoryDesignationCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtSubjectAreaCodeList>(entity =>
            {
                entity.HasKey(e => e.SubjectAreaCodeId);

                entity.ToTable("Tbl_Lt_SubjectAreaCodeList");

                entity.HasIndex(e => e.SubjectAreaCode)
                    .HasName("IX_Tbl_Lt_SubjectAreaCodeList")
                    .IsUnique();

                entity.Property(e => e.SubjectAreaCodeId).HasColumnName("SubjectAreaCodeID");

                entity.Property(e => e.SubjectAreaCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectAreaCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtTaxCalculationCodeList>(entity =>
            {
                entity.HasKey(e => e.TaxCalculationCodeId);

                entity.ToTable("Tbl_Lt_TaxCalculationCodeList");

                entity.HasIndex(e => e.TaxCalculationCode)
                    .HasName("IX_Tbl_Lt_TaxCalculationCodeList")
                    .IsUnique();

                entity.Property(e => e.TaxCalculationCodeId).HasColumnName("TaxCalculationCodeID");

                entity.Property(e => e.TaxCalculationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaxCalculationCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtTaxRegistrationTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.TaxRegistrationTypeCodeId);

                entity.ToTable("Tbl_Lt_TaxRegistrationTypeCodeList");

                entity.Property(e => e.TaxRegistrationTypeCodeId).HasColumnName("TaxRegistrationTypeCodeID");

                entity.Property(e => e.TaxRegistrationTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaxRegistrationTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtTaxonomyCodeList>(entity =>
            {
                entity.HasKey(e => e.TaxonomyCodeId);

                entity.ToTable("Tbl_Lt_TaxonomyCodeList");

                entity.HasIndex(e => e.TaxonomyCode)
                    .HasName("IX_Tbl_Lt_TaxonomyCodeList")
                    .IsUnique();

                entity.Property(e => e.TaxonomyCodeId).HasColumnName("TaxonomyCodeID");

                entity.Property(e => e.TaxonomyCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TaxonomyCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtValidityCodeList>(entity =>
            {
                entity.HasKey(e => e.ValidityCodeId);

                entity.ToTable("Tbl_Lt_ValidityCodeList");

                entity.Property(e => e.ValidityCodeId).HasColumnName("ValidityCodeID");

                entity.Property(e => e.ValidityCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityCodedesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtVehicleClassCodeList>(entity =>
            {
                entity.HasKey(e => e.VehicleClassCodeId);

                entity.ToTable("Tbl_Lt_VehicleClassCodeList");

                entity.HasIndex(e => e.VehicleClassCode)
                    .HasName("IX_Tbl_Lt_VehicleClassCodeList")
                    .IsUnique();

                entity.Property(e => e.VehicleClassCodeId).HasColumnName("VehicleClassCodeID");

                entity.Property(e => e.VehicleClassCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleClassCodeDesc)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLtVirtualPartyNameCodeList>(entity =>
            {
                entity.HasKey(e => e.VirtualPartyNameCodeId);

                entity.ToTable("Tbl_Lt_VirtualPartyNameCodeList");

                entity.Property(e => e.VirtualPartyNameCodeId).HasColumnName("VirtualPartyNameCodeID");

                entity.Property(e => e.VirtualPartyNameCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VirtualPartyNameDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMarketingManager>(entity =>
            {
                entity.HasKey(e => e.MarketingManagerId);

                entity.ToTable("Tbl_MarketingManager");

                entity.Property(e => e.MarketingManagerId)
                    .HasColumnName("MarketingManagerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinMarketingId).HasColumnName("PartyRoleinMarketingID");

                entity.HasOne(d => d.PartyRoleinMarketing)
                    .WithMany(p => p.TblMarketingManager)
                    .HasForeignKey(d => d.PartyRoleinMarketingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_MarketingManager_Tbl_PartyRoleinMarketing");
            });

            modelBuilder.Entity<TblMarketingSpecialist>(entity =>
            {
                entity.HasKey(e => e.MarketingSpecialistId);

                entity.ToTable("Tbl_MarketingSpecialist");

                entity.Property(e => e.MarketingSpecialistId).HasColumnName("MarketingSpecialistID");

                entity.Property(e => e.PartyRoleinMarketingId).HasColumnName("PartyRoleinMarketingID");

                entity.HasOne(d => d.PartyRoleinMarketing)
                    .WithMany(p => p.TblMarketingSpecialist)
                    .HasForeignKey(d => d.PartyRoleinMarketingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_MarketingSpecialist_Tbl_PartyRoleinMarketing");
            });

            modelBuilder.Entity<TblMedicalExaminer>(entity =>
            {
                entity.HasKey(e => e.MedicalExaminerId);

                entity.ToTable("Tbl_MedicalExaminer");

                entity.Property(e => e.MedicalExaminerId).HasColumnName("MedicalExaminerID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblMedicalExaminer)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_MedicalExaminer_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblMedicalFacility>(entity =>
            {
                entity.HasKey(e => e.MedicalFacilityId)
                    .HasName("PK_Table_1");

                entity.ToTable("Tbl_MedicalFacility");

                entity.Property(e => e.MedicalFacilityId).HasColumnName("MedicalFacilityID");

                entity.Property(e => e.HealthInstitutionId).HasColumnName("HealthInstitutionID");

                entity.Property(e => e.MedicalFacilityCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MedicalFacilityName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.HealthInstitution)
                    .WithMany(p => p.TblMedicalFacility)
                    .HasForeignKey(d => d.HealthInstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_Tbl_HealthInstitution");
            });

            modelBuilder.Entity<TblMedicalUnit>(entity =>
            {
                entity.HasKey(e => e.MedicalUnitId);

                entity.ToTable("Tbl_MedicalUnit");

                entity.Property(e => e.MedicalUnitId).HasColumnName("MedicalUnitID");

                entity.Property(e => e.MedicalUnitCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MedicalUnitName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationUnitId).HasColumnName("OrganizationUnitID");

                entity.HasOne(d => d.OrganizationUnit)
                    .WithMany(p => p.TblMedicalUnit)
                    .HasForeignKey(d => d.OrganizationUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_MedicalUnit_Tbl_OrganizationUnit");
            });

            modelBuilder.Entity<TblMembershipRegistration>(entity =>
            {
                entity.HasKey(e => e.MembershipRegistrationId);

                entity.ToTable("Tbl_MembershipRegistration");

                entity.Property(e => e.MembershipRegistrationId).HasColumnName("MembershipRegistrationID");

                entity.Property(e => e.MembershipStatusCodeId).HasColumnName("MembershipStatusCodeID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.HasOne(d => d.MembershipStatusCode)
                    .WithMany(p => p.TblMembershipRegistration)
                    .HasForeignKey(d => d.MembershipStatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_MembershipRegistration_Tbl_Lt_MembershipStatusCodeList");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblMembershipRegistration)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_MembershipRegistration_Tbl_Party");
            });

            modelBuilder.Entity<TblMilitaryRegistration>(entity =>
            {
                entity.HasKey(e => e.MilitaryRegistraionId);

                entity.ToTable("Tbl_MilitaryRegistration");

                entity.Property(e => e.MilitaryRegistraionId).HasColumnName("MilitaryRegistraionID");

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.HasOne(d => d.PersonRegistration)
                    .WithMany(p => p.TblMilitaryRegistration)
                    .HasForeignKey(d => d.PersonRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_MilitaryRegistration_Tbl_PersonRegistration");
            });

            modelBuilder.Entity<TblNotificationAuthority>(entity =>
            {
                entity.HasKey(e => e.NotificationAuthorityId);

                entity.ToTable("Tbl_NotificationAuthority");

                entity.Property(e => e.NotificationAuthorityId)
                    .HasColumnName("NotificationAuthorityID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblObligee>(entity =>
            {
                entity.HasKey(e => e.ObligeeId);

                entity.ToTable("Tbl_Obligee");

                entity.Property(e => e.ObligeeId).HasColumnName("ObligeeID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblObligee)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Obligee_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblOccupant>(entity =>
            {
                entity.HasKey(e => e.OccupantId);

                entity.ToTable("Tbl_Occupant");

                entity.Property(e => e.OccupantId).HasColumnName("OccupantID");

                entity.Property(e => e.PhysicalObjectUserId).HasColumnName("PhysicalObjectUserID");

                entity.HasOne(d => d.PhysicalObjectUser)
                    .WithMany(p => p.TblOccupant)
                    .HasForeignKey(d => d.PhysicalObjectUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Occupant_Tbl_PhysicalObjectUser");
            });

            modelBuilder.Entity<TblOperationsDetial>(entity =>
            {
                entity.HasKey(e => e.OperationsDatialiD);

                entity.ToTable("Tbl_OperationsDetial");

                entity.Property(e => e.CustomerCount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FiscalYearEndMonthDay).HasColumnType("date");

                entity.Property(e => e.NNtureOfBussiness)
                    .HasColumnName("nNtureOfBussiness")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SicCodeId).HasColumnName("sicCodeId");

                entity.HasOne(d => d.NafCode)
                    .WithMany(p => p.TblOperationsDetial)
                    .HasForeignKey(d => d.NafCodeId)
                    .HasConstraintName("FK_Tbl_OperationsDetial_TbL_lt_NafCode");

                entity.HasOne(d => d.NiacsCode)
                    .WithMany(p => p.TblOperationsDetial)
                    .HasForeignKey(d => d.NiacsCodeId)
                    .HasConstraintName("FK_Tbl_OperationsDetial_Tbl_Lt_NaicsCode");

                entity.HasOne(d => d.SicCode)
                    .WithMany(p => p.TblOperationsDetial)
                    .HasForeignKey(d => d.SicCodeId)
                    .HasConstraintName("FK_Tbl_OperationsDetial_Tbl_Lt_SicCode");
            });

            modelBuilder.Entity<TblOpponentThirdParty>(entity =>
            {
                entity.HasKey(e => e.OpponentThirdPartyId);

                entity.ToTable("Tbl_OpponentThirdParty");

                entity.Property(e => e.OpponentThirdPartyId).HasColumnName("OpponentThirdPartyID");

                entity.Property(e => e.AgreementNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InsurerName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LiabiityPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblOrganization>(entity =>
            {
                entity.HasKey(e => e.OrganizationId);

                entity.ToTable("Tbl_Organization");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.OrganizationStatusCodeId).HasColumnName("OrganizationStatusCodeID");

                entity.Property(e => e.OrganizationTypeCodeId).HasColumnName("OrganizationTypeCodeID");

                entity.Property(e => e.StatusReason)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrganizationStatusCode)
                    .WithMany(p => p.TblOrganization)
                    .HasForeignKey(d => d.OrganizationStatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Organization_Tbl_Lt_OrganizationStatusCodeList");

                entity.HasOne(d => d.OrganizationTypeCode)
                    .WithMany(p => p.TblOrganization)
                    .HasForeignKey(d => d.OrganizationTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Organization_Tbl_Lt_OrganizationTypeCodeList");
            });

            modelBuilder.Entity<TblOrganizationDetail>(entity =>
            {
                entity.HasKey(e => e.OrganizationDetailId);

                entity.ToTable("Tbl_OrganizationDetail");

                entity.Property(e => e.OrganizationDetailId).HasColumnName("OrganizationDetailID");

                entity.Property(e => e.EmployeeSummeryDetailId).HasColumnName("EmployeeSummeryDetailID");

                entity.Property(e => e.FinancialResultId).HasColumnName("FinancialResultID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.HasOne(d => d.EmployeeSummeryDetail)
                    .WithMany(p => p.TblOrganizationDetail)
                    .HasForeignKey(d => d.EmployeeSummeryDetailId)
                    .HasConstraintName("FK_Tbl_OrganizationDetail_Tbl_EmployeeSummeryDetail");

                entity.HasOne(d => d.FinancialResult)
                    .WithMany(p => p.TblOrganizationDetail)
                    .HasForeignKey(d => d.FinancialResultId)
                    .HasConstraintName("FK_Tbl_OrganizationDetail_Tbl_Lt_FinancialResult");

                entity.HasOne(d => d.OperationsDatial)
                    .WithMany(p => p.TblOrganizationDetail)
                    .HasForeignKey(d => d.OperationsDatialiD)
                    .HasConstraintName("FK_Tbl_OrganizationDetail_Tbl_OperationsDetial");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblOrganizationDetail)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationDetail_Tbl_Organization");

                entity.HasOne(d => d.OrganizationLegalStatus)
                    .WithMany(p => p.TblOrganizationDetail)
                    .HasForeignKey(d => d.OrganizationLegalStatusId)
                    .HasConstraintName("FK_Tbl_OrganizationDetail_Tbl_OrganizationLegalStatus");
            });

            modelBuilder.Entity<TblOrganizationLegalStatus>(entity =>
            {
                entity.HasKey(e => e.OrganizationLegalStatusId);

                entity.ToTable("Tbl_OrganizationLegalStatus");

                entity.Property(e => e.AbreviationName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LegalEntityTypeCode)
                    .WithMany(p => p.TblOrganizationLegalStatus)
                    .HasForeignKey(d => d.LegalEntityTypeCodeId)
                    .HasConstraintName("FK_Tbl_OrganizationLegalStatus_Tbl_Lt_LegalEntityCodeList");
            });

            modelBuilder.Entity<TblOrganizationName>(entity =>
            {
                entity.HasKey(e => e.OrganizationNameId);

                entity.ToTable("Tbl_OrganizationName");

                entity.Property(e => e.OrganizationNameId).HasColumnName("OrganizationNameID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.OrganizationNameUsageCodeId).HasColumnName("OrganizationNameUsageCodeID");

                entity.Property(e => e.PartyNameId).HasColumnName("PartyNameID");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblOrganizationName)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationName_Tbl_Organization");

                entity.HasOne(d => d.PartyName)
                    .WithMany(p => p.TblOrganizationName)
                    .HasForeignKey(d => d.PartyNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationName_Tbl_Lt_OrganizationNameUsageCodeList");
            });

            modelBuilder.Entity<TblOrganizationRelationship>(entity =>
            {
                entity.HasKey(e => e.OrganizationRelationShipId);

                entity.ToTable("Tbl_OrganizationRelationship");

                entity.Property(e => e.OrganizationRelationShipId).HasColumnName("OrganizationRelationShipID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblOrganizationRelationship)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationRelationship_Tbl_Organization");

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblOrganizationRelationship)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationRelationship_Tbl_PartyRoleRelationship");
            });

            modelBuilder.Entity<TblOrganizationUnit>(entity =>
            {
                entity.HasKey(e => e.OrganizationUnitId);

                entity.ToTable("Tbl_OrganizationUnit");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.OrganizationUnitName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblOrganizationUnit)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationUnit_Tbl_Organization");

                entity.HasOne(d => d.OrganizationUnitKindType)
                    .WithMany(p => p.TblOrganizationUnit)
                    .HasForeignKey(d => d.OrganizationUnitKindTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OrganizationUnit_Tbl_Lt_OrginazationUnitKindTypeCodeList");
            });

            modelBuilder.Entity<TblOtherHouseHoldMember>(entity =>
            {
                entity.HasKey(e => e.OtherHouseHoldMemberId);

                entity.ToTable("Tbl_OtherHouseHoldMember");

                entity.Property(e => e.OtherHouseHoldMemberId)
                    .HasColumnName("OtherHouseHoldMemberID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblOtherHouseHoldMember)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_OtherHouseHoldMember_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblOutpatient>(entity =>
            {
                entity.HasKey(e => e.OutPatientId);

                entity.ToTable("Tbl_Outpatient");

                entity.Property(e => e.OutPatientId).HasColumnName("OutPatientID");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TblOutpatient)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Outpatient_Tbl_Patient");
            });

            modelBuilder.Entity<TblOwner>(entity =>
            {
                entity.HasKey(e => e.OwnerId);

                entity.ToTable("Tbl_Owner");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.HasOne(d => d.PartyRolePhysicalObjectNavigation)
                    .WithMany(p => p.TblOwner)
                    .HasForeignKey(d => d.PartyRolePhysicalObject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Owner_Tbl_PartyRolePhysicalObject");
            });

            modelBuilder.Entity<TblParentOrganization>(entity =>
            {
                entity.HasKey(e => e.ParentOrganiozationId);

                entity.ToTable("Tbl_ParentOrganization");

                entity.Property(e => e.ParentOrganiozationId).HasColumnName("ParentOrganiozationID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblParentOrganization)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ParentOrganization_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblParty>(entity =>
            {
                entity.HasKey(e => e.PartyId);

                entity.ToTable("Tbl_Party");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyTypeCodeId).HasColumnName("PartyTypeCodeID");

                entity.HasOne(d => d.PartyTypeCode)
                    .WithMany(p => p.TblParty)
                    .HasForeignKey(d => d.PartyTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Party_Tbl_Lt_PartyTypeCodeList");
            });

            modelBuilder.Entity<TblPartyDetail>(entity =>
            {
                entity.HasKey(e => e.PartyDetailId);

                entity.ToTable("Tbl_Party_Detail");

                entity.Property(e => e.PartyDetailId).HasColumnName("PartyDetailID");

                entity.Property(e => e.ApplicabilityCodeId).HasColumnName("ApplicabilityCodeID");

                entity.Property(e => e.PartyDetailTypeCodeId).HasColumnName("PartyDetailTypeCodeID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.HasOne(d => d.ApplicabilityCode)
                    .WithMany(p => p.TblPartyDetail)
                    .HasForeignKey(d => d.ApplicabilityCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Party_Detail_Tbl_lt_ApplicabilityCodeList");

                entity.HasOne(d => d.PartyDetailTypeCode)
                    .WithMany(p => p.TblPartyDetail)
                    .HasForeignKey(d => d.PartyDetailTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Party_Detail_Tbl_Lt_PartyDetailTypeCodeList");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblPartyDetail)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Party_Detail_Tbl_Party");
            });

            modelBuilder.Entity<TblPartyName>(entity =>
            {
                entity.HasKey(e => e.PartyNameId)
                    .HasName("Tbl_PartyName_pk")
                    .IsClustered(false);

                entity.ToTable("Tbl_PartyName");

                entity.Property(e => e.PartyNameId).HasColumnName("PartyNameID");

                entity.Property(e => e.Defualtindicator)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EffectivePeriodEnd).HasColumnType("datetime");

                entity.Property(e => e.EffectivePeriodStart).HasColumnType("datetime");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TblPartyName)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyName_Tbl_Lt_LanguageCode");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblPartyName)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyName_Tbl_Party");
            });

            modelBuilder.Entity<TblPartyRoleInAgreement>(entity =>
            {
                entity.HasKey(e => e.PartyRoleInAgreementId);

                entity.ToTable("Tbl_PartyRoleInAgreement");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.Property(e => e.AgreementId).HasColumnName("AgreementID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyRoleinAgreementTypeCodeId).HasColumnName("PartyRoleinAgreementTypeCodeID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblPartyRoleInAgreement)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRoleInAgreement_Tbl_Party");

                entity.HasOne(d => d.PartyRoleinAgreementTypeCode)
                    .WithMany(p => p.TblPartyRoleInAgreement)
                    .HasForeignKey(d => d.PartyRoleinAgreementTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRoleInAgreement_Tbl_Lt_PartyRoleinAgreementTypeCodeList");
            });

            modelBuilder.Entity<TblPartyRoleInProduct>(entity =>
            {
                entity.HasKey(e => e.PartyRoleinProductId);

                entity.ToTable("Tbl_PartyRoleInProduct");

                entity.Property(e => e.PartyRoleinProductId).HasColumnName("PartyRoleinProductID");

                entity.Property(e => e.PartyRoleInProductTypeCodeId).HasColumnName("PartyRoleInProductTypeCodeID");

                entity.Property(e => e.ProductSpecificationId).HasColumnName("ProductSpecificationID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblPartyRoleInProduct)
                    .HasForeignKey(d => d.PartyId)
                    .HasConstraintName("FK_Tbl_PartyRoleInProduct_Tbl_Party");

                entity.HasOne(d => d.PartyRoleInProductTypeCode)
                    .WithMany(p => p.TblPartyRoleInProduct)
                    .HasForeignKey(d => d.PartyRoleInProductTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRoleInProduct_Tbl_Lt_PartyRoleInProductTypeCodeList");
            });

            modelBuilder.Entity<TblPartyRolePhysicalObject>(entity =>
            {
                entity.HasKey(e => e.PartyRolePhysicalObject);

                entity.ToTable("Tbl_PartyRolePhysicalObject");

                entity.Property(e => e.PartyRoleOnPhysicalObjectTypeCodeId).HasColumnName("PartyRoleOnPhysicalObjectTypeCodeID");

                entity.Property(e => e.PhysicalObjectId).HasColumnName("PhysicalObjectID");

                entity.HasOne(d => d.PartyRoleOnPhysicalObjectTypeCode)
                    .WithMany(p => p.TblPartyRolePhysicalObject)
                    .HasForeignKey(d => d.PartyRoleOnPhysicalObjectTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRolePhysicalObject_Tbl_Lt_PartyRoleOnPhysicalObjectTypeCodeList");
            });

            modelBuilder.Entity<TblPartyRoleRegistration>(entity =>
            {
                entity.HasKey(e => e.PartyRoleRegistrationId);

                entity.ToTable("Tbl_PartyRoleRegistration");

                entity.Property(e => e.PartyRoleRegistrationId).HasColumnName("PartyRoleRegistrationID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyRoleRegistrationCodeId).HasColumnName("PartyRoleRegistrationCodeID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblPartyRoleRegistration)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRoleRegistration_Tbl_Party");

                entity.HasOne(d => d.PartyRoleRegistrationCode)
                    .WithMany(p => p.TblPartyRoleRegistration)
                    .HasForeignKey(d => d.PartyRoleRegistrationCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRoleRegistration_Tbl_Lt_PartyRoleRegistrationCodeList");
            });

            modelBuilder.Entity<TblPartyRoleRelationship>(entity =>
            {
                entity.HasKey(e => e.PartyRoleRelationshipId);

                entity.ToTable("Tbl_PartyRoleRelationship");

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.Property(e => e.PartyRoleInRelationShipTypeCodeId).HasColumnName("PartyRoleInRelationShipTypeCodeID");

                entity.HasOne(d => d.PartyRoleInRelationShipTypeCode)
                    .WithMany(p => p.TblPartyRoleRelationship)
                    .HasForeignKey(d => d.PartyRoleInRelationShipTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRoleRelationship_Tbl_Lt_PartyRoleInRelationShipTypeCodeList");
            });

            modelBuilder.Entity<TblPartyRoleinMarketing>(entity =>
            {
                entity.HasKey(e => e.PartyRoleinMarketingId);

                entity.ToTable("Tbl_PartyRoleinMarketing");

                entity.Property(e => e.PartyRoleinMarketingId)
                    .HasColumnName("PartyRoleinMarketingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MarketingId).HasColumnName("MarketingID");

                entity.Property(e => e.PartyRoleinMarketingTypeCodeId).HasColumnName("PartyRoleinMarketingTypeCodeID");

                entity.HasOne(d => d.PartyRoleinMarketingTypeCode)
                    .WithMany(p => p.TblPartyRoleinMarketing)
                    .HasForeignKey(d => d.PartyRoleinMarketingTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRoleinMarketing_Tbl_Lt_PartyRoleinMarketingTypeCodeList");
            });

            modelBuilder.Entity<TblPartyRoleinRelationShip>(entity =>
            {
                entity.HasKey(e => e.PartyRoleinRerlationShipId);

                entity.ToTable("Tbl_PartyRoleinRelationShip");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyRoleInRelationShipTypeCodeId).HasColumnName("PartyRoleInRElationShipTypeCodeID");

                entity.Property(e => e.RelationShipId).HasColumnName("RelationShipID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblPartyRoleinRelationShip)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRoleinRelationShip_Tbl_Party");

                entity.HasOne(d => d.PartyRoleInRelationShipTypeCode)
                    .WithMany(p => p.TblPartyRoleinRelationShip)
                    .HasForeignKey(d => d.PartyRoleInRelationShipTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PartyRoleinRelationShip_Tbl_Lt_PartyRoleInRElationShipTypeCodeList");
            });

            modelBuilder.Entity<TblPassport>(entity =>
            {
                entity.HasKey(e => e.PassportId);

                entity.ToTable("Tbl_Passport");

                entity.Property(e => e.PassportId).HasColumnName("PassportID");

                entity.Property(e => e.ValidityCodeId).HasColumnName("ValidityCodeID");

                entity.HasOne(d => d.ValidityCode)
                    .WithMany(p => p.TblPassport)
                    .HasForeignKey(d => d.ValidityCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Passport_Tbl_Lt_ValidityCodeList");
            });

            modelBuilder.Entity<TblPatient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.ToTable("Tbl_Patient");

                entity.Property(e => e.PatientId)
                    .HasColumnName("PatientID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LastDischargeFacilityTypeCodeId).HasColumnName("LastDischargeFacilityTypeCodeID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");

                entity.Property(e => e.PatientTypeCodeId).HasColumnName("PatientTypeCodeID");

                entity.HasOne(d => d.LastDischargeFacilityTypeCode)
                    .WithMany(p => p.TblPatient)
                    .HasForeignKey(d => d.LastDischargeFacilityTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Patient_Tbl_Lt_LastDischargeFacilityTypeCodeList");

                entity.HasOne(d => d.PatientTypeCode)
                    .WithMany(p => p.TblPatient)
                    .HasForeignKey(d => d.PatientTypeCodeId)
                    .HasConstraintName("FK_Tbl_Patient_Tbl_Lt_PatientTypeCodeList");
            });

            modelBuilder.Entity<TblPayingServicer>(entity =>
            {
                entity.HasKey(e => e.PayingServicerId);

                entity.ToTable("Tbl_PayingServicer");

                entity.Property(e => e.PayingServicerId).HasColumnName("PayingServicerID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblPayingServicer)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PayingServicer_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblPerson>(entity =>
            {
                entity.HasKey(e => e.PersonId);

                entity.ToTable("Tbl_Person");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.BloodTypeCodeId).HasColumnName("BloodTypeCodeID");

                entity.Property(e => e.CrossMonthlyIncomeId).HasColumnName("CrossMonthlyIncomeID");

                entity.Property(e => e.DeathIndicator).HasDefaultValueSql("((0))");

                entity.Property(e => e.EthnicityId).HasColumnName("EthnicityID");

                entity.Property(e => e.GenderCodeId).HasColumnName("GenderCodeID");

                entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");

                entity.Property(e => e.MissingIndicator).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.BloodTypeCode)
                    .WithMany(p => p.TblPerson)
                    .HasForeignKey(d => d.BloodTypeCodeId)
                    .HasConstraintName("FK_Tbl_Person_Tbl_Lt_BloodTypeCodeList");

                entity.HasOne(d => d.CrossMonthlyIncome)
                    .WithMany(p => p.TblPerson)
                    .HasForeignKey(d => d.CrossMonthlyIncomeId)
                    .HasConstraintName("FK_Tbl_Person_Tbl_Lt_CrossMonthlyIncomeCodeList");

                entity.HasOne(d => d.Ethnicity)
                    .WithMany(p => p.TblPerson)
                    .HasForeignKey(d => d.EthnicityId)
                    .HasConstraintName("FK_Tbl_Person_Tbl_Lt_EthnicityCodeList");

                entity.HasOne(d => d.GenderCode)
                    .WithMany(p => p.TblPerson)
                    .HasForeignKey(d => d.GenderCodeId)
                    .HasConstraintName("FK_Tbl_Person_Tbl_Lt_GenderCodeList");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.TblPerson)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("FK_Tbl_Person_Tbl_Lt_MaritalStatusCodeList");
            });

            modelBuilder.Entity<TblPersonDetail>(entity =>
            {
                entity.HasKey(e => e.PersonDetaiId)
                    .HasName("PK_Tbl_Lt_PersonDetail");

                entity.ToTable("Tbl_PersonDetail");

                entity.Property(e => e.PersonDetaiId).HasColumnName("PersonDetaiID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.Property(e => e.PersonDetailCodeId).HasColumnName("PersonDetailCodeID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblPersonDetail)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Lt_PersonDetail_Tbl_Party");

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblPersonDetail)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .HasConstraintName("FK_Tbl_PersonDetail_Tbl_PartyRoleinRelationShip");

                entity.HasOne(d => d.PersonDetailCode)
                    .WithMany(p => p.TblPersonDetail)
                    .HasForeignKey(d => d.PersonDetailCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Lt_PersonDetail_Tbl_Lt_PersonDetailTypeCodeList");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblPersonDetail)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Lt_PersonDetail_Tbl_Person");
            });

            modelBuilder.Entity<TblPersonName>(entity =>
            {
                entity.HasKey(e => e.PersonaNameId);

                entity.ToTable("Tbl_PersonName");

                entity.Property(e => e.PersonaNameId).HasColumnName("PersonaNameID");

                entity.Property(e => e.GivenName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Initials)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PersonNameUsageCodeId).HasColumnName("PersonNameUsageCodeID");

                entity.Property(e => e.PreferredName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrefixTitleCodeId).HasColumnName("PrefixTitleCodeID");

                entity.Property(e => e.Suffix)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblPersonName)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PersonName_Tbl_Person");

                entity.HasOne(d => d.PersonNameUsageCode)
                    .WithMany(p => p.TblPersonName)
                    .HasForeignKey(d => d.PersonNameUsageCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PersonName_TBl_Lt_PersonNameUsageCodeList");

                entity.HasOne(d => d.PrefixTitleCode)
                    .WithMany(p => p.TblPersonName)
                    .HasForeignKey(d => d.PrefixTitleCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PersonName_Tbl_Lt_PrefixTitleCodeList");
            });

            modelBuilder.Entity<TblPersonReferalLink>(entity =>
            {
                entity.HasKey(e => e.PersonReferalLinkId);

                entity.ToTable("Tbl_PersonReferalLink");

                entity.Property(e => e.PersonReferalLinkId).HasColumnName("PersonReferalLinkID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.ReferalId).HasColumnName("ReferalID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblPersonReferalLink)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PersonReferalLink_Tbl_Person");

                entity.HasOne(d => d.Referal)
                    .WithMany(p => p.TblPersonReferalLink)
                    .HasForeignKey(d => d.ReferalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PersonReferalLink_Tbl_lt_ReferalCodeList");
            });

            modelBuilder.Entity<TblPersonRegistration>(entity =>
            {
                entity.HasKey(e => e.PersonRegistrationId);

                entity.ToTable("Tbl_PersonRegistration");

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PersonRegistrationTypeCodeId).HasColumnName("PersonRegistrationTypeCodeID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.TblPersonRegistration)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PersonRegistration_Tbl_Person");

                entity.HasOne(d => d.PersonRegistrationTypeCode)
                    .WithMany(p => p.TblPersonRegistration)
                    .HasForeignKey(d => d.PersonRegistrationTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PersonRegistration_Tbl_Lt_PersonRegistrationTypeCodeList");
            });

            modelBuilder.Entity<TblPersonalActivityLicence>(entity =>
            {
                entity.HasKey(e => e.PersonalActivityLicenceId);

                entity.ToTable("Tbl_PersonalActivityLicence");

                entity.Property(e => e.PersonalActivityLicenceId).HasColumnName("PersonalActivityLicenceID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.HasOne(d => d.PersonRegistration)
                    .WithMany(p => p.TblPersonalActivityLicence)
                    .HasForeignKey(d => d.PersonRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PersonalActivityLicence_Tbl_PersonRegistration1");
            });

            modelBuilder.Entity<TblPhysicalObjectUser>(entity =>
            {
                entity.HasKey(e => e.PhysicalObjectUserId);

                entity.ToTable("Tbl_PhysicalObjectUser");

                entity.Property(e => e.PhysicalObjectUserId).HasColumnName("PhysicalObjectUserID");

                entity.Property(e => e.PhysicalObjectUserTypeCodeId).HasColumnName("PhysicalObjectUserTypeCodeID");

                entity.HasOne(d => d.PartyRolePhysicalObjectNavigation)
                    .WithMany(p => p.TblPhysicalObjectUser)
                    .HasForeignKey(d => d.PartyRolePhysicalObject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PhysicalObjectUser_Tbl_PartyRolePhysicalObject");

                entity.HasOne(d => d.PhysicalObjectUserTypeCode)
                    .WithMany(p => p.TblPhysicalObjectUser)
                    .HasForeignKey(d => d.PhysicalObjectUserTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PhysicalObjectUser_Tbl_Lt_PhysicalObjectUserTypeCodeList");
            });

            modelBuilder.Entity<TblPilot>(entity =>
            {
                entity.HasKey(e => e.PilotId);

                entity.ToTable("Tbl_Pilot");

                entity.Property(e => e.PilotId).HasColumnName("PilotID");

                entity.Property(e => e.ClaimCount)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength()
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblPilot)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Pilot_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblPilotLog>(entity =>
            {
                entity.HasKey(e => e.PilotLogId);

                entity.ToTable("Tbl_PilotLog");

                entity.Property(e => e.PilotLogId).HasColumnName("PilotLogID");

                entity.Property(e => e.PilotId).HasColumnName("PilotID");

                entity.Property(e => e.PilotLogCodeId).HasColumnName("PilotLogCodeID");

                entity.HasOne(d => d.Pilot)
                    .WithMany(p => p.TblPilotLog)
                    .HasForeignKey(d => d.PilotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PilotLog_Tbl_Pilot");

                entity.HasOne(d => d.PilotLogCode)
                    .WithMany(p => p.TblPilotLog)
                    .HasForeignKey(d => d.PilotLogCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PilotLog_Tbl_Lt_PilotLogTypeCodeList");
            });

            modelBuilder.Entity<TblPlaintiff>(entity =>
            {
                entity.HasKey(e => e.PlaintiffId);

                entity.ToTable("Tbl_Plaintiff");

                entity.Property(e => e.PlaintiffId).HasColumnName("PlaintiffID");

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblPostalAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tbl_PostalAddress");

                entity.Property(e => e.AddressLines)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.BoxNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingName)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CarrierRoute)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FloorNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostDirectionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalAddressId).HasColumnName("PostalAddressID");

                entity.Property(e => e.PostalBarCode)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PreDirectionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetTypeCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPremiumCollector>(entity =>
            {
                entity.HasKey(e => e.PremiumCollectorId);

                entity.ToTable("Tbl_PremiumCollector");

                entity.Property(e => e.PremiumCollectorId).HasColumnName("PremiumCollectorID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblPremiumCollector)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PremiumCollector_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblPremiumPayer>(entity =>
            {
                entity.HasKey(e => e.PremiumPayerId);

                entity.ToTable("Tbl_PremiumPayer");

                entity.Property(e => e.PremiumPayerId).HasColumnName("PremiumPayerID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblPremiumPayer)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PremiumPayer_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblPrincipal>(entity =>
            {
                entity.HasKey(e => e.PrincipalId);

                entity.ToTable("Tbl_Principal");

                entity.Property(e => e.PrincipalId).HasColumnName("PrincipalID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.Property(e => e.PartyRoleinAgreementTypeCodeId).HasColumnName("PartyRoleinAgreementTypeCodeID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblPrincipal)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Principal_Tbl_PartyRoleInAgreement");

                entity.HasOne(d => d.PartyRoleinAgreementTypeCode)
                    .WithMany(p => p.TblPrincipal)
                    .HasForeignKey(d => d.PartyRoleinAgreementTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Principal_Tbl_Lt_PartyRoleinAgreementTypeCodeList");
            });

            modelBuilder.Entity<TblProducerRegistration>(entity =>
            {
                entity.HasKey(e => e.ProducerRegistrationId);

                entity.ToTable("Tbl_ProducerRegistration");

                entity.Property(e => e.ProducerRegistrationId).HasColumnName("ProducerRegistrationID");

                entity.Property(e => e.PartyRoleRegistrationId).HasColumnName("PartyRoleRegistrationID");

                entity.Property(e => e.ProdRegAuthCodeId).HasColumnName("ProdRegAuthCodeID");

                entity.HasOne(d => d.PartyRoleRegistration)
                    .WithMany(p => p.TblProducerRegistration)
                    .HasForeignKey(d => d.PartyRoleRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProducerRegistration_Tbl_PartyRoleRegistration");

                entity.HasOne(d => d.ProdRegAuthCode)
                    .WithMany(p => p.TblProducerRegistration)
                    .HasForeignKey(d => d.ProdRegAuthCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProducerRegistration_Tbl_Lt_ProducerRegistrationAuthorityCodeList");
            });

            modelBuilder.Entity<TblProducerRelationShip>(entity =>
            {
                entity.HasKey(e => e.ProducerReltionShipId);

                entity.ToTable("Tbl_ProducerRelationShip");

                entity.Property(e => e.ProducerReltionShipId).HasColumnName("ProducerReltionShipID");

                entity.Property(e => e.DistributionMethodType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.Property(e => e.ProducerRelationShipCodeId).HasColumnName("ProducerRelationShipCodeID");

                entity.Property(e => e.ProducerRelationshipTypeCodeId).HasColumnName("ProducerRelationshipTypeCodeID");

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblProducerRelationShip)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProducerRelationShip_Tbl_PartyRoleRelationship");

                entity.HasOne(d => d.ProducerRelationShipCode)
                    .WithMany(p => p.TblProducerRelationShip)
                    .HasForeignKey(d => d.ProducerRelationShipCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProducerRelationShip_Tbl_Lt_ProducerRelationShipCodeList");

                entity.HasOne(d => d.ProducerRelationshipTypeCode)
                    .WithMany(p => p.TblProducerRelationShip)
                    .HasForeignKey(d => d.ProducerRelationshipTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProducerRelationShip_Tbl_Lt_ProducerRelationshipTypeCodeList");
            });

            modelBuilder.Entity<TblProductAdministrator>(entity =>
            {
                entity.HasKey(e => e.ProductAdministratorId);

                entity.ToTable("Tbl_ProductAdministrator");

                entity.Property(e => e.ProductAdministratorId).HasColumnName("ProductAdministratorID");

                entity.Property(e => e.PartyRoleinProductId).HasColumnName("PartyRoleinProductID");

                entity.HasOne(d => d.PartyRoleinProduct)
                    .WithMany(p => p.TblProductAdministrator)
                    .HasForeignKey(d => d.PartyRoleinProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductAdministrator_Tbl_PartyRoleInProduct");
            });

            modelBuilder.Entity<TblProductDistributor>(entity =>
            {
                entity.HasKey(e => e.ProductManagerId);

                entity.ToTable("Tbl_ProductDistributor");

                entity.Property(e => e.ProductManagerId)
                    .HasColumnName("ProductManagerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinProductId).HasColumnName("PartyRoleinProductID");

                entity.HasOne(d => d.PartyRoleinProduct)
                    .WithMany(p => p.TblProductDistributor)
                    .HasForeignKey(d => d.PartyRoleinProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductDistributor_Tbl_PartyRoleInProduct");
            });

            modelBuilder.Entity<TblProductManager>(entity =>
            {
                entity.HasKey(e => e.ProductManager);

                entity.ToTable("Tbl_ProductManager");

                entity.Property(e => e.PartyRoleinProductId).HasColumnName("PartyRoleinProductID");

                entity.HasOne(d => d.PartyRoleinProduct)
                    .WithMany(p => p.TblProductManager)
                    .HasForeignKey(d => d.PartyRoleinProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProductManager_Tbl_PartyRoleInProduct");
            });

            modelBuilder.Entity<TblProjectManager>(entity =>
            {
                entity.HasKey(e => e.ProjectManagerId);

                entity.ToTable("Tbl_ProjectManager");

                entity.Property(e => e.ProjectManagerId).HasColumnName("ProjectManagerID");

                entity.Property(e => e.PartyRoleinMarketingId).HasColumnName("PartyRoleinMarketingID");

                entity.HasOne(d => d.PartyRoleinMarketing)
                    .WithMany(p => p.TblProjectManager)
                    .HasForeignKey(d => d.PartyRoleinMarketingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ProjectManager_Tbl_PartyRoleinMarketing");
            });

            modelBuilder.Entity<TblPropiertorTypeCodeList>(entity =>
            {
                entity.HasKey(e => e.PropierTypeCodeId);

                entity.ToTable("Tbl_PropiertorTypeCodeList");

                entity.HasIndex(e => e.PropierTypeCode)
                    .HasName("IX_Tbl_PropiertorTypeCodeList")
                    .IsUnique();

                entity.Property(e => e.PropierTypeCodeId).HasColumnName("PropierTypeCodeID");

                entity.Property(e => e.PropierTypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PropierTypeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPropietor>(entity =>
            {
                entity.HasKey(e => e.PropietorId);

                entity.ToTable("Tbl_Propietor");

                entity.Property(e => e.PropietorId).HasColumnName("PropietorID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblPropietor)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Propietor_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblPropietorRelationship>(entity =>
            {
                entity.HasKey(e => e.PropietorRelationshipId);

                entity.ToTable("Tbl_PropietorRelationship");

                entity.Property(e => e.PropietorRelationshipId)
                    .HasColumnName("PropietorRelationshipID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.Property(e => e.PropierTypeCodeId).HasColumnName("PropierTypeCodeID");

                entity.HasOne(d => d.PartyRoleRelationship)
                    .WithMany(p => p.TblPropietorRelationship)
                    .HasForeignKey(d => d.PartyRoleRelationshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PropietorRelationship_Tbl_PartyRoleRelationship");

                entity.HasOne(d => d.PropierTypeCode)
                    .WithMany(p => p.TblPropietorRelationship)
                    .HasForeignKey(d => d.PropierTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PropietorRelationship_Tbl_PropiertorTypeCodeList");
            });

            modelBuilder.Entity<TblPropietorShip>(entity =>
            {
                entity.HasKey(e => e.PropietorShipId);

                entity.ToTable("Tbl_PropietorShip");

                entity.Property(e => e.PropietorShipId).HasColumnName("PropietorShipID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblPropietorShip)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_PropietorShip_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblRegionalUnit>(entity =>
            {
                entity.HasKey(e => e.RegionalUnitId);

                entity.ToTable("Tbl_RegionalUnit");

                entity.Property(e => e.RegionalUnitId).HasColumnName("RegionalUnitID");

                entity.Property(e => e.OrganizationUnitId).HasColumnName("OrganizationUnitID");

                entity.Property(e => e.RegionalUnitCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RegionalUnitName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrganizationUnit)
                    .WithMany(p => p.TblRegionalUnit)
                    .HasForeignKey(d => d.OrganizationUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_RegionalUnit_Tbl_OrganizationUnit");
            });

            modelBuilder.Entity<TblReinsurer>(entity =>
            {
                entity.HasKey(e => e.ReinsurerId);

                entity.ToTable("Tbl_Reinsurer");

                entity.Property(e => e.ReinsurerId).HasColumnName("ReinsurerID");

                entity.Property(e => e.InsurerId).HasColumnName("InsurerID");

                entity.Property(e => e.PlacementDescription)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ReinsurerType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Insurer)
                    .WithMany(p => p.TblReinsurer)
                    .HasForeignKey(d => d.InsurerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Reinsurer_Tbl_Insurer");
            });

            modelBuilder.Entity<TblRepresentative>(entity =>
            {
                entity.HasKey(e => e.ReprasentativeId);

                entity.ToTable("Tbl_Representative");

                entity.Property(e => e.ReprasentativeId).HasColumnName("ReprasentativeID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.Property(e => e.ReprentativeFunction)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblRepresentative)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Representative_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblRepresentedParty>(entity =>
            {
                entity.HasKey(e => e.RepresentedPartyId);

                entity.ToTable("Tbl_RepresentedParty");

                entity.Property(e => e.RepresentedPartyId).HasColumnName("RepresentedPartyID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblRepresentedParty)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_RepresentedParty_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblResidentRegistration>(entity =>
            {
                entity.HasKey(e => e.ResidentRegistrationId);

                entity.ToTable("Tbl_ResidentRegistration");

                entity.Property(e => e.ResidentRegistrationId).HasColumnName("ResidentRegistrationID");

                entity.Property(e => e.PersonRegistrationId).HasColumnName("PersonRegistrationID");

                entity.HasOne(d => d.PersonRegistration)
                    .WithMany(p => p.TblResidentRegistration)
                    .HasForeignKey(d => d.PersonRegistrationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ResidentRegistration_Tbl_PersonRegistration");
            });

            modelBuilder.Entity<TblRiskManager>(entity =>
            {
                entity.HasKey(e => e.RiskManagerId);

                entity.ToTable("Tbl_RiskManager");

                entity.Property(e => e.RiskManagerId).HasColumnName("RiskManagerID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblRiskManager)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_RiskManager_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblRolePersonPartyContactDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tbl_RolePersonPartyContactDetails");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PkemailContactId).HasColumnName("PKEmailContactID");

                entity.Property(e => e.PktelephoneNumberId).HasColumnName("PKTelephoneNumberID");

                entity.Property(e => e.PostalAddressId).HasColumnName("PostalAddressID");

                entity.Property(e => e.StreetAddressId).HasColumnName("StreetAddressID");
            });

            modelBuilder.Entity<TblSalaryGradeCodeList>(entity =>
            {
                entity.HasKey(e => e.SalaryGradeCodeId);

                entity.ToTable("Tbl_SalaryGradeCodeList");

                entity.HasIndex(e => e.SalaryGradeCode)
                    .HasName("IX_Tbl_SalaryGradeCodeList")
                    .IsUnique();

                entity.Property(e => e.SalaryGradeCodeId).HasColumnName("SalaryGradeCodeID");

                entity.Property(e => e.SalaryGradeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryGradeCodeDesc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblServiceProvider>(entity =>
            {
                entity.HasKey(e => e.ServiceProviderId);

                entity.ToTable("Tbl_ServiceProvider");

                entity.Property(e => e.ServiceProviderId).HasColumnName("ServiceProviderID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.Property(e => e.ServiceProviderTypeCodeId).HasColumnName("ServiceProviderTypeCodeID");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblServiceProvider)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ServiceProvider_Tbl_PartyRoleinRelationShip");

                entity.HasOne(d => d.ServiceProviderTypeCode)
                    .WithMany(p => p.TblServiceProvider)
                    .HasForeignKey(d => d.ServiceProviderTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_ServiceProvider_Tbl_Lt_ServiceProviderTypeCodeList");
            });

            modelBuilder.Entity<TblSignatory>(entity =>
            {
                entity.HasKey(e => e.SignatoryId);

                entity.ToTable("Tbl_Signatory");

                entity.Property(e => e.SignatoryId).HasColumnName("SignatoryID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.Property(e => e.SignatoryDesignationCodeId).HasColumnName("SignatoryDesignationCodeID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblSignatory)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Signatory_Tbl_PartyRoleInAgreement");

                entity.HasOne(d => d.SignatoryDesignationCode)
                    .WithMany(p => p.TblSignatory)
                    .HasForeignKey(d => d.SignatoryDesignationCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Signatory_Tbl_Lt_SignatoryDesignationCodeList");
            });

            modelBuilder.Entity<TblSpouse>(entity =>
            {
                entity.HasKey(e => e.SpouseId);

                entity.ToTable("Tbl_Spouse");

                entity.Property(e => e.SpouseId).HasColumnName("SpouseID");

                entity.Property(e => e.CivilRelationNatureCodeId).HasColumnName("CivilRelationNatureCodeID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.HasOne(d => d.CivilRelationNatureCode)
                    .WithMany(p => p.TblSpouse)
                    .HasForeignKey(d => d.CivilRelationNatureCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Spouse_Tbl_Lt_CivilRelationNatureCodeList");

                entity.HasOne(d => d.PartyRoleinRerlationShip)
                    .WithMany(p => p.TblSpouse)
                    .HasForeignKey(d => d.PartyRoleinRerlationShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Spouse_Tbl_PartyRoleinRelationShip");
            });

            modelBuilder.Entity<TblSurety>(entity =>
            {
                entity.HasKey(e => e.SuretyId);

                entity.ToTable("Tbl_Surety");

                entity.Property(e => e.SuretyId).HasColumnName("SuretyID");

                entity.Property(e => e.PartyRoleInAgreementId).HasColumnName("PartyRoleInAgreementID");

                entity.HasOne(d => d.PartyRoleInAgreement)
                    .WithMany(p => p.TblSurety)
                    .HasForeignKey(d => d.PartyRoleInAgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Surety_Tbl_PartyRoleInAgreement");
            });

            modelBuilder.Entity<TblTaxRegistration>(entity =>
            {
                entity.HasKey(e => e.TaxRegistrationId);

                entity.ToTable("Tbl_TaxRegistration");

                entity.Property(e => e.TaxRegistrationId).HasColumnName("TaxRegistrationID");

                entity.Property(e => e.MembershipType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.TaxCalculationCodeId).HasColumnName("TaxCalculationCodeID");

                entity.Property(e => e.TaxRegistrationTypeCodeId).HasColumnName("TaxRegistrationTypeCodeID");

                entity.HasOne(d => d.Party)
                    .WithMany(p => p.TblTaxRegistration)
                    .HasForeignKey(d => d.PartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TaxRegistration_Tbl_Party");

                entity.HasOne(d => d.TaxCalculationCode)
                    .WithMany(p => p.TblTaxRegistration)
                    .HasForeignKey(d => d.TaxCalculationCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TaxRegistration_Tbl_Lt_TaxCalculationCodeList");

                entity.HasOne(d => d.TaxRegistrationTypeCode)
                    .WithMany(p => p.TblTaxRegistration)
                    .HasForeignKey(d => d.TaxRegistrationTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_TaxRegistration_Tbl_Lt_TaxRegistrationTypeCodeList");
            });

            modelBuilder.Entity<TblTeam>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.ToTable("Tbl_Team");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.OrganizationUnitId).HasColumnName("OrganizationUnitID");

                entity.Property(e => e.TeamCode)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrganizationUnit)
                    .WithMany(p => p.TblTeam)
                    .HasForeignKey(d => d.OrganizationUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Team_Tbl_OrganizationUnit");
            });

            modelBuilder.Entity<TblTelephoneNumber>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tbl_TelephoneNumber");

                entity.Property(e => e.AreaCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FullNumber)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PktelephoneNumberId).HasColumnName("PKTelephoneNumberID");

                entity.Property(e => e.TelephoneNetworkTypeCodeId).HasColumnName("TelephoneNetworkTypeCodeID");

                entity.Property(e => e.TelephoneTypeCodeListId).HasColumnName("TelephoneTypeCodeListID");

                entity.Property(e => e.TrunkPrefix)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVehicleUser>(entity =>
            {
                entity.HasKey(e => e.VehicleUserId);

                entity.ToTable("Tbl_VehicleUser");

                entity.Property(e => e.VehicleUserId).HasColumnName("VehicleUserID");

                entity.Property(e => e.PhysicalObjectUserId).HasColumnName("PhysicalObjectUserID");

                entity.HasOne(d => d.PhysicalObjectUser)
                    .WithMany(p => p.TblVehicleUser)
                    .HasForeignKey(d => d.PhysicalObjectUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_VehicleUser_Tbl_PhysicalObjectUser");
            });

            modelBuilder.Entity<TblVictim>(entity =>
            {
                entity.HasKey(e => e.VictimId);

                entity.ToTable("Tbl_Victim");

                entity.Property(e => e.VictimId)
                    .HasColumnName("VictimID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TblVirtualParty>(entity =>
            {
                entity.HasKey(e => e.VirtualPartyId);

                entity.ToTable("Tbl_VirtualParty");

                entity.Property(e => e.VirtualPartyId).HasColumnName("VirtualPartyID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VirtualPartyNameId).HasColumnName("VirtualPartyNameID");

                entity.HasOne(d => d.VirtualPartyName)
                    .WithMany(p => p.TblVirtualParty)
                    .HasForeignKey(d => d.VirtualPartyNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_VirtualParty_Tbl_VirtualPartyName");
            });

            modelBuilder.Entity<TblVirtualPartyLink>(entity =>
            {
                entity.HasKey(e => e.VirtualPartyLinkId);

                entity.ToTable("Tbl_VirtualPartyLink");

                entity.Property(e => e.VirtualPartyLinkId).HasColumnName("VirtualPartyLinkID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.VirtualPartyId).HasColumnName("VirtualPartyID");

                entity.HasOne(d => d.VirtualParty)
                    .WithMany(p => p.TblVirtualPartyLink)
                    .HasForeignKey(d => d.VirtualPartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_VirtualPartyLink_Tbl_VirtualParty");
            });

            modelBuilder.Entity<TblVirtualPartyName>(entity =>
            {
                entity.HasKey(e => e.VirtualPartyNameId);

                entity.ToTable("Tbl_VirtualPartyName");

                entity.Property(e => e.VirtualPartyNameId).HasColumnName("VirtualPartyNameID");

                entity.Property(e => e.PartyNameId).HasColumnName("PartyNameID");

                entity.Property(e => e.VirtualPartyDesc).IsUnicode(false);

                entity.Property(e => e.VirtualPartyNameCodeId).HasColumnName("VirtualPartyNameCodeID");

                entity.HasOne(d => d.PartyName)
                    .WithMany(p => p.TblVirtualPartyName)
                    .HasForeignKey(d => d.PartyNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_VirtualPartyName_Tbl_PartyName");

                entity.HasOne(d => d.VirtualPartyNameCode)
                    .WithMany(p => p.TblVirtualPartyName)
                    .HasForeignKey(d => d.VirtualPartyNameCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_VirtualPartyName_Tbl_Lt_VirtualPartyNameCodeList");
            });

            modelBuilder.Entity<TblWitness>(entity =>
            {
                entity.HasKey(e => e.WitnessId);

                entity.ToTable("Tbl_Witness");

                entity.Property(e => e.WitnessId)
                    .HasColumnName("WitnessID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PartyRoleinClaimId).HasColumnName("PartyRoleinClaimID");
            });

            modelBuilder.Entity<TlbStreetAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tlb_StreetAddress");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PostDirectionCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreDirectionCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddressId).HasColumnName("StreetAddressID");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_employee");

                entity.Property(e => e.DepartmentalUnitCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentalUnitId).HasColumnName("DepartmentalUnitID");

                entity.Property(e => e.DepartmentalUnitName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EffectivePeriodEnd).HasColumnType("datetime");

                entity.Property(e => e.EffectivePeriodStart).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerId).HasColumnName("EmployerID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitleCodeId).HasColumnName("JobTitleCodeID");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.OrganizationNameId).HasColumnName("OrganizationNameID");

                entity.Property(e => e.OrganizationNameUsageCodeId).HasColumnName("OrganizationNameUsageCodeID");

                entity.Property(e => e.OrganizationRelationShipId).HasColumnName("OrganizationRelationShipID");

                entity.Property(e => e.OrganizationTypeCodeId).HasColumnName("OrganizationTypeCodeID");

                entity.Property(e => e.OrganizationUnitName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyNameId).HasColumnName("PartyNameID");

                entity.Property(e => e.PartyRoleinRerlationShipId).HasColumnName("PartyRoleinRerlationShipID");

                entity.Property(e => e.ProficiencyLevelCodeId).HasColumnName("ProficiencyLevelCodeID");

                entity.Property(e => e.SalaryGradeCodeId).HasColumnName("SalaryGradeCodeID");

                entity.Property(e => e.StatusReason)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwOrgDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_OrgDepartment");

                entity.Property(e => e.DepartmentalUnitCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentalUnitId).HasColumnName("DepartmentalUnitID");

                entity.Property(e => e.DepartmentalUnitName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.OrganizationStatusCodeId).HasColumnName("OrganizationStatusCodeID");

                entity.Property(e => e.OrganizationTypeCodeId).HasColumnName("OrganizationTypeCodeID");

                entity.Property(e => e.OrganizationUnitName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StatusReason)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwOrganization>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_Organization");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EffectivePeriodEnd).HasColumnType("datetime");

                entity.Property(e => e.EffectivePeriodStart).HasColumnType("datetime");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.OrganizationNameId).HasColumnName("OrganizationNameID");

                entity.Property(e => e.OrganizationNameUsageCodeId).HasColumnName("OrganizationNameUsageCodeID");

                entity.Property(e => e.OrganizationRelationShipId).HasColumnName("OrganizationRelationShipID");

                entity.Property(e => e.OrganizationStatusCodeId).HasColumnName("OrganizationStatusCodeID");

                entity.Property(e => e.OrganizationTypeCodeId).HasColumnName("OrganizationTypeCodeID");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyNameId).HasColumnName("PartyNameID");

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.Property(e => e.StatusReason)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwPartypersondetailbasic>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_PARTYPERSONDETAILBASIC");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyRoleRelationshipId).HasColumnName("PartyRoleRelationshipID");

                entity.Property(e => e.PartyTypeCodeId).HasColumnName("PartyTypeCodeID");

                entity.Property(e => e.PersonDetaiId).HasColumnName("PersonDetaiID");

                entity.Property(e => e.PersonDetailCodeId).HasColumnName("PersonDetailCodeID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");
            });

            modelBuilder.Entity<VwPersondetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_PERSONDETAIL");

                entity.Property(e => e.AddressLines).IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BloodTypeCodeId).HasColumnName("BloodTypeCodeID");

                entity.Property(e => e.BoxNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Capital)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CarrierRoute)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCodeId).HasColumnName("CountryCodeID");

                entity.Property(e => e.CrossMonthlyIncomeId).HasColumnName("CrossMonthlyIncomeID");

                entity.Property(e => e.EmailAddress).IsUnicode(false);

                entity.Property(e => e.EthnicityId).HasColumnName("EthnicityID");

                entity.Property(e => e.FloorNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FundAssetId).HasColumnName("FundAssetID");

                entity.Property(e => e.GenderCodeId).HasColumnName("GenderCodeID");

                entity.Property(e => e.GivenName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdentityNumber)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Initials)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Number).IsUnicode(false);

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PersonDetailCodeId).HasColumnName("PersonDetailCodeID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PersonNameUsageCodeId).HasColumnName("PersonNameUsageCodeID");

                entity.Property(e => e.PersonReferalLinkId).HasColumnName("PersonReferalLinkID");

                entity.Property(e => e.PersonRegistrationTypeCodeId).HasColumnName("PersonRegistrationTypeCodeID");

                entity.Property(e => e.PostalBarCode)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PostalPostDirectionCode)
                    .HasColumnName("postal_PostDirectionCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalPreDirectionCode)
                    .HasColumnName("postal_PreDirectionCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrefixTitleCodeId).HasColumnName("PrefixTitleCodeID");

                entity.Property(e => e.StreetName)
                    .HasColumnName("Street_Name")
                    .IsUnicode(false);

                entity.Property(e => e.StreetName1)
                    .HasColumnName("StreetName")
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetPostDirectionCode)
                    .HasColumnName("street_postDirectionCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetPreDirectionCode)
                    .HasColumnName("street_PreDirectionCode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetTypeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Suffix)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TypeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UnitNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityCodeId).HasColumnName("ValidityCodeID");
            });

            modelBuilder.Entity<VwVirtualPartyPartyLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_VirtualPartyPartyLink");

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyTypeCodeId).HasColumnName("PartyTypeCodeID");

                entity.Property(e => e.VirtualPartyDesc).IsUnicode(false);

                entity.Property(e => e.VirtualPartyId).HasColumnName("VirtualPartyID");

                entity.Property(e => e.VirtualPartyLinkId).HasColumnName("VirtualPartyLinkID");

                entity.Property(e => e.VirtualPartyName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwVirtualPartyPartyLinkV2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_VirtualPartyPartyLinkV2");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PartyId).HasColumnName("PartyID");

                entity.Property(e => e.PartyTypeCodeId).HasColumnName("PartyTypeCodeID");

                entity.Property(e => e.VirtualPartyDesc).IsUnicode(false);

                entity.Property(e => e.VirtualPartyId).HasColumnName("VirtualPartyID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
