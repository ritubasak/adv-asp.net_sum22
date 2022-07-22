using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace fundProject.Models
{
    public class gmail
    {
        [Required(ErrorMessage = "Required")]
        public string To { get; set; }

        public string From { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Body { get; set; }
    }
}