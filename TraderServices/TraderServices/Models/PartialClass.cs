using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TraderServices
{
    [MetadataType(typeof(TradeSkillMetaData))]
    public partial class TradeSkill
    {

    }

    public class TradeSkillMetaData
    {
        [DisplayName("Trader's Name")]
        public int TraderID { get; set; }
        [DisplayName("Trade")]
        public int CategoryID { get; set; }
        [DisplayName("Years of Experience")]
        public string YearsOfExp { get; set; }
        [DisplayName("Detail of Experience")]
        public string ShortDes { get; set; }




    }

    [MetadataType(typeof(TraderMetaData))]
    public partial class Trader
    {

    }

    public class TraderMetaData
    {
        [DisplayName("Name")]
        public int ID { get; set; }

        [DisplayName("Email Address")]
        public string AuthKey { get; set; }



    }

    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {

    }

    public class CategoryMetaData
    {
        [DisplayName("Name")]
        public int ID { get; set; }

        [DisplayName("Description")]
        public string Desc { get; set; }



    }

    [MetadataType(typeof(JobMetaData))]
    public partial class Job
    {

    }

    public class JobMetaData
    {
        [DisplayName("Job")]
        public string Names { get; set; }

        [DisplayName("Description")]
        public string Details { get; set; }

        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }


        //[DisplayName("Category")]
        //public string CategoryID { get; set; }


    }
}