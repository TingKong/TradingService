using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TraderServices.Models
{
    public class Traderskills
    {
        [DisplayName("Skill Name")]
        public Movie CustMovie { get; set; }

        [DisplayName("Customer")]
        public Customer Cust { get; set; }

    }
}