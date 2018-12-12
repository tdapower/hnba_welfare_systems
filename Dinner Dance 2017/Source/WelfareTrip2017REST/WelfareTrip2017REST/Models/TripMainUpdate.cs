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
    }
}