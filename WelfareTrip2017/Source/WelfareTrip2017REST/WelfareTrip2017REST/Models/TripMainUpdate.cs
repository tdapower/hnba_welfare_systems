using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WelfareTrip2017REST.Models
{
    public class TripMainUpdate
    {
        public int SeqId { get; set; }
        public int IsMemberParticipate { get; set; }
        public int IsSpouseParticipate { get; set; }
        public int IsCh1Participate { get; set; }
        public int IsCh2Participate { get; set; }
        public int IsCh3Participate { get; set; }
        public int IsCh4Participate { get; set; }
        public int IsCh5Participate { get; set; }
        public string ParticipateDate { get; set; }
        public double MemberCost { get; set; }
        public string Remarks { get; set; }
    }
}