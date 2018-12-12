using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WelfareTrip2017REST.Models
{
    public class TripMain
    {
        public int SeqId { get; set; }
        public string Company { get; set; }
        public string BranchDept { get; set; }
        public int EpfNo { get; set; }
        public string MemberName { get; set; }

        public string MemberGender { get; set; }
        public string MaritialStatus { get; set; }
        public string SpouseName { get; set; }
        public int IsMemberParticipate { get; set; }
        public int IsSpouseParticipate { get; set; }
        
        public string SystemDate { get; set; }
    }
}