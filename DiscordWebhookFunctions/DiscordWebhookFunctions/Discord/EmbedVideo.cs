using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordWebhookFunctions.Discord
{
    public class EmbedVideo
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}