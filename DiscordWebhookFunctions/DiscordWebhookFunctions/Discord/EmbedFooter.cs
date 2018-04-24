using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordWebhookFunctions.Discord
{
    public class EmbedFooter
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("proxy_icon_url")]
        public string ProxyIconUrl { get; set; }
    }
}
