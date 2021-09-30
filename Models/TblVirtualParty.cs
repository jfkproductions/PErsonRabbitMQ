using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class TblVirtualParty
    {
        public TblVirtualParty()
        {
            TblVirtualPartyLink = new HashSet<TblVirtualPartyLink>();
        }

        public int VirtualPartyId { get; set; }
        public int VirtualPartyNameId { get; set; }
        public string Description { get; set; }
        public int InternalExternalTypeId { get; set; }
        public int PartyId { get; set; }
        public virtual TblVirtualPartyName VirtualPartyName { get; set; }
        public virtual ICollection<TblVirtualPartyLink> TblVirtualPartyLink { get; set; }
    }
}
