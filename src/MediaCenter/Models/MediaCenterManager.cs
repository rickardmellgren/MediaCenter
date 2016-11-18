using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MediaCenter.Models
{
    public static class MediaCenterManager
    {
        static List<ProgramData> programs = new List<ProgramData>();

        static List<TvChannel> channels = new List<TvChannel>();

        static List<TvChannel> channelOrder = new List<TvChannel>
        {
            new TvChannel(1, "svt1.svt.se" ,"SVT1", "http://chanlogos.xmltv.se/svt1.svt.se.png"),
            new TvChannel(2, "svt2.svt.se", "SVT2", "http://chanlogos.xmltv.se/svt2.svt.se.png"),
            new TvChannel(3, "tv3.se", "TV3 (SE)", "http://chanlogos.xmltv.se/tv3.se.png"),
            new TvChannel(4, "tv4.se", "TV4", "http://chanlogos.xmltv.se/tv4.se.png"),
            new TvChannel(5, "kanal5.se", "Kanal 5 (SE)", "http://chanlogos.xmltv.se/kanal5.se.png"),
            new TvChannel(6, "tv6.se", "TV6 (SE)", "http://chanlogos.xmltv.se/tv6.se.png"),
            new TvChannel(7, "sjuan.se", "Sjuan", "http://chanlogos.xmltv.se/sjuan.se.png"),
            new TvChannel(8, "tv8.se", "TV8", "http://chanlogos.xmltv.se/tv8.se.png"),
            new TvChannel(9, "kanal9.se", "Kanal 9", "http://chanlogos.xmltv.se/kanal9.se.png"),
            new TvChannel(10, "tv10.se", "TV10", "http://chanlogos.xmltv.se/tv10.se.png"),
            new TvChannel(11, "tv11.sbstv.se", "Kanal 11", "http://chanlogos.xmltv.se/tv11.sbstv.se.png"),
            new TvChannel(12, "tv12.tv4.se", "TV12", "http://chanlogos.xmltv.se/tv12.tv4.se.png"),
            new TvChannel(13, "kunskapskanalen.svt.se", "Kunskapskanalen", "http://chanlogos.xmltv.se/kunskapskanalen.svt.se.png"),
            new TvChannel(14, "svt24.svt.se", "SVT24", "http://chanlogos.xmltv.se/svt24.svt.se.png"),
            //new TvChannel(15, "svtb.svt.se", "Barnkanalen", "http://chanlogos.xmltv.se/svtb.svt.se.png"),
            //new TvChannel(16, "discoverychannel.se", "Discovery Channel (SE)", "http://chanlogos.xmltv.se/discoverychannel.se.png"),
            //new TvChannel(17, "hd.eurosport.se", "Eurosport HD", "http://chanlogos.xmltv.se/hd.eurosport.se.png"),
            //new TvChannel(18, "hd.eurosport2.se", "Eurosport 2 HD", "http://chanlogos.xmltv.se/hd.eurosport2.se.png"),
            //new TvChannel(19, "mtv.se", "MTV (SE)", "http://chanlogos.xmltv.se/mtv.se.png"),
        };

        static MediaCenterManager()
        {
            //Load xml
            XDocument xdoc = XDocument.Load("/xml\\se3.xml");

            //Console.WriteLine(xdoc);


            string formatString = "yyyyMMddHHmmss zzzz";
            var tvShows = from item in xdoc.Descendants("programme")
                       select new
                       {
                           Channel = item.Attribute("channel").Value,
                           Start = DateTime.ParseExact(item.Attribute("start").Value, formatString, null),
                           Stop = DateTime.ParseExact(item.Attribute("stop").Value, formatString, null),
                           Title = item.Element("title").Value,
                           Description = item.Element("desc") != null ? item.Element("desc").Value : "No description",
                       };

            int programNo = 1;
            foreach (var p in tvShows)
            {
                TimeSpan span = p.Stop.Subtract(p.Start);
                double showLength = span.TotalMinutes;
                int orderNo = 1;
                foreach (var item in channelOrder)
                {
                    if (p.Channel == item.ChannelName)
                    {
                        orderNo = item.OrderNo;
                        programs.Add(new ProgramData(programNo, orderNo, p.Channel, p.Start, p.Stop, showLength, p.Title, p.Description));
                    }
                }
                
                //Console.WriteLine(p.Title + "   " + p.Description + "  " + p.Channel + "    " + p.Start + "-" + p.Stop);
                programNo++;
            }
        }

        internal static ProgramGuideVM[] ListPrograms()
        {
            DateTime timeNow = DateTime.Now;
            return programs
                .Where(p => p.Stop > timeNow)
                .OrderBy(p => p.OrderNo)
                .ThenBy(p => p.Start)
                .Select(p => new ProgramGuideVM
                {
                    Id = p.Id,
                    OrderNo = p.OrderNo,
                    Channel = p.Channel,
                    Title = p.Title,
                    Stop = p.Stop,
                    Start = p.Start
                }).ToArray();
        }

        internal static TvChannel[] ListChannels()
        {
            return channelOrder.OrderBy(c => c.OrderNo)
                    .Select(c => new TvChannel
                    {
                        OrderNo = c.OrderNo,
                        DisplayName = c.DisplayName,
                        Icon = c.Icon
                    }).ToArray();
        }
    }
}
