using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TraderServices.Models
{
    public class TraderSkills
    {
        public TradeSkill TraderS { get; set; }

        public Trader TraderP { get; set; }
        public Category TraderC { get; set; }

    }
}