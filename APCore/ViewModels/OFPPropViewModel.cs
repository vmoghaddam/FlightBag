using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APCore.ViewModels
{
    public class OFPPropViewModel
    {
        public int Id { get; set; }
        public int OFPId { get; set; }
        public string PropName { get; set; }
        public string PropValue { get; set; }
        public string PropType { get; set; }
        public string User { get; set; }
        public string DateUpdate { get; set; }
    }
}
