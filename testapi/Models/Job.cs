//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testapi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Job
    {
        public int Id { get; set; }
        public string code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> LocationId { get; set; }
       public Nullable<int> departmentId { get; set; }
        public Nullable<System.DateTime> posteddate { get; set; }
        public Nullable<System.DateTime> closingdate { get; set; }


    }
}