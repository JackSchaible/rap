using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Rap.Data.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private ApplicationDbContext _ctx;
        private string _rootPath;

        public DbInitializer(ApplicationDbContext ctx, IOptionsMonitor<InitializerOptions> options)
        {
            _ctx = ctx;
            _rootPath = options.CurrentValue.RootPath;
        }

        public void Initialize()
        {
            if (_ctx.Flights.Any()) return;

            using (var fs = new FileStream(Path.Combine(_rootPath, "Assets", "seed-data.json"), FileMode.Open))
                using (var doc = JsonDocument.Parse(fs))
                    foreach(var flightElement in doc.RootElement.EnumerateArray())
                    {
                        JsonElement
                            linksElement = flightElement.GetProperty("links"),
                            rocketElement = flightElement.GetProperty("rocket");

                        _ctx.Flights.Add(new Flight
                        {
                            FlightNumber = flightElement.GetProperty("flight_number").GetInt32(),
                            MissionName = flightElement.GetProperty("mission_name").GetString(),
                            LaunchDateUTC = flightElement.GetProperty("launch_date_utc").GetDateTime(),
                            Details = flightElement.GetProperty("details").GetString(),
                            ArticleLink = linksElement.GetProperty("article_link").GetString(),
                            MissionPatch = linksElement.GetProperty("mission_patch").GetString(),
                            RocketName = rocketElement.GetProperty("rocket_name").GetString(),
                            RocketType = rocketElement.GetProperty("rocket_type").GetString(),
                            LandSuccess = ExtractLanded(rocketElement),
                            Reuse = ExtractReuse(flightElement),
                            RedditCampaign = !linksElement.GetProperty("reddit_campaign").ValueEquals("null")
                        });
                    }

            _ctx.SaveChanges();
        }

        private bool? ExtractLanded(JsonElement rocketElement)
        {
            bool? result = null;

            var firstStageCoresElement = rocketElement.GetProperty("first_stage");
            var coresArray = firstStageCoresElement.GetProperty("cores");
            var coreElement = coresArray.EnumerateArray().ToArray()[0];
            var landSuccessElement = coreElement.GetProperty("land_success");

            if (landSuccessElement.ValueKind != JsonValueKind.Null)
                result = landSuccessElement.GetBoolean();

            return result;
        }
        private bool ExtractReuse(JsonElement flightElement)
        {
            bool result = false;

            foreach (var property in flightElement.GetProperty("reuse").EnumerateObject())
                if (property.Value.GetBoolean())
                    result = true;

            return result;
        }
    }
}
