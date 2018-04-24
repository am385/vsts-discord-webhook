using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordWebhookFunctions.Discord
{
    public class Webhook
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("tts")]
        public bool TTS { get; set; }

        [JsonProperty("file")]
        public byte[] File { get; set; }

        [JsonProperty("embeds")]
        public List<Embed> Embeds { get; set; } = new List<Embed>();
    }
}
