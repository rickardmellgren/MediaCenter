using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaCenter.Models
{
    public class TvChannel
    {
        public int OrderNo { get; set; }
        public string ChannelName { get; set; }
        public string DisplayName { get; set; }
        public string Icon { get; set; }

        public TvChannel(int orderNo, string channelName, string displayName, string icon)
        {
            OrderNo = orderNo;
            ChannelName = channelName;
            DisplayName = displayName;
            Icon = icon;

        }

        public TvChannel(string channelName, string displayName, string icon)
        {

            ChannelName = channelName;
            DisplayName = displayName;
            Icon = icon;

        }

        public TvChannel(int orderNo, string displayName)
        {
            OrderNo = orderNo;
            DisplayName = displayName;
        }

        public TvChannel()
        {

        }
    }
}
