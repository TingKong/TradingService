using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingServices.Models
{
    public class Traders
    {
        public int ID { get; set; }
        public string Name  { get; set; }
        public int YearsExp { get; set; }
        public string ShortDesp { get; set; }
        public string AuthKey { get; set; }


    }
}