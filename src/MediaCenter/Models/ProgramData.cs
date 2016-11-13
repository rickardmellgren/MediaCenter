using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCenter.Models
{
    public class ProgramData
    {
        public int Id { get; set; }

        public int OrderNo { get; set; }
        public string Channel { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public double Length { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Presenter { get; set; }
        public string[] Director { get; set; }
        public string[] Actor { get; set; }
        public string Category { get; set; }
        public string Episode { get; set; }
        public int DateRecorded { get; set; }

        public ProgramData(int id, int orderNo, string channel, DateTime start, DateTime stop, double length, string title, string description)
        {
            Id = id;
            OrderNo = orderNo;
            Channel = channel;
            Start = start;
            Stop = stop;
            Length = length;
            Title = title;
            Description = description;
        }

        //public ProgramData(string channel, DateTime start, DateTime end, string title, string description, string[] presenter, string[] director, string[] actor, string category, string episode, int dateRecorded)
        //{
        //    Channel = channel;
        //    Start = start;
        //    End = end;
        //    Title = title;
        //    Description = description;
        //    Presenter = presenter;
        //    Director = director;
        //    Actor = actor;
        //    Category = category;
        //    Episode = episode;
        //    DateRecorded = dateRecorded;
        //}
    }
}
