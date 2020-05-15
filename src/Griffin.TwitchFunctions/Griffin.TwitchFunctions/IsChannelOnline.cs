using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Griffin.TwitchFunctions
{
    public static class IsChannelOnline
    {
        [FunctionName("IsChannelOnline")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            var clientId = Environment.GetEnvironmentVariable("twitch:clientId");
            var accessToken = Environment.GetEnvironmentVariable("twitch:accessToken");

            var twitch = new Twitch(clientId, accessToken);

            string name = req.Query["channelName"];

            if (string.IsNullOrEmpty(name)) return new BadRequestObjectResult("Channel name was missing.");

            var isOnline = await twitch.IsChannelOnlineAsync(name);

            var badge = new ShieldBadge
            {
                Label = "twitch.tv/1kevgriff",
                LabelColor = "lightgrey",
                Style = "flat",
                Message = isOnline ? "LIVE" : "OFFLINE",
                Color = isOnline ? "#2f855a" : "red"
            };

            return new JsonResult(badge);
        }
    }
}
