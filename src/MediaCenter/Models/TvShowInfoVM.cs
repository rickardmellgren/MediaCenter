using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCenter.Models
{
    public class TvShowInfoVM
    {
        public ProgramGuideVM Program { get; set; }
        public TvChannel Channel { get; set; }
    }
}
