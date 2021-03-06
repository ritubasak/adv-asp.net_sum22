//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Donor.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Tbl_Donor
    {
        public int dnId { get; set; }

        [required(ErrorMessage = "Required")]
        public string dnName { get; set; }

        [required(ErrorMessage = "Required")]
        [DisplayName("Username")]
        public string dnUserName { get; set; }

        [required(ErrorMessage = "Required")]
        [EmailAddress]
        public string dnEmail { get; set; }
        [required(ErrorMessage = "Required")]

        public string dnGender { get; set; }

        [DisplayName("Password")]
        [required(ErrorMessage = "Required")]
        [MinLength(6, ErrorMessage = "Minimum digit should be 6!")]
        [DataType(DataType.Password)]
        public string dnPassword { get; set; }
    }
}
