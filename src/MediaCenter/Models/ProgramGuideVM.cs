using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCenter.Models
{
    public class ProgramGuideVM
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public string Channel { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProgramGuideVM(int id, int orderNo, string channel, DateTime start, DateTime stop, string title, string description)
        {
            Id = id;
            OrderNo = orderNo;
            Channel = channel;
            Start = start;
            Stop = stop;
            Title = title;
            Description = description;
        }

        public ProgramGuideVM()
        {

        }
    }
}
