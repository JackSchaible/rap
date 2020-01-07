using System;

namespace Rap.Data
{
    public class Flight
    {
        public int FlightID { get; set; }
        public int FlightNumber { get; set; }
        public string MissionName { get; set; }
        public DateTime LaunchDateUTC { get; set; }
        public string Details { get; set; }

        public string ArticleLink { get; set; }
        public string MissionPatch { get; set; }

        public string RocketName { get; set; }
        public string RocketType { get; set; }

        public bool? LandSuccess { get; set; }
        public bool Reuse { get; set; }
        public bool RedditCampaign { get; set; }
    }
}
