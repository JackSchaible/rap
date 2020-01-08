using AutoMapper;
using Rap.Data;
using System;

namespace Rap.Models
{
    public class FlightModel
    {
        public string Badge { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime LaunchDate { get; set; }
        public string Details { get; set; }
        public int ID { get; set; }
        public string Link { get; set; }
        public bool Landed { get; set; }
        public bool Reused { get; set; }
        public bool Reddit { get; set; }
    }

    public class FlightModelMapper : Profile
    {
        public FlightModelMapper()
        {
            CreateMap<Flight, FlightModel>()
                .ForMember(d => d.Badge, o => o.MapFrom(s => s.MissionPatch))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.MissionName))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.RocketType))
                .ForMember(d => d.LaunchDate, o => o.MapFrom(s => s.LaunchDateUTC))
                .ForMember(d => d.ID, o => o.MapFrom(s => s.FlightNumber))
                .ForMember(d => d.Link, o => o.MapFrom(s => s.ArticleLink))
                .ForMember(d => d.Landed, o => o.MapFrom(s => s.LandSuccess))
                .ForMember(d => d.Reused, o => o.MapFrom(s => s.Reuse))
                .ForMember(d => d.Reddit, o => o.MapFrom(s => s.RedditCampaign));
        }
    }
}
