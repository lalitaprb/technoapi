using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testapi.Models
{
    public class Jobdetail
    {
        public Job jobs { get; set; }
        public Location location { get; set; }
        public Department department { get; set; }
    }

}