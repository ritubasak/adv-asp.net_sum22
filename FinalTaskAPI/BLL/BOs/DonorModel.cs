using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BOs
{
    public class DonorModel 
    {
        public int dnId { get; set; }
        public string dnName { get; set; }
        public string dnUserName { get; set; }
        public string dnEmail { get; set; }
        public string dnGender { get; set; }
        public string dnPassword { get; set; }
    }
}
