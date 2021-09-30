using Party_Dll.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FnPerson.Classes
{
    public class VirtualParty
    {
        public int? VirtualPartyId { get; set; }
        public string Description { get; set; }
        public Enviroment Enviroment { get; set; }
        public InternalExgernalType InternalExgernalType { get; set; }
        public Party Party { get; set; }
        public VirtualPartyName VirtualPartyName { get; set; }
    }

    public class Party
    {
        public int PartyId { get; set; }
        public int PartyTypeCodeId { get; set; }
    }
    public class VirtualPartyName
    {
        public int VirtualPartyNameId { get; set; }
        public string VirtualPartyDesc { get; set; }
        public int VirtualPartyNameCodeId { get; set; }
        public int PartyNameId { get; set; }
    }
        public class Enviroment
    {
        public int EnviromentId { get; set; }
        public string EnvironmentName { get; set; }
        public string EnviornmentType { get; set; }
    }

    public partial class InternalExgernalType
    { 
        public int InternalExgernalTypeId { get; set; }
        public string InternalExgernalTypeName { get; set; }
        public string InternalExgernalDescription { get; set; }        
    }
}
