using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCenter.Models
{
    public class ProgramChannelVM
    {
        public ProgramGuideVM[] Programs { get; set; }
        public TvChannel[] TvChannels { get; set; }

    }
}
