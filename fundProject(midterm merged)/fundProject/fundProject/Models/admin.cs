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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class admin
    {
        public admin()
        {
            this.acceptReqs = new HashSet<acceptReq>();
        }

        public int aId { get; set; }


        public string aName { get; set; }


        public string aUserName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        public string aEmail { get; set; }
        public string aGender { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string aPassword { get; set; }

        public virtual ICollection<acceptReq> acceptReqs { get; set; }
    }
}