//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fundProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class leave
    {
        public int leaveId { get; set; }
        [Required(ErrorMessage = "Required")]

        public int eId { get; set; }
        [Required(ErrorMessage = "Required")]
        public string description { get; set; }
        public Nullable<int> leaveStatus { get; set; }
    
        public virtual employee employee { get; set; }
    }
}