using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingServices.Models
{
    public class Jobs
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public DateTime DueDate { get; set; }


    }
}