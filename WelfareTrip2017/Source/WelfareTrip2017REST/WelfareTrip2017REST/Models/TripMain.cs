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
        public string Ch1Name { get; set; }
        public string Ch1Dob { get; set; }
        public string Ch2Name { get; set; }
        public string Ch2Dob { get; set; }
        public string Ch3Name { get; set; }
        public string Ch3Dob { get; set; }
        public string Ch4Name { get; set; }
        public string Ch4Dob { get; set; }
        public string Ch5Name { get; set; }
        public string Ch5Dob { get; set; }
        public int IsMemberParticipate { get; set; }
        public int IsSpouseParticipate { get; set; }
        public int IsCh1Participate { get; set; }
        public int IsCh2Participate { get; set; }
        public int IsCh3Participate { get; set; }
        public int IsCh4Participate { get; set; }
        public int IsCh5Participate { get; set; }

        public string ParticipateDate { get; set; }
        public int MemberCost { get; set; }
        public string RoomSeqId { get; set; }
        public string Remarks { get; set; }
        public string SystemDate { get; set; }
    }
}