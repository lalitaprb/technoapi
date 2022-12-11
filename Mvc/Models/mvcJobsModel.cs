using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcJobsModel
    {
        public int Id { get; set; }
        public string code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<int> DeptId { get; set; }
        public Nullable<System.DateTime> posteddate { get; set; }
        public Nullable<System.DateTime> closingdate { get; set; }
    }
}