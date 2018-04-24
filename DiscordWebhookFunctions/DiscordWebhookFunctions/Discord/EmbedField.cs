using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordWebhookFunctions.Discord
{
    public class EmbedField
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("inline")]
        public bool Inline { get; set; }
    }
}