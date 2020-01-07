using System;
using System.ComponentModel.DataAnnotations;

namespace Rap.Data
{
    public class Flight
    {
        [Key]
        public int FlightNumber { get; set; }
        public DateTime LaunchDateUTC { get; set; }
        public string Details { get; set; }
        public string ArticleLink { get; set; }

        public string MissionPatch { get; set; }
        public string MissionName { get; set; }

        //rocket/rocket_name
        public string RocketName { get; set; }
        //rocket/rocket_type
        public string RocketType { get; set; }

        //rocket/first_stage/cores/[0]/land_success
        public bool LandSuccess { get; set; }

        //reuse/any = true
        public bool Reuse { get; set; }
        //links/reddit_campaign
        public bool RedditCampaign { get; set; }
    }
}
