using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TraderServices.Models
{
    public class Jobs
    {
        public int ID { get; set; }
        [DisplayName("Job Title")]

        public string Names { get; set; }
        public string Details { get; set; }
        public System.DateTime DueDate { get; set; }
        public int TraderID { get; set; }
        public int CategoryID { get; set; }


        public Trader traderPerson { get; set; }
        public List<Category> catList {get; set;}




        //public static Trader GetTraderByUserName(Trader traderjob)
        //{
        //    string userName = User.Identity.Name;

        //    return (traderjob);
        //}


    }
}