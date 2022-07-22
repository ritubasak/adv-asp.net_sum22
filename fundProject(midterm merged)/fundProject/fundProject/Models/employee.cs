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

    public partial class employee
    {
        public employee()
        {
            this.acceptReqs = new HashSet<acceptReq>();
        }
    
        public int eId { get; set; }
        public string eName { get; set; }
        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required")]
        public string eUserName { get; set; }
        public string eEmail { get; set; }
        public string eGender { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string ePassword { get; set; }
    
        public virtual ICollection<acceptReq> acceptReqs { get; set; }
        public virtual leave leave { get; set; }
    }
}